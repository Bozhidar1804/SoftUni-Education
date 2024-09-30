using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsGuidValid(string? id, ref Guid cinemaGuid)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            bool isGuidValid = Guid.TryParse(id, out cinemaGuid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }
    }
}
