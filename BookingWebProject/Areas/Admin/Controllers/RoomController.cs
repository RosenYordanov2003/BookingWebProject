﻿namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Room;
    using Contracts;
    using Models.Room.DataModels;
    using Core.Models.Pager;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;

    public class RoomController : BaseAdminController
    {
        private readonly IRoomAdminService roomAdminService;
        private readonly IRoomBasisAdminService roomBasisAdminService;
        private readonly IHotelAdminService hotelService;
        public RoomController(IRoomAdminService roomAdminService, IRoomBasisAdminService roomBasisAdminService,
            IHotelAdminService hotelService)
        {
            this.roomAdminService = roomAdminService;
            this.roomBasisAdminService = roomBasisAdminService;
            this.hotelService = hotelService;
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
                roomToEdit.RoomTypeId = roomTypeId;
                roomToEdit.HotelId = hotelId;
                return View(roomToEdit);

            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int roomTypeId, int hotelId, EditRoomViewModel editRoomViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editRoomViewModel);
            }
            try
            {
                if (!await roomAdminService.IsRoomByGivenTypeExistsInHotel(hotelId, roomTypeId))
                {
                    return NotFound();
                }
                await roomAdminService.UpdateRoomsInHotelByRoomTypeIdAsync(roomTypeId, hotelId, editRoomViewModel);
                TempData[SuccessMessage] = SuccessfullyUpdateRoomsInHotel;

                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> RemoveRoomBasis(int roomBasisId, int hotelId, int roomTypeId)
        {
            try
            {
                if (!await roomBasisAdminService.IsRoomBasisExist(hotelId, roomTypeId, roomBasisId))
                {
                    return NotFound();
                }
                await roomBasisAdminService.RemoveRoomBasisFromRoomsInHotelByGivenRoomTypeAsync(hotelId, roomTypeId, roomBasisId);
                TempData[SuccessMessage] = SuccessfullyRemoveRoomBases;

                return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });
            }
            catch (Exception)
            {

                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(int hotelId, int roomTypeId)
        {
            try
            {
                if (!await roomAdminService.IsRoomByGivenTypeExistsInHotel(hotelId, roomTypeId))
                {
                    return NotFound();
                }
                await roomAdminService.AddRoomByGivenRoomTypeInHotelAsync(hotelId, roomTypeId);
                TempData[SuccessMessage] = SuccessfullyAddRoomByGivenRoomTypeInHotel;

                return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpGet]
        public async Task<IActionResult> AllRoomsInHotel(int Id, int pg = 1)
        {
            if (pg <= 0)
            {
                pg = 1;
            }
            try
            {
                if (!await hotelService.CheckIsHotelExistAsync(Id))
                {
                    return NotFound();
                }
                int totalHotelRoomsCount = await roomAdminService.GetHotelRoomsCountAsync(Id);
                Pager pager = new Pager(totalHotelRoomsCount, pg);
                RoomHotelsDataModel roomHotelsDataModel = new RoomHotelsDataModel()
                {
                    Rooms = await roomAdminService.GetHotelRoomsByHotelIdAsync(Id, pager),
                    Pager = pager
                };
                return View(roomHotelsDataModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Delete(int roomId)
        {
            try
            {
                if (!await roomAdminService.CheckIsRoomExistByIdAsync(roomId))
                {
                    return NotFound();
                }
                if (await roomAdminService.CheckIfRoomIsAlreadyDeletedByGivenIdAsync(roomId))
                {
                    TempData[WarningMessage] = RoomIsAlreadyDeleted;
                }
                await roomAdminService.DeleteRoomByIdAsync(roomId);
                TempData[SuccessMessage] = SuccessfullyDeleteRoom;
                return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
