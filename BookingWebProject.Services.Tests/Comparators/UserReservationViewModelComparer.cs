namespace BookingWebProject.Services.Tests.Comparators
{
    using System.Collections;
    using Core.Models.Reservation;
    public class UserReservationViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            UserReservationViewModel userReservation1 = (UserReservationViewModel)x;
            UserReservationViewModel userReservation2 = (UserReservationViewModel)y;

            if (userReservation1 == null || userReservation2 == null)
            {
                return -1;
            }
            if (userReservation1.Id != userReservation2.Id  || userReservation1.StartDate != userReservation2.StartDate 
                || userReservation1.EndDate != userReservation2.EndDate || userReservation1.Price != userReservation2.Price)
            {
                return -1;
            }
            return 0; ;
        }
    }
}
