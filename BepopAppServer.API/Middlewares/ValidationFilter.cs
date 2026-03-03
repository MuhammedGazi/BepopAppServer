using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BepopAppServer.API.Middlewares
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Controller'a gelen tüm parametreleri dön (Örn: CreateCategoryDto)
            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument is null) continue;

                // Gelen parametrenin tipini al (CreateCategoryDto)
                var argType = argument.GetType();

                // DI Container'da bu DTO için yazılmış bir IValidator<T> var mı diye sor
                var validatorType = typeof(IValidator<>).MakeGenericType(argType);
                var validator = context.HttpContext.RequestServices.GetService(validatorType) as IValidator;

                if (validator is not null)
                {
                    var validationContext = new ValidationContext<object>(argument);
                    var validationResult = await validator.ValidateAsync(validationContext);

                    if (!validationResult.IsValid)
                    {
                        // Hata varsa Servise GİTMEDEN doğrudan 400 Bad Request dön!
                        var errors = validationResult.Errors
                            .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });

                        context.Result = new BadRequestObjectResult(new { Errors = errors });
                        return; // İşlemi kes!
                    }
                }
            }
            await next();
        }
    }
}