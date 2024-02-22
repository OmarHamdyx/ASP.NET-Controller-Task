using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Controller_Task.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [HttpGet("/")]

        public IActionResult HomePage()
        {
            Response.StatusCode = 200;
            return Content("<h1>Welcome to the Best Bank</h1>", "text/html");
        }

        [HttpGet("/account-details")]
        public IActionResult DisplayAccountDetails()
        {
            Response.StatusCode = 200;
            return Json(new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 });
        }
        [HttpGet("/account-statement")]
        public IActionResult DisplayAccountStatement()
        {
            Response.StatusCode = 200;
            return File("/sample.pdf", "application/pdf");

        }
        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult DisplayCurrentBalance()
        {
            if (!Request.RouteValues.ContainsKey("accountNumber"))
            {
                return NotFound("Account Number should be supplied");
            }

            int accountNumber = Convert.ToInt16(Request.RouteValues["accountNumber"]);

            if (accountNumber == 1001)
            {
                Response.StatusCode = 200;
                return Content("5000");
            }
            return BadRequest("Account Number should be 1001");
        }

    }

}

