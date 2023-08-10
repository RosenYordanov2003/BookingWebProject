namespace BookingWebProject.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Models.Room;
    using Models.Picture;
    using Models.RoomBasis;
    using Models.RoomPackage;
    using Contracts;
    using Data;

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
                  .Where(r => r.HotelId == hotelId && !r.Hotel.IsDeleted && !r.IsDeleted && !r.RoomType.IsDeleted)
                  .Select(r => new RoomViewModel()
                  {
                      Id = r.Id,
                      PricePerNight = r.PricePerNight + (r.PricePerNight * r.RoomType.IncreasePercentage) / 100,
                      Description = r.Description,
                      RoomCapacity = r.Capacity,
                      RoomType = r.RoomType.Name,
                      HotelName = r.Hotel.Name,
                      RoomPictures = r.Pictures.Where(p => !p.IsDeleted).Select(p => new PictureViewModel() { Path = p.Path }).ToArray()
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
                     Price = r.PricePerNight + (r.PricePerNight *r.RoomType.IncreasePercentage) / 100,
                     RoomPictures = r.Pictures.Where(p => !p.IsDeleted).Select(p => new PictureViewModel() { Path = p.Path }).ToArray(),
                     RoomBases = r.RoomBases.Where(rb => !rb.IsDeleted && !rb.RoomBasis.IsDeleted).Select(rb => new RoomBasisViewModel() { Id = rb.RoomBasis.Id, Name = rb.RoomBasis.Name, ClassIcon = rb.RoomBasis.ClassIcon }).ToArray()
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
                .Where(p => p.RoomId == roomOrderInfoViewModel.Id && !p.IsDeleted)
                .Select(p => new PictureViewModel()
                {
                    Path = p.Path
                })
                .FirstOrDefaultAsync();

            return roomToBook;
        }
    }
}
