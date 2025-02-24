using FluentValidation;
using MediatR;

namespace YoutubeApi.Application.Beheviors
{
    public class FluentValidationBehevior<TRequest, TResponse> : IPipelineBehavior<IRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;

        public FluentValidationBehevior(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validator = validator;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var fialtures = validator
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .GroupBy(x => x.ErrorMessage)
                .Select(x => x.First())
                .Where(f => f != null)
                .ToList();

            if (fialtures.Any())
                throw new ValidationException(fialtures);
            return next();
        }

        public Task<TResponse> Handle(IRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>((TRequest)request);
            var fialtures = validator
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .GroupBy(x => x.ErrorMessage)
                .Select(x => x.First())
                .Where(f => f != null)
                .ToList();

            if (fialtures.Any())
                throw new ValidationException(fialtures);
            return next();
        }
    }
}
