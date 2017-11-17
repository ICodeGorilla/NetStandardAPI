using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace NTests
{
    public static class ActionResultExtension
    {
        public static async Task<T> GetOkObjectResult<T>(this Task<IActionResult> task)
        {
            var actionResult = await task;
            Assert.That(actionResult, Is.TypeOf(typeof(OkObjectResult)), "The request was not OK as expected.");
            var okResult = (OkObjectResult)actionResult;
            return (T)okResult.Value;
        }

        public static void CheckBadRequest(this Task<IActionResult> task)
        {
            CheckResult<BadRequestResult>(task);
        }

        public static void CheckNoContent(this Task<IActionResult> task)
        {
            CheckResult<NoContentResult>(task);
        }

        public static void CheckNotFound(this Task<IActionResult> task)
        {
            CheckResult<NotFoundResult>(task);
        }

        public static void CheckOkResult(this Task<IActionResult> task)
        {
            CheckResult<OkResult>(task);
        }

        private static async void CheckResult<T>(Task<IActionResult> task)
        {
            var actionResult = await task;
            AssertResult<T>(actionResult);
        }

        private static void AssertResult<T>(IActionResult actionResult)
        {
            Assert.That(actionResult, Is.TypeOf(typeof(T)), $"The request was not a {typeof(T).FullName} as expected.");
        }

    }
}
