using Fourth.Mvc.Models;
using Fourth.Mvc.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Fourth.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IOptionsMonitor<WebApiOptions> _webApiOptions;

        public CustomerController(
            ILogger<CustomerController> logger,
            IOptionsMonitor<WebApiOptions> webApiOptions)
        {
            _logger = logger;
            _webApiOptions = webApiOptions;
        }

        public IActionResult List()
        {
            CustomerViewModel model = new CustomerViewModel();
            model.WebApiBaseUrl = _webApiOptions.CurrentValue.ApiBaseUrl;
            return View(model);
        }

        public IActionResult Details(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return View("Error");
            }

            var model = new CustomerDetailsViewModel();
            model.WebApiBaseUrl = _webApiOptions.CurrentValue.ApiBaseUrl;
            model.CustomerId = customerId;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
