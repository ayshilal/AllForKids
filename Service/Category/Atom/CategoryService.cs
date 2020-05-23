using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using EntityLibrary;
using Service.Repository;
using CommonType.Response;
using CommonType;
using Service.Base;
using CommonTypes.Response;
using static CommonType.Enums;
using System.Collections.Generic;
using Service.Category.Model;

namespace Service.Category.Atom
{
    public class CategoryService : GenericRepository<EntityLibrary.Model.Category>, ICategoryRepository
    {
        public CategoryService(AppDBContext stockTrackingEntities) : base(stockTrackingEntities)
        {

        }


        public ResponseModel<CategoryDtoViewModel> GetAll(CategoryDtoSearchModel model)
        {
            var query = Context.Category.AsQueryable();

            if (!string.IsNullOrEmpty(model.Slug))
                query = query.Where(r => r.Slug.Contains(model.Slug));


            var result = query.OrderByDescending(r => r.ID).Select(p => new CategoryDtoViewModel
            {
                ID = p.ID,
                Slug = p.Slug,
                Image = p.Image,
                Items = p.Items,
                Path = p.Path,
                Type = p.Type
            }).ToList();

            return new ResponseModel<CategoryDtoViewModel>((int)Enums.ResponseCode.SUCCESS, result);
        }
        public List<CategoryDtoViewModel> Get(CategoryDtoSearchModel model)
        {
            var query = Context.Category.AsQueryable();

            if (!string.IsNullOrEmpty(model.Slug))
                query = query.Where(r => r.Slug.Contains(model.Slug));


            var result = query.OrderByDescending(r => r.ID).Select(p => new CategoryDtoViewModel
            {
                ID = p.ID,
                Slug = p.Slug,
                Image = p.Image,
                Items = p.Items,
                Path = p.Path,
                Type = p.Type
            }).ToList();

            return result;
        }
        public ResponseModel<DropdownListModel> GetAll()
        {
            var query = Context.Category.AsQueryable().Where(p => p.Status == (int)Enums.Flag.ACTIVE);
            var result = query.OrderBy(r => r.Slug).Select(p => new DropdownListModel
            {
                Value = p.ID,
                Text = p.Slug
            }).ToList();

            return new ResponseModel<DropdownListModel>((int)Enums.ResponseCode.SUCCESS, result);
        }


        public ServicePrimitiveResponseObject<CategoryDtoEditModel> GetById(long id)
        {
            var result = new ServicePrimitiveResponseObject<CategoryDtoEditModel>();
            var data = FindFirstBy(p => p.ID == id);
            if (data != null)
            {
                var category = new CategoryDtoEditModel();
                category.ID = data.ID;
                category.Slug = data.Slug;
                category.Type = data.Image;
                category.InsertUserId = data.InsertUserId;
                category.InsertDate = data.InsertDate;
                category.Status = data.Status;

                result.Data = category;
            }
            return result;
        }


        public ServicePrimitiveResponse Create(CategoryDtoEditModel model)
        {

            var item = FindFirstBy(p => p.Slug == model.Slug);
            if (item != null)
            {
                if (item.Slug == model.Slug)
                    return IncorrectData("This data already exist");
            }


            //var data = new EntityLibrary.Model.User();
            //data.Name = model.Name;
            //data.InsertDate = DateTime.Now;
            //data.InsertUserId = model.InsertUserId;
            //data.Status = model.Status;
            //Add(data);

            var servicePrimitiveResponse = UnitOfWork.Commit(model.InsertUserId);


            var category = new EntityLibrary.Model.Category();
            category.Slug = model.Slug;
            category.InsertDate = DateTime.Now;
            category.InsertUserId = model.InsertUserId;
            category.Status = (int)Flag.ACTIVE;
            Context.Category.Add(category);


            UnitOfWork.Commit(model.InsertUserId);

            return servicePrimitiveResponse;

        }


        public ServicePrimitiveResponse Update(CategoryDtoEditModel model)
        {
            var categoryControl = FindFirstBy(p => (p.Slug == model.Slug) && p.ID != model.ID);
            if (categoryControl != null)
            {
                if (categoryControl.Slug == model.Slug)
                    return IncorrectData("This data already exist");
            }

            var category = FindFirstBy(p => p.ID == model.ID);
            if (category == null)
                return NoDataFound();


            category.Slug = model.Slug;
            category.InsertDate = DateTime.Now;
            category.LastUpdateUserId = model.LastUpdateUserId;
            category.Status = model.Status;

            Edit(category);

            var servicePrimitiveResponse = UnitOfWork.Commit(model.InsertUserId);
            return servicePrimitiveResponse;
        }
    }
}