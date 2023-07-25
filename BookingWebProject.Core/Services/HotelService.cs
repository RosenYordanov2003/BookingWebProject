namespace BookingWebProject.Core.Services
{
    using Models.Picture;
    using Contracts;
    using Models.Hotel;
    using BookingWebProject.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using BookingWebProject.Infrastructure.Data.Models;
    using BookingWebProject.Core.Models.Hotel.Enums;

    public class HotelService : IHotelService
    {
        private readonly BookingContext bookingContext;
        public HotelService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }


        public async Task<AllHotelsSortedAndFilteredDataModel> GetAllHotelsSortedAndFilteredAsync(Guid userId, HotelQueryViewModel hotelQueryViewModel)
        {
            IQueryable<Hotel> hotels = bookingContext.Hotels.AsQueryable();
            hotels = SortAndFilterHotels(hotelQueryViewModel, hotels);
            int recordsToSkip = (hotelQueryViewModel.Pager.CurrentPage - 1) * hotelQueryViewModel.Pager.PageSize;
            IEnumerable<HotelViewModel> allHotels = await hotels.Skip(recordsToSkip)
                .Take(hotelQueryViewModel.Pager.PageSize)
                  .Where(h => !h.IsDeleted)
                  .Select(h => new HotelViewModel()
                  {
                      Id = h.Id,
                      Name = h.Name,
                      StarRating = h.StarRating,
                      City = h.City,
                      Country = h.Country,
                      PicturePath = h.Pictures.First().Path,
                      IsFavorite = h.FavoriteHotels.Any(fv => fv.HotelId == h.Id && fv.UserId == userId),
                  })
                  .ToArrayAsync();
            return new AllHotelsSortedAndFilteredDataModel()
            {
                Hotels = allHotels
            };
        }

        public Task<int> GetCountAsync(HotelQueryViewModel hotelQueryViewModel)
        {
            IQueryable<Hotel> allHotels = bookingContext.Hotels.AsQueryable();
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
                    Pictures = h.Pictures.Select(p => new PictureViewModel()
                    {
                        Path = p.Path,
                    }).ToList()
                })

                 .Take(4)
                 .ToListAsync();

            return hotels;
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
                hotels = hotels.Where(h => h.HotelBenefits.Any(hb => hotelQueryViewModel.SelectedBenefitIds.Contains(hb.BenefitId)));
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
