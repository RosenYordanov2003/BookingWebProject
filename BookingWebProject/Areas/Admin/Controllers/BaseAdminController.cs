namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Common.GeneralAplicationConstants;
    
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName + "," + ModeratorRoleName)]
    public class BaseAdminController : Controller
    {
        
    }
}
