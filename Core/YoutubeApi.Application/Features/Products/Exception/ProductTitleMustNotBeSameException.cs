using YoutubeApi.Application.Base;

namespace YoutubeApi.Application.Features.Products.Exception
{
    public class ProductTitleMustNotBeSameException : BaseException
    {
        public ProductTitleMustNotBeSameException() : base("Ürün başlığı zaten var")
        {

        }
    }
}
