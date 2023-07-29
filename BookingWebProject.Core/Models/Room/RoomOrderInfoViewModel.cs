
namespace BookingWebProject.Core.Models.Room
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Picture;
    using RoomPackage;
    using RoomBasis;

    public class RoomOrderInfoViewModel
    {
        public RoomOrderInfoViewModel()
        {
            RoomBases = new List<RoomBasisViewModel>();
            Packages = new List<RoomPackageViewModel>();
            RoomPictures = new List<PictureViewModel>();
        }
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public int HotelId { get; init; }
        public string? Description { get; init; }
        public decimal Price { get; set; }
        public int RoomCapacity { get; set; }
        [Display(Name = "Children Count")]
        public int ChildrenCount { get; set; }
        [Display(Name = "Adults Count")]
        public int AdultsCount { get; set; }
        public IEnumerable<RoomBasisViewModel> RoomBases { get; set; }
        public int PackageId { get; set; }
        public IEnumerable<RoomPackageViewModel> Packages { get; set; }
        public IEnumerable<PictureViewModel> RoomPictures { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (AdultsCount <= 0)
            {
                yield return new ValidationResult("There must be at least one adult",
                   new[] { nameof(AdultsCount) });
            }
            if (ChildrenCount < 0)
            {
                yield return new ValidationResult("Children count can not be less than zero",
                  new[] { nameof(AdultsCount) });
            }
            if (AdultsCount + ChildrenCount > RoomCapacity)
            {
                yield return new ValidationResult("Room capacity is not enough. Please search for another room", new[] { nameof(AdultsCount), nameof(ChildrenCount) });
            }
        }
    }
}
