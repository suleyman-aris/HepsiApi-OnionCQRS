using MediatR;
using Microsoft.EntityFrameworkCore;
using YoutubeApi.Application.DTO;
using YoutubeApi.Application.Interface.AutoMapper;
using YoutubeApi.Application.Interface.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Queries.GetAllProduct
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryRespose>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllProductsQueryRespose>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include : x => x.Include(b => b.Brand));

            var brand = mapper.Map<BrandDto, Brand>(new Brand());

            var map = mapper.Map<GetAllProductsQueryRespose, Product>(products);
            foreach (var item in map)
                item.Price -= (item.Price * item.Discount / 100);

            return map;

            //throw new Exception("hata mesajı");
        }
    }
}
