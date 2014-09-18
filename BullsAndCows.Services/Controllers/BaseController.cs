namespace BullsAndCows.Services.Controllers
{
    using BullsAndCows.Data;
    using System.Web.Http;

    [Authorize]
    public abstract class BaseController : ApiController
    {
        protected IBullsAndCowsData data;

        protected BaseController(IBullsAndCowsData data)
        {
            this.data = data;
        }
    }
}
