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
    using Models.RoomBasis;

    public class RoomAdminService : IRoomAdminService
    {
        private readonly BookingContext bookingContext;
        public RoomAdminService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<RoomAdminViewModel>> GetHotelRoomsByHotelIdAsync(int hotelId)
        {
            IEnumerable<RoomAdminViewModel> hotelRooms = await bookingContext.Rooms
                .Where(r => r.HotelId == hotelId)
                .Select(r => new RoomAdminViewModel()
                {
                    Id = r.Id,
                    RoomTypeId = r.RoomTypeId,
                    RoomTypeName = r.RoomType.Name,
                    ImgPath = r.Pictures.Where(p => !p.IsDeleted).First().Path,
                    IsDeleted = r.IsDeleted,
                    PricePerNight = r.PricePerNight
                })
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
                    CurrentRoomBasis = r.RoomBases.Where(rb => !rb.IsDeleted).Select(rb => new RoomBasisAdminViewModel() { Id = rb.RoomBasisId, Name = rb.RoomBasis.Name }).ToArray(),
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
    }
}
