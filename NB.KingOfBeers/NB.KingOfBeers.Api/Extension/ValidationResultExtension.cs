using Microsoft.AspNetCore.Mvc.ModelBinding;
using FluentValidation.Results;

namespace NB.KingOfBeers.Api.Extension
{
    public static class ValidationResultExtension
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            if (result.IsValid) return;
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        public static IActionResult FluentValidationProblem(this ControllerBase controller, ValidationResult result)
        {
            result.AddToModelState(controller.ModelState);

            return controller.ValidationProblem();
        }
    }
}
