using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using USend.UserApi.Application.Interfaces;

namespace Usend.UserApi.WebApi.Filters
{
    public class ValidateModelFilter : ActionFilterAttribute
    {
        private readonly INotificationContext _notification;

        public ValidateModelFilter(INotificationContext notificationContext)
        {
            _notification = notificationContext;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                                    .SelectMany(v => v.Errors)
                                    .Select(v => v.ErrorMessage)
                                    .ToList();

                errors?.ForEach(error =>
                    _notification.AddNotification(error));

                context.Result = new JsonResult(_notification.Notifications)
                {
                    StatusCode = 400
                };
            }
        }
    }
}
