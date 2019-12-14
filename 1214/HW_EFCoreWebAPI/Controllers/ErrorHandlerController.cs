using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HW_EFCoreWebAPI.Controllers
{
    /** Class-1214: 練習透過萬用的錯誤 API 回應非預期的例外結果 */
    [ApiController]
    public class ErrorHandlerController : ControllerBase
    {
        // ASP.NWT Core 2.x 以前
        [Route("/error")]
        public ActionResult Error([FromBody]IHostEnvironment webHostEnvironment)
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;    // 避免沒使用handler時產生空值錯誤
            var isDev = webHostEnvironment.IsDevelopment();
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = feature.Path,
                Title = isDev ? $"{ex.GetType().Name}: {ex.Message}" : "An error occured.",
                Detail = isDev ? ex.StackTrace : null
            };
            return StatusCode(problemDetails.Status.Value, problemDetails);
        }
        // ASP.NWT Core 3.0 之後
        [Route("/error2")]
        public IActionResult Error() => Problem();
    }
}