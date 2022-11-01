using CommonType;
using CommonTypes.Page;
using Service.Category.Model;
using System;
using System.Collections.Generic;
using WebApi.Models.Category;

namespace WebApi.Extensions.Category
{
    public static class CategoryEditModelMappingExtension
    {
        public static IEnumerable<CategoryGridModel> ToGridModel(this IPagedList<EntityLibrary.Model.Product> entity)
        {
            return entity.MapTo<IEnumerable<EntityLibrary.Model.Product>, IEnumerable<CategoryGridModel>>();
        }

        public static CategoryDtoSearchModel ToSearchModel(this CategorySearchModel entity)
        {
            return entity.MapTo<CategorySearchModel, CategoryDtoSearchModel>();
        }

        public static CategoryEditModel ToModel(this EntityLibrary.Model.Product entity)
        {
            return entity.MapTo<EntityLibrary.Model.Product, CategoryEditModel>();
        }



        public static CategoryDtoEditModel ToEntity(this CategoryEditModel model)
        {
            var category = model.MapTo<CategoryEditModel, CategoryDtoEditModel>();
            if (model.Id > 0)
            {
                category.LastUpdateDate = DateTime.Now;
                category.LastUpdateUserId = UserProfile.Current.UserID;
            }
            else
            {
                category.InsertDate = DateTime.Now;
                category.InsertUserId = UserProfile.Current.UserID;
            }
            return category;
        }
    }
}
