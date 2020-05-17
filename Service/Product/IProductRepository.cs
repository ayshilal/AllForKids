using CommonType.Response;
using CommonTypes.Response;
using Service.Base;
using Service.Product.Model;
using Service.Repository;
using System.Collections.Generic;

namespace Service.Product
{
    public interface IProductRepository : IGenericRepository<EntityLibrary.Model.Product>
    {
        List<ProductDtoViewModel> Get(ProductDtoSearchModel model);
        ResponseModel<ProductDtoViewModel> GetAll(ProductDtoSearchModel model);

        ResponseModel<DropdownListModel> GetAll();
        ServicePrimitiveResponseObject<ProductDtoEditModel> GetById(long id);

        ServicePrimitiveResponse Create(ProductDtoEditModel model);

        ServicePrimitiveResponse Update(ProductDtoEditModel model);
    }

}
