namespace BookingWebProject.Core.Models.Pager
{
    using static Common.GeneralAplicationConstants;
    public class Pager
    {
        public Pager(int totalItems, int currentPage)
        {
            Configure(totalItems, currentPage);
        }

        private void Configure(int totalItems, int currentPage)
        {
            int totalPages = (int)Math.Ceiling((double)totalItems / PageSize);
            int startPage = Math.Max(1, currentPage - 2);
            int endPage = Math.Min(startPage + 3, totalPages);

            if (currentPage > endPage && endPage != 0)
            {
                currentPage = endPage;
                startPage = Math.Max(1, currentPage - 3);
                endPage = Math.Min(startPage + 3, totalPages);
            }

            TotalPages = totalPages;
            CurrentPage = currentPage;
            PageSize = PageSize;
            StartPage = startPage;
            EndPage = endPage;
            TotalItems = totalItems;
        }

        /// <summary>
        /// Total number of entity records
        /// </summary>
        public int TotalItems { get; private set; }
        /// <summary>
        /// The active page on page bar
        /// </summary>
        public int CurrentPage { get; private set; }
        /// <summary>
        /// The size of number of records displayed on the page
        /// </summary>
        public int PageSize { get; private set; }
        /// <summary>
        /// Total number of pages on page bar
        /// </summary>
        public int TotalPages { get; private set; }
        /// <summary>
        /// The page number which is first on page bar
        /// </summary>
        public int StartPage { get; private set; }
        /// <summary>
        ///  The page number which is last on page bar
        /// </summary>
        public int EndPage { get; private set; }
    }
}
