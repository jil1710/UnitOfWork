using Microsoft.AspNetCore.Mvc;

namespace UnitOfWork.Handler
{
    public class ErrorHandlerController : Controller
    {
        private readonly ILogger<ErrorHandlerController> _logger;

        public ErrorHandlerController(ILogger<ErrorHandlerController> logger)
        {
            this._logger = logger;
        }

        public IActionResult NotFoundEx()
        {
            _logger.LogError("Accessing Not Found Page 404 Error");
            return View();
        }

        public IActionResult Ambiguous()
        {
            _logger.LogError($"{nameof(Ambiguous)} Page Request Occure!");
            return View();
        }
        public IActionResult BadRequestEx()
        {
            _logger.LogError($"{nameof(BadRequest)} Occure!");
            return View();
        }
        public IActionResult InternalServerError()
        {
            _logger.LogError("Internal Server Error Occure!");
            return View();
        }
        public IActionResult LoopDetected()
        {
            _logger.LogError($"{nameof(LoopDetected)} Error Occure!");
            return View();
        }
        public IActionResult UnAuthorized()
        {
            _logger.LogError("Unauthorized access occure!");
            return View();
        }
    }
}
