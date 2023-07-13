namespace BookingWebProject.Infrastructure.Data.Configurations
{
    using BookingWebProject.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    public class HotelBenefitsConfiguration : IEntityTypeConfiguration<HotelBenefits>
    {
        public void Configure(EntityTypeBuilder<HotelBenefits> builder)
        {
            builder.HasKey(ck => new { ck.HotelId, ck.BenefitId });
            builder.HasOne(hb => hb.Benefit).WithMany(b => b.HotelBenefits).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(hb => hb.Hotel).WithMany(h => h.HotelBenefits).OnDelete(DeleteBehavior.NoAction);
            ICollection<HotelBenefits> hotelBenefits = CreateHotelBenefits();
            builder.HasData(hotelBenefits);
        }

        private ICollection<HotelBenefits> CreateHotelBenefits()
        {
            List<HotelBenefits> hotelBenefits = new List<HotelBenefits>();
            hotelBenefits.AddRange(AddBenefitsToHotel(1, new int[] { 2, 4, 6, 7, 5, 8 }));
            hotelBenefits.AddRange(AddBenefitsToHotel(2, new int[] { 2, 4, 6, 7, 5, 8 }));
            hotelBenefits.AddRange(AddBenefitsToHotel(3, new int[] { 2, 6, 7, 5, 8 }));
            hotelBenefits.AddRange(AddBenefitsToHotel(4, new int[] { 1, 4, 6, 5, 8 }));
            hotelBenefits.AddRange(AddBenefitsToHotel(5, new int[] { 5, 3, 4, 6, 7, 8 }));
            hotelBenefits.AddRange(AddBenefitsToHotel(6, new int[] { 2, 3, 4, 5, 6, 7, 8 }));
            return hotelBenefits;

        }
        private ICollection<HotelBenefits> AddBenefitsToHotel(int hotelId, int[] benefitIds)
        {
            List<HotelBenefits> hotelBenefits = new List<HotelBenefits>();

            foreach (int benefitId in benefitIds)
            {
                HotelBenefits hotelBenefit = new HotelBenefits() { HotelId = hotelId, BenefitId = benefitId };
                hotelBenefits.Add(hotelBenefit);
            }
            return hotelBenefits;
        }
    }
}
