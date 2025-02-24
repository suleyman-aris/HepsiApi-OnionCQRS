using YoutubeApi.Application.Base;
using YoutubeApi.Application.Features.Products.Exception;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products, string requestTitle)
        {
            if (products.Any(x=>x.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();

            return Task.CompletedTask;
        }
    }
}
