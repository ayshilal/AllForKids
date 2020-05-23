using CommonType.Response;
using CommonTypes.Response;
using Service.Base;
using Service.Category.Model;
using Service.Repository;
using System.Collections.Generic;

namespace Service.Category
{
    public interface ICategoryRepository : IGenericRepository<EntityLibrary.Model.Category>
    {
        List<CategoryDtoViewModel> Get(CategoryDtoSearchModel model);
        ResponseModel<CategoryDtoViewModel> GetAll(CategoryDtoSearchModel model);

        ResponseModel<DropdownListModel> GetAll();
        ServicePrimitiveResponseObject<CategoryDtoEditModel> GetById(long id);

        ServicePrimitiveResponse Create(CategoryDtoEditModel model);

        ServicePrimitiveResponse Update(CategoryDtoEditModel model);
    }

}
