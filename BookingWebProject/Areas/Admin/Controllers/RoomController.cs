namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Room;
    using Contracts;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    public class RoomController : BaseAdminController
    {
        private readonly IRoomAdminService roomAdminService;
        private readonly IRoomBasisAdminService roomBasisAdminService;
        public RoomController(IRoomAdminService roomAdminService, IRoomBasisAdminService roomBasisAdminService)
        {
            this.roomAdminService = roomAdminService;
            this.roomBasisAdminService = roomBasisAdminService;
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int roomTypeId, int hotelId)
        {
            try
            {
                if (!await roomAdminService.IsRoomByGivenTypeExistsInHotel(hotelId, roomTypeId))
                {
                    return NotFound();
                }
                EditRoomViewModel roomToEdit = await roomAdminService.GetRoomToEditAsync(roomTypeId, hotelId);
                roomToEdit.OtherRoomBasis = await roomBasisAdminService.GetOtherRoomBasisAsync(hotelId, roomTypeId);
                return View(roomToEdit);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
    }
}
