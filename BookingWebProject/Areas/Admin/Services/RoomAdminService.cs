namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Admin.Contracts;
    using Admin.Models.Room;
    using Data;
    using Models.Picture;
    using Infrastructure.Data.Models;
    using Core.Models.RoomBasis;
    using Core.Models.Pager;
    using BookingWebProject.Core.Models.Hotel;

    public class RoomAdminService : IRoomAdminService
    {
        private readonly IWebHostEnvironment env;
        private readonly BookingContext bookingContext;
        public RoomAdminService(BookingContext bookingContext, IWebHostEnvironment env)
        {
            this.bookingContext = bookingContext;
            this.env = env;
        }

        public async Task<IEnumerable<RoomAdminViewModel>> GetHotelRoomsByHotelIdAsync(int hotelId, Pager pager)
        {
            IEnumerable<RoomAdminViewModel> hotelRooms = await bookingContext.Rooms
                .Where(r => r.HotelId == hotelId)
                .OrderBy(r => r.IsDeleted)
                .Select(r => new RoomAdminViewModel()
                {
                    Id = r.Id,
                    RoomTypeId = r.RoomTypeId,
                    RoomTypeName = r.RoomType.Name,
                    ImgPath = r.Pictures.Where(p => !p.IsDeleted).First().Path,
                    IsDeleted = r.IsDeleted,
                    PricePerNight = r.PricePerNight,
                    HotelId = r.HotelId
                })
                .Skip((pager.CurrentPage - 1) * pager.PageSize)
                .Take(pager.PageSize)
                .OrderBy(r => r.RoomTypeId)
                .ToArrayAsync();
            return hotelRooms;
        }

        public async Task<bool> IsRoomByGivenTypeExistsInHotel(int hotelId, int roomTypeId)
        {
            return await bookingContext.Rooms.AnyAsync(r => r.RoomTypeId == roomTypeId && r.HotelId == hotelId);
        }
        public async Task<EditRoomViewModel> GetRoomToEditAsync(int roomTypeId, int hotelId)
        {
            EditRoomViewModel roomToEdit = await bookingContext.Rooms
                .Where(r => r.RoomTypeId == roomTypeId && r.HotelId == hotelId)
                .Select(r => new EditRoomViewModel()
                {
                    PeopleCapacity = r.Capacity,
                    PricePerNight = r.PricePerNight,
                    Description = r.Description,
                    Pictures = r.Pictures.Select(p => new PictureAdminViewModel()
                    {
                        Id = p.Id,
                        IsDeleted = p.IsDeleted,
                        Path = p.Path
                    }),
                    CurrentRoomBasis = r.RoomBases.Where(rb => !rb.IsDeleted).Select(rb => new RoomBasisViewModel() { Id = rb.RoomBasisId, Name = rb.RoomBasis.Name }).ToArray(),
                })
                .FirstAsync();

            return roomToEdit;

        }

        public async Task UpdateRoomsInHotelByRoomTypeIdAsync(int roomTypeId, int hotelId, EditRoomViewModel editRoomViewModel)
        {
            IEnumerable<Room> roomsToUpdate = await bookingContext.Rooms
                .Where(r => r.RoomTypeId == roomTypeId && r.HotelId == hotelId)
                .ToArrayAsync();


            foreach (Room room in roomsToUpdate)
            {
                room.PricePerNight = editRoomViewModel.PricePerNight;
                room.Capacity = editRoomViewModel.PeopleCapacity;
                room.Description = editRoomViewModel.Description;
                if (editRoomViewModel.SelectedRoomBasisIds.Any())
                {
                    foreach (int roomBasisId in editRoomViewModel.SelectedRoomBasisIds)
                    {
                        if (await bookingContext.RoomsBases.AnyAsync(rb => rb.RoomId == room.Id && rb.RoomBasisId == roomBasisId))
                        {
                            RoomsBases roomBases = await bookingContext.RoomsBases.FirstAsync(rb => rb.RoomId == room.Id && rb.RoomBasisId == roomBasisId);
                            roomBases.IsDeleted = false;
                        }
                        else
                        {
                            await bookingContext.RoomsBases.AddAsync(new RoomsBases() { RoomId = room.Id, RoomBasisId = roomBasisId });
                        }
                    }
                }
            }
            await bookingContext.SaveChangesAsync();
        }

        public async Task AddRoomByGivenRoomTypeInHotelAsync(int hotelId, int roomtypeId)
        {
            Room roomToAddCoppy = await GetRoomByGivenRoomTypeAndHotelIdAsync(hotelId, roomtypeId);
            Room roomToAdd = new Room()
            {
                PricePerNight = roomToAddCoppy.PricePerNight,
                Capacity = roomToAddCoppy.Capacity,
                Description = roomToAddCoppy.Description,
                HotelId = roomToAddCoppy.HotelId,
                RoomTypeId = roomToAddCoppy.RoomTypeId,
                IsDeleted = false
            };
            await bookingContext.Rooms.AddAsync(roomToAdd);
            await bookingContext.SaveChangesAsync();

            foreach (Picture picture in roomToAddCoppy.Pictures)
            {
                roomToAdd.Pictures.Add(new Picture()
                {
                    RoomId = roomToAdd.Id,
                    Path = picture.Path
                });
            }
            foreach (RoomsBases roomBasis in roomToAddCoppy.RoomBases)
            {
                roomToAdd.RoomBases.Add(new RoomsBases()
                {
                    RoomId = roomToAdd.Id,
                    RoomBasisId = roomBasis.RoomBasisId,
                });
            }

            await bookingContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<RoomAdminViewModel>> GetRoomByHotelIdAsync(int hotelId)
        {
            IEnumerable<RoomAdminViewModel> hotelRooms = await bookingContext.Rooms
                 .Where(r => r.HotelId == hotelId)
                 .Select(r => new RoomAdminViewModel()
                 {
                     Id = r.Id,
                     RoomTypeName = r.RoomType.Name,
                     RoomTypeId = r.RoomTypeId,
                     ImgPath = r.Pictures.Where(p => !p.IsDeleted).First().Path,
                     IsDeleted = r.IsDeleted,
                     PricePerNight = r.PricePerNight,
                     HotelId = r.HotelId

                 })
                 .ToArrayAsync();
            return hotelRooms;
        }

        public async Task<int> GetHotelRoomsCountAsync(int hotelId)
        {
            return await bookingContext.Rooms.Where(r => r.HotelId == hotelId).CountAsync();
        }

        public async Task<IEnumerable<RoomAdminViewModel>> GetRoomTypesInHotelByHotelIdAsync(int hotelId)
        {
            IEnumerable<RoomAdminViewModel> hotelRooms = await bookingContext.Rooms
                  .Where(r => r.HotelId == hotelId)
                  .Select(r => new RoomAdminViewModel()
                  {
                      Id = r.Id,
                      RoomTypeName = r.RoomType.Name,
                      RoomTypeId = r.RoomTypeId,
                      ImgPath = r.Pictures.Where(p => !p.IsDeleted).First().Path,
                      IsDeleted = r.IsDeleted,
                      PricePerNight = r.PricePerNight,
                      HotelId = r.HotelId

                  })
                  .ToArrayAsync();
            return hotelRooms.DistinctBy(r => r.RoomTypeId);
        }

        public async Task<bool> CheckIsRoomExistByIdAsync(int roomId)
        {
            return await bookingContext.Rooms.AnyAsync(r => r.Id == roomId);
        }

        public async Task<bool> CheckIfRoomIsAlreadyDeletedByGivenIdAsync(int roomId)
        {
            return await bookingContext.Rooms.AnyAsync(r => r.Id == r.Id && r.IsDeleted);
        }

        public async Task DeleteRoomByIdAsync(int roomId)
        {
            Room roomToDelete = await FindRoomByIdAsync(roomId);
            roomToDelete.IsDeleted = true;
            await bookingContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIfRoomIsAlreadyRecoveredByIdAsync(int roomId)
        {
            return await bookingContext.Rooms.AnyAsync(r => r.Id == roomId && !r.IsDeleted);
        }

        public async Task RecoverRoomByIdAsync(int roomId)
        {
            Room roomToRecover = await FindRoomByIdAsync(roomId);
            roomToRecover.IsDeleted = false;
            await bookingContext.SaveChangesAsync();
        }

        public async Task<int> CreateRoomAsync(CreateRoomViewModel createRoomViewModel)
        {
            Room roomToCreate = new Room()
            {
                Capacity = createRoomViewModel.PeopleCapacity,
                RoomTypeId = createRoomViewModel.RoomTypeId,
                HotelId = createRoomViewModel.HotelId,
                Description = createRoomViewModel.Description,
                PricePerNight = createRoomViewModel.PricePerNight,
                IsDeleted = false,
            };
            await bookingContext.Rooms.AddAsync(roomToCreate);
            await bookingContext.SaveChangesAsync();

            if (createRoomViewModel.SelectedRoomBasesIds.Any())
            {
                foreach (int roomBasisId in createRoomViewModel.SelectedRoomBasesIds)
                {
                    await bookingContext.RoomsBases.AddAsync(new RoomsBases() { RoomBasisId = roomBasisId, RoomId = roomToCreate.Id });
                }
            }
            await bookingContext.SaveChangesAsync();
            return roomToCreate.Id;
        }

        public async Task CreateRoomImgsAsync(int roomId, CreateRoomViewModel createRoomViewModel)
        {
            Room roomToGet = await bookingContext.Rooms
                .Include(r => r.Hotel)
            .FirstAsync(r => r.Id == roomId);

            string roomFolderName = $"{roomToGet.Hotel.Name} rooms";
            string uploadPath = Path.Combine(env.WebRootPath, "img", "Rooms", roomFolderName);
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            foreach (IFormFile file in createRoomViewModel.PicturesFileProvider!)
            {
                if (file.Length > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(uploadPath, fileName);
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        await bookingContext.Pictures.AddAsync(new Picture() { Path = $"/img/Rooms/{roomFolderName}/{fileName}", RoomId = roomId });
                        await bookingContext.SaveChangesAsync();
                        await file.CopyToAsync(stream);
                    }
                }
            }
        }
        private async Task<Room> GetRoomByGivenRoomTypeAndHotelIdAsync(int hotelId, int roomtypeId)
        {
            Room roomToFind = await bookingContext.Rooms
                .Where(r => r.RoomTypeId == roomtypeId && r.HotelId == hotelId)
                .Include(r => r.RoomBases)
                .Include(r => r.Pictures)
                .FirstAsync();

            return roomToFind;
        }
        private async Task<Room> FindRoomByIdAsync(int roomId)
        {
            Room room = await bookingContext.Rooms.FirstAsync(r => r.Id == roomId);
            return room;
        }
    }
}
