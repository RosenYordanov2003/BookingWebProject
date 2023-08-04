namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Infrastructure.Data.Models;
    using Core.Models.Benefits;
    using Contracts;
    using Models.Hotel;
    using Models.Picture;
    using Data;
    using Core.Models.Pager;

    public class HotelAdminService : IHotelAdminService
    {
        private readonly BookingContext bookingContext;
        private readonly IWebHostEnvironment env;
        public HotelAdminService(BookingContext bookingContext, IWebHostEnvironment env)
        {
            this.bookingContext = bookingContext;
            this.env = env;
        }

        public async Task<IEnumerable<HotelAllViewModel>> GetAllHotelsAsync(Pager pager)
        {
            IEnumerable<HotelAllViewModel> allHotels = await bookingContext.Hotels
                .OrderBy(h => h.IsDeleted)
                .Select(h => new HotelAllViewModel()
                {
                    Id = h.Id,
                    HotelName = h.Name,
                    StarsCount = h.StarRating,
                    IsDeleted = h.IsDeleted,
                    ImgPath = h.Pictures.First().Path

                })
                .Skip((pager.CurrentPage - 1) * pager.PageSize)
                .Take(pager.PageSize)
                .ToArrayAsync();

            return allHotels;
        }
        public async Task<bool> CheckIfHotelIsAlredyDeletedAsync(int hotelId)
        {
            return await bookingContext.Hotels
                 .AnyAsync(h => h.Id == hotelId && h.IsDeleted);
        }

        public async Task DeleteHotelByIdAsync(int hotelId)
        {
            Hotel hotelToDelete = await bookingContext.Hotels
                 .FirstAsync(h => h.Id == hotelId);
            hotelToDelete.IsDeleted = true;

            await bookingContext.SaveChangesAsync();
        }

        public async Task RecoverHotelByIdAsync(int hotelId)
        {
            Hotel hotelToRecover = await FindHotelByIdAsync(hotelId);
            hotelToRecover.IsDeleted = false;

            await bookingContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIsHotelForRecoverExistByIdAsync(int hotelId)
        {
            return await bookingContext.Hotels
                .AnyAsync(h => h.IsDeleted && h.Id == hotelId);
        }

        public async Task<EditHotelViewModel> GetHotelToEditAsync(int hotelId)
        {
            EditHotelViewModel editHotelViewModel = await bookingContext.Hotels
                 .Where(h => h.Id == hotelId)
                 .Select(h => new EditHotelViewModel()
                 {
                     Id = h.Id,
                     StarRating = h.StarRating,
                     City = h.City,
                     Country = h.Country,
                     Description = h.Description,
                     HotelName = h.Name,
                     Longitude = h.Longitude,
                     Latitude = h.Latitude,
                     Pictures = h.Pictures.Select(p => new PictureAdminViewModel()
                     {
                         Id = p.Id,
                         Path = p.Path,
                         IsDeleted = p.IsDeleted,
                     })
                     .ToArray(),
                     CurrentHotelBenefits = h.HotelBenefits.Where(hb => !hb.IsDeleted).Select(hb => new BenefitViewModel()
                     {
                         Id = hb.BenefitId,
                         BenefitIcon = hb.Benefit.ClassIcon,
                         Name = hb.Benefit.Name,
                         IsDeleted = hb.IsDeleted,

                     })
                 })
                 .FirstAsync();

            return editHotelViewModel;
        }

        public async Task EditHotelByIdAsync(int hotelId, EditHotelViewModel editHotelViewModel)
        {
            Hotel hotelToEdit = await FindHotelByIdAsync(hotelId);
            hotelToEdit.Name = editHotelViewModel.HotelName;
            hotelToEdit.StarRating = editHotelViewModel.StarRating;
            hotelToEdit.City = editHotelViewModel.City;
            hotelToEdit.Country = editHotelViewModel.Country;
            hotelToEdit.Description = editHotelViewModel.Description;
            hotelToEdit.Longitude = editHotelViewModel.Longitude;
            hotelToEdit.Latitude = editHotelViewModel.Latitude;

            if (editHotelViewModel.SelectedBenefitIds.Any())
            {
                await AddHotelBenefitsToHotelAsync(hotelId, editHotelViewModel.SelectedBenefitIds);
            }
            if (!string.IsNullOrWhiteSpace(editHotelViewModel.ImgUrl))
            {
                await bookingContext.Pictures.AddAsync(new Picture() { HotelId = editHotelViewModel.Id, Path = editHotelViewModel.ImgUrl });
                await bookingContext.SaveChangesAsync();
            }
            await bookingContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIsHotelBenefitExistAsync(int benefitId, int hotelId)
        {
            return await bookingContext.HotelBenefits
                 .AnyAsync(hb => hb.HotelId == hotelId && hb.BenefitId == benefitId);
        }

        public async Task<bool> CheckIsHotelBenefitIsAlreadyDeletedAsync(int benefitId, int hotelId)
        {
            return await bookingContext.HotelBenefits
                  .AnyAsync(hb => hb.HotelId == hotelId && hb.BenefitId == benefitId && !hb.IsDeleted);
        }

        public async Task DeleteHotelBenefitAsync(int benefitId, int hotelId)
        {
            HotelBenefits hotelBenefit = await bookingContext.HotelBenefits
                 .FirstAsync(hb => hb.HotelId == hotelId && hb.BenefitId == benefitId);

            hotelBenefit.IsDeleted = true;
            await bookingContext.SaveChangesAsync();
        }

        public async Task CreateHotelAsync(CreateHotelViewModel createHotelViewModel)
        {
            Hotel hotel = new Hotel()
            {
                Name = createHotelViewModel.Name,
                Country = createHotelViewModel.Country,
                Longitude = createHotelViewModel.Longitude,
                Latitude = createHotelViewModel.Latitude,
                IsDeleted = false,
                City = createHotelViewModel.City,
                Description = createHotelViewModel.Description,
                StarRating = createHotelViewModel.StarRating,
            };

            await bookingContext.Hotels.AddAsync(hotel);
            await bookingContext.SaveChangesAsync();

            if (createHotelViewModel.SelectedBenefitIds.Any())
            {
                Hotel hotelToFind = await bookingContext.Hotels.FirstAsync(h => h.Name == createHotelViewModel.Name && !h.IsDeleted);
                await AddHotelBenefitsToHotelAsync(hotelToFind.Id, createHotelViewModel.SelectedBenefitIds);
            }
        }
        public async Task CreateHotelImgsAsync(CreateHotelViewModel hotelViewModel)
        {
            string hotelFolderName = hotelViewModel.Name;
            Hotel hotelToFind = await bookingContext.Hotels.FirstAsync(h => h.Name == hotelViewModel.Name && !h.IsDeleted);
            string uploadPath = Path.Combine(env.WebRootPath, "img", "Hotels", hotelFolderName);
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            foreach (var file in hotelViewModel.PicturesFileProvider!)
            {
                if (file.Length > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(uploadPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await bookingContext.Pictures.AddAsync(new Picture() { Path = $"/img/Hotels/{hotelFolderName}/{fileName}", HotelId = hotelToFind.Id });
                        await bookingContext.SaveChangesAsync();
                        await file.CopyToAsync(stream);
                    }
                }
            }
        }
        private async Task AddHotelBenefitsToHotelAsync(int hotelId, IEnumerable<int> benefitIds)
        {
            foreach (int benefitId in benefitIds)
            {
                if (await CheckIsHotelBenefitExistAsync(benefitId, hotelId))
                {
                    await RecoverHotelBenefitAsync(benefitId, hotelId);
                }
                else
                {
                    await bookingContext.HotelBenefits.AddAsync(new HotelBenefits() { HotelId = hotelId, BenefitId = benefitId });
                    await bookingContext.SaveChangesAsync();
                }
            }
        }
        private async Task<Hotel> FindHotelByIdAsync(int hotelId)
        {
            Hotel hotelToEdit = await bookingContext.Hotels
               .FirstAsync(h => h.Id == hotelId);

            return hotelToEdit;
        }
        private async Task RecoverHotelBenefitAsync(int benefitId, int hotelId)
        {
            HotelBenefits hotelBenefit = await bookingContext.HotelBenefits
                 .FirstAsync(hb => hb.HotelId == hotelId && hb.BenefitId == benefitId);

            hotelBenefit.IsDeleted = false;
            await bookingContext.SaveChangesAsync();
        }

        public async Task<int> GetAllHotelsCountAsync()
        {
            return await bookingContext.Hotels.CountAsync();
        }
    }
}
