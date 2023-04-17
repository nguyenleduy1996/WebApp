﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Products;
using ViewModels.CommonDTO;

namespace Application.Catalog.Products
{
    public   interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);

        Task<List<ProductViewModel>> GetAll();
    }
}
