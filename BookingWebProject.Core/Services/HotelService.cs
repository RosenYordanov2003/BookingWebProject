namespace BookingWebProject.Core.Services
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Models.Picture;
    using Contracts;
    using Models.Hotel;
    using Data;
    using Infrastructure.Data.Models;
    using Models.Hotel.Enums;
    using BookingWebProject.Core.Models.Pager;
    using BookingWebProject.Core.Models.Benefits;
    using BookingWebProject.Core.Models.Comment;
    using BookingWebProject.Core.Models.Room;

    public class HotelService : IHotelService
    {
        private readonly BookingContext bookingContext;
        public HotelService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }


        public async Task<AllHotelsSortedAndFilteredDataModel> GetAllHotelsSortedAndFilteredAsync(Guid userId, HotelQueryViewModel hotelQueryViewModel)
        {
            IQueryable<Hotel> hotels = bookingContext.Hotels.Where(h => !h.IsDeleted).AsQueryable();
            hotels = SortAndFilterHotels(hotelQueryViewModel, hotels);
            int recordsToSkip = (hotelQueryViewModel.Pager.CurrentPage - 1) * hotelQueryViewModel.Pager.PageSize;
            IEnumerable<HotelViewModel> allHotels = await hotels.Skip(recordsToSkip)
                .Take(hotelQueryViewModel.Pager.PageSize)
                  .Select(h => new HotelViewModel()
                  {
                      Id = h.Id,
                      Name = h.Name,
                      StarRating = h.StarRating,
                      City = h.City,
                      Country = h.Country,
                      PicturePath = h.Pictures.Where(p => !p.IsDeleted).FirstOrDefault().Path,
                      IsFavorite = h.FavoriteHotels.Any(fv => fv.HotelId == h.Id && fv.UserId == userId),
                      CheapestHotelRoomViewModel = h.Rooms
                     .Where(r => !r.IsDeleted && !r.RoomType.IsDeleted)
                     .Select(r => new CheapestHotelRoomViewModel() { Id = r.Id, PricePerNight = r.PricePerNight })
                     .OrderBy(r => r.PricePerNight)
                     .FirstOrDefault()
                  }).ToArrayAsync();
            return new AllHotelsSortedAndFilteredDataModel()
            {
                Hotels = allHotels
            };
        }

        public Task<int> GetCountAsync(HotelQueryViewModel hotelQueryViewModel)
        {
            IQueryable<Hotel> allHotels = bookingContext.Hotels.Where(h => !h.IsDeleted).AsQueryable();
            allHotels = SortAndFilterHotels(hotelQueryViewModel, allHotels);
            return allHotels.CountAsync();
        }
        public async Task<IEnumerable<string>> GetAllHotelCitiesAsync()
        {
            IEnumerable<string> hotelCities = await bookingContext
                .Hotels
                .Where(h => !h.IsDeleted)
                .Select(h => h.City)
                .Distinct()
                .ToArrayAsync();
            return hotelCities;
        }

        public async Task<IEnumerable<string>> GetAllHotelCountriesAsync()
        {
            IEnumerable<string> hotelCountries = await bookingContext
                  .Hotels
                  .Where(h => !h.IsDeleted)
                  .Select(h => h.Country)
                  .Distinct()
                  .ToArrayAsync();
            return hotelCountries;
        }

        public async Task<IEnumerable<HotelCardViewModel>> GetTopHotelsAsync()
        {
            IEnumerable<HotelCardViewModel> hotels = await bookingContext.Hotels.
                Include(h => h.Reservations).
                 OrderByDescending(h => h.Reservations.Count)
                .ThenByDescending(h => h.StarRating)
                .Where(h => !h.IsDeleted)
                .Select(h => new HotelCardViewModel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Country = h.Country,
                    City = h.City,
                    Stars = h.StarRating,
                    Pictures = h.Pictures.Where(p => !p.IsDeleted).Select(p => new PictureViewModel()
                    {
                        Path = p.Path,
                    })
                    .ToList()
                })

                 .Take(4)
                 .ToListAsync();

            return hotels;
        }
        public async Task<bool> CheckIsHotelExistAsync(int hotelId)
        {
            return await bookingContext.Hotels
                  .AnyAsync(h => h.Id == hotelId && !h.IsDeleted);
        }

        public async Task AddHotelToUserFavoriteHotels(int hotelId, Guid userId)
        {
            FavoriteHotels favoriteHotel = new FavoriteHotels()
            {
                HotelId = hotelId,
                UserId = userId
            };
            await bookingContext.FavoriteHotels.AddAsync(favoriteHotel);
            await bookingContext.SaveChangesAsync();
        }

        public async Task RemoveHotelFromUserFavoriteHotels(int hotelId, Guid userId)
        {
            FavoriteHotels favoriteHotelToRemove = await bookingContext
                .FavoriteHotels.FirstAsync(fh => fh.UserId == userId && fh.HotelId == hotelId);
            bookingContext.FavoriteHotels.Remove(favoriteHotelToRemove);

            await bookingContext.SaveChangesAsync();
        }
        public async Task<HotelInfoViewModel> GetHotelByIdAsync(int hotelId, Pager pager)
        {
            int recordsToSkip = (pager.CurrentPage - 1) * pager.PageSize;
            HotelInfoViewModel hotel = await bookingContext
                 .Hotels
                 .Select(h => new HotelInfoViewModel()
                 {
                     Id = h.Id,
                     City = h.City,
                     Country = h.Country,
                     Name = h.Name,
                     Description = h.Description,
                     StarRating = h.StarRating,
                     Latitude = h.Latitude,
                     Longitude = h.Longitude,
                     Benefits = h.HotelBenefits.Where(hb => hb.HotelId == hotelId && !hb.IsDeleted && !hb.Benefit.IsDeleted).Select(b => new BenefitViewModel()
                     {
                         Name = b.Benefit.Name,
                         BenefitIcon = b.Benefit.ClassIcon
                     }).ToArray(),
                     Pictures = h.Pictures.Where(p => !p.IsDeleted).Select(p => new PictureViewModel() { Path = p.Path }).ToArray(),
                     Comments = h.Comments.Where(c => !c.IsDeleted).Select(c => new CommentViewModel()
                     {
                         Id = c.Id,
                         CreatedOn = c.CreatedDate,
                         Description = c.Description,
                         UserName = c.UserName,
                         UserId = c.UserId,
                         UserPicturePath = c.User.ProfilePicturePath

                     }).
                     Skip(recordsToSkip)
                    .Take(pager.PageSize)
                 })
                 .FirstAsync(h => h.Id == hotelId);
            return hotel;
        }
        public async Task<int> GetHotelCommentsCountAsync(int hotelId)
        {
            return await bookingContext.Comments
                .Where(c => c.HotelId == hotelId && !c.IsDeleted)
                .CountAsync();
        }
        private IQueryable<Hotel> SortAndFilterHotels(HotelQueryViewModel hotelQueryViewModel, IQueryable<Hotel> hotels)
        {
            if (hotelQueryViewModel.MinStarsCountFilter.HasValue)
            {
                hotels = hotels.Where(h => h.StarRating >= hotelQueryViewModel.MinStarsCountFilter);
            }
            if (hotelQueryViewModel.MaxStarsCountFilter.HasValue)
            {
                hotels = hotels.Where(h => h.StarRating <= hotelQueryViewModel.MaxStarsCountFilter);
            }
            if (!string.IsNullOrWhiteSpace(hotelQueryViewModel.City) && hotelQueryViewModel.City != "all")
            {
                hotels = hotels.Where(h => h.City == hotelQueryViewModel.City);
            }
            if (!string.IsNullOrWhiteSpace(hotelQueryViewModel.Country) && hotelQueryViewModel.Country != "all")
            {
                hotels = hotels.Where(h => h.Country == hotelQueryViewModel.Country);
            }
            if (hotelQueryViewModel.SelectedBenefitIds.Any())
            {
                foreach (var selectedBenefitId in hotelQueryViewModel.SelectedBenefitIds)
                {
                    hotels = hotels.Where(h => h.HotelBenefits.Any(hb => hb.BenefitId == selectedBenefitId));
                }
            }


            if (hotelQueryViewModel.HotelSortOption == HotelSortOption.ByStarRatingAscending)
            {
                hotels = hotels.OrderBy(h => h.StarRating);
            }
            else if (hotelQueryViewModel.HotelSortOption == HotelSortOption.ByStarRatingDescending)
            {
                hotels = hotels.OrderByDescending(h => h.StarRating);
            }
            else if (hotelQueryViewModel.HotelSortOption == HotelSortOption.ByCountryAscending)
            {
                hotels = hotels.OrderBy(h => h.Country);
            }
            else if (hotelQueryViewModel.HotelSortOption == HotelSortOption.ByCountryDescending)
            {
                hotels = hotels.OrderByDescending(h => h.Country);
            }
            else if (hotelQueryViewModel.HotelSortOption == HotelSortOption.ByCityAscending)
            {
                hotels = hotels.OrderBy(h => h.City);
            }
            else if (hotelQueryViewModel.HotelSortOption == HotelSortOption.ByCityDescending)
            {
                hotels = hotels.OrderByDescending(h => h.City);
            }
            else
            {
                hotels = hotels.OrderBy(h => h.Id);
            }

            return hotels;
        }
    }
}
