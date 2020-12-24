namespace DefinitelyNotAForum.Web.Areas.Administration.Controllers
{
    using DefinitelyNotAForum.Common;
    using DefinitelyNotAForum.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
