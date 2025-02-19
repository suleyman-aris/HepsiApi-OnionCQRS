using MediatR;

namespace YoutubeApi.Application.Features.Products.Queries.GetAllProduct
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryRespose>>
    {
    }
}
