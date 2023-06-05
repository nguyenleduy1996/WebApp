
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Products;
using ViewModels.Catalog.Products.ProductImages;
using ViewModels.CommonDTO;

namespace Application.Catalog.Products
{
    public interface IAdminProductService
    {
        Task <int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int ProductId);
        Task< List<ProductViewModel>> Getall();
        Task< PagedResult<ProductViewModel>> GetAllPaging(GetProductPaginRequest request);
        Task<ProductViewModel> GetById(int productId, string languageId);
        Task<bool> UpdatePrice(int ProductId, decimal newPrice);
        Task AddViewcount(int productID);
        Task<bool> UpdateStock (int productId, int AddedQuantity);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);
        Task<int> RemoveImage( int imageId);
        Task<int> UpdateImage( int imageId, ProductImageUpdateRequest request);
        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImages(int productId);


    }
}
