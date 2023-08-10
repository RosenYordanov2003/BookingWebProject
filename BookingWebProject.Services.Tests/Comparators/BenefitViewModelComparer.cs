namespace BookingWebProject.Services.Tests.Comparators
{
    using System.Collections;
    using Core.Models.Benefits;
    internal class BenefitViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            BenefitViewModel benefit1 = (BenefitViewModel)x;
            BenefitViewModel benefit2 = (BenefitViewModel)y;

            if (benefit1 == null || benefit2 == null)
            {
                return -1;
            }
            if (benefit1.Id != benefit2.Id || benefit1.Name != benefit2.Name
                || benefit1.BenefitIcon != benefit2.BenefitIcon)
            {
                return -1;
            }
            return 0;
        }
    }
}
