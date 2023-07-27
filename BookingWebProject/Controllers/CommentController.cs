namespace BookingWebProject.Controllers
{
    using Core.Models.Comment;
    using Core.Contracts;
    using Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;

    [Authorize]

    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> PostComment([FromBody] PostCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Keys
               .SelectMany(key => ModelState[key].Errors
               .Select(x => new { Key = key, Error = x.ErrorMessage }))
               .ToList();
                return Json(new { success = false, errors = errors });
            }
            try
            {
                await commentService.CreateCommentAsync(model, User.GetId(), User.Identity.Name);
                TempData[SuccessMessage] = SuccessFullyPostedComment;
                return Json(new { success = true });
            }
            catch (Exception)
            {
                TempData[WarningMessage] = DefaultErrorMessage;
                return Json(new { success = false });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await commentService.IsExist(id))
            {
                TempData[ErrorMessage] = CommentDoesNotExist;
                return Json(new { success = false });
            }
            try
            {
                await commentService.DeleteCommentAsync(id);
                TempData[SuccessMessage] = SuccessRemoveMessage;
                return Json(new { success = true });
            }
            catch (Exception)
            {
                TempData[WarningMessage] = DefaultErrorMessage;
                return Json(new { success = false });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] EditCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Keys
               .SelectMany(key => ModelState[key].Errors
               .Select(x => new { Key = key, Error = x.ErrorMessage }))
               .ToList();
                return Json(new { success = false, errors = errors });
            }
            if (!await commentService.IsExist(model.Id))
            {
                TempData[ErrorMessage] = CommentDoesNotExist;
                return Json(new { success = false });
            }
            try
            {
                await commentService.EditCommentAsync(model);
                TempData[SuccessMessage] = SuccessEditedComment;
                return Json(new { success = true });
            }
            catch (Exception)
            {
                TempData[WarningMessage] = DefaultErrorMessage;
                return Json(new { success = false });
            }
        }
    }
}
