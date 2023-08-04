namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Admin.Contracts;
    using Admin.Models.Room;
    using Data;
    using Core.Models.RoomBasis;
    using Models.Picture;
    using BookingWebProject.Infrastructure.Data.Models;

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
                    CurrentRoomBasis = r.RoomBases.Select(rb => new RoomBasisViewModel() { Id = rb.RoomBasisId, Name = rb.RoomBasis.Name }).ToArray(),
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
                        await bookingContext.RoomsBases.AddAsync(new RoomsBases() { RoomId = room.Id, RoomBasisId = roomBasisId });
                        await bookingContext.SaveChangesAsync();
                    }
                }
            }
            await bookingContext.SaveChangesAsync();
        }
    }
}
