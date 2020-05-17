using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        public ObjectResult Errors(ModelStateDictionary modelState)
        {
            var query = from state in modelState.Values
                        from error in state.Errors
                        select error.ErrorMessage;
            var errorList = query.ToList();
            return BadRequest(new { Errors = errorList });
        }

        public ObjectResult Errors(IList<string> errors)
        {
            IList<string> allErrors = errors;
            return BadRequest(new { Errors = allErrors });
        }

        public ActionResult NoDataFound()
        {
            return NoContent();
        }

        public ActionResult Successful(object value)
        {
            return Ok(new { Result = value });
        }

    }
}