namespace BookingWebProject.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.Room;
    using BookingWebProject.Core.Models.Picture;
    using BookingWebProject.Core.Models.RoomBasis;
    using BookingWebProject.Core.Models.RoomPackage;

    public class RoomService : IRoomService
    {
        private readonly BookingContext bookingContext;
        public RoomService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<RoomViewModel>> GetHotelRooms(int hotelId)
        {
            var hotelRooms = await bookingContext.Rooms
                  .Where(r => r.HotelId == hotelId)
                  .Select(r => new RoomViewModel()
                  {
                      Id = r.Id,
                      PricePerNight = r.PricePerNight,
                      Description = r.Description,
                      RoomCapacity = r.Capacity,
                      RoomType = r.RoomType.Name,
                      HotelName = r.Hotel.Name,
                      RoomPictures = r.Pictures.Select(p => new Models.Picture.PictureViewModel() { Path = p.Path }).ToArray()
                  })
                  .ToArrayAsync();
            return hotelRooms;
        }


        public async Task<bool> IsRoomExistAsync(int roomId)
        {
            return await bookingContext.Rooms.AnyAsync(r => r.Id == roomId && !r.IsDeleted);
        }
        public async Task<RoomOrderInfoViewModel> GetORderRoomInfoAsync(int roomId)
        {
            RoomOrderInfoViewModel roomOrderInfoViewModel = await bookingContext.Rooms
                 .Select(r => new RoomOrderInfoViewModel()
                 {
                     Id = r.Id,
                     HotelId = r.HotelId,
                     Description = r.Description,
                     Name = r.RoomType.Name,
                     RoomCapacity = r.Capacity,
                     Price = r.PricePerNight,
                     RoomPictures = r.Pictures.Select(p => new PictureViewModel() { Path = p.Path }).ToArray(),
                     RoomBases = r.RoomBases.Select(rb => new RoomBasisViewModel() { Id = rb.RoomBasis.Id, Name = rb.RoomBasis.Name }).ToArray()
                 })
                 .FirstAsync(r => r.Id == roomId);
            return roomOrderInfoViewModel;
        }
        public async Task<BookRoomViewModel> GetRoomToBookAsync(RoomOrderInfoViewModel roomOrderInfoViewModel, RoomPackageViewModel package)
        {
            BookRoomViewModel roomToBook = new BookRoomViewModel()
            {
                AdultsCount = roomOrderInfoViewModel.AdultsCount,
                ChildrenCount = roomOrderInfoViewModel.ChildrenCount,
                HotelId = roomOrderInfoViewModel.HotelId,
                Name = roomOrderInfoViewModel.Name,
                SelectedPackage = package
            };
            decimal childrenPrice = roomOrderInfoViewModel.ChildrenCount > 0 ? (roomOrderInfoViewModel.Price - (roomOrderInfoViewModel.Price * 60 / 100)) * roomOrderInfoViewModel.ChildrenCount : 0;
            roomToBook.Price = (roomOrderInfoViewModel.Price * roomOrderInfoViewModel.AdultsCount) + childrenPrice;

            roomToBook.RoomPicture = await bookingContext.Pictures
                .Where(p => p.RoomId == roomOrderInfoViewModel.Id)
                .Select(p => new PictureViewModel()
                {
                    Path = p.Path
                })
                .FirstAsync();

            return roomToBook;
        }
    }
}
