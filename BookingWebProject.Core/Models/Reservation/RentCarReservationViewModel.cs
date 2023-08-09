namespace BookingWebProject.Core.Models.Reservation
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using RentCar;
    using User;
    public class RentCarReservationViewModel : IValidatableObject
    {
        public UserViewModel User { get; set; } = null!;
        public CarViewModel CarlViewModel { get; set; } = null!;
        public DateTime StartRentDate { get; set; }
        public DateTime EndRentDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartRentDate >= EndRentDate)
            {
                yield return new ValidationResult("Start Rent Date must be before End Rent Date",
                    new[] { nameof(StartRentDate), nameof(EndRentDate) });
            }
        }
    }
}
