﻿namespace BookingWebProject.Core.Contracts
{
    using Models.Hotel;
    public interface IHotelService
    {
        Task<IEnumerable<HotelCardViewModel>> GetTopHotelsAsync();
    }
}