using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System.ComponentModel.DataAnnotations;
//using ValidationException = FluentValidation.ValidationException;

namespace YoutubeApi.Application.Exceptions
{
    public class ExceptionsMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
			try
			{
				await next(httpContext);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, ex);
			}
        }

		private static Task HandleExceptionAsync(HttpContext httpContent, Exception exception)
		{
			int statusCode = GetStatusCode(exception);
            httpContent.Response.ContentType = "application/json";
			httpContent.Response.StatusCode = statusCode;

			if (exception.GetType() == typeof(FluentValidation.ValidationException))
			{
				return httpContent.Response.WriteAsync(new ExceptionModel
				{
					Errors = ((FluentValidation.ValidationException)exception).Errors.Select(e => e.ErrorMessage),
					StatusCode = StatusCodes.Status400BadRequest
				}.ToString());
			}

			List<string> errors = new()
			{
				$"Hata Mesajı {exception.Message}" 
			};

			return httpContent.Response.WriteAsync(new ExceptionModel
			{
				Errors = errors,
				StatusCode = statusCode
			}.ToString());


		}

		private static int GetStatusCode(Exception exception) =>
			exception switch
			{

                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status400BadRequest,
                FluentValidation.ValidationException => StatusCodes.Status422UnprocessableEntity,
				_ => StatusCodes.Status500InternalServerError

			};

    }
}
