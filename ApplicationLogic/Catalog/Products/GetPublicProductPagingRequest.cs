using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.CommonDTO;

namespace ViewModels.Catalog.Productss
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public string languageId { get; set; }
        public int? CategoryId { get; set; }
    }
}
