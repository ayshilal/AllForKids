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
            var bank = model.MapTo<CategoryEditModel, CategoryDtoEditModel>();
            if (model.Id > 0)
            {
                bank.LastUpdateDate = DateTime.Now;
                bank.LastUpdateUserId = UserProfile.Current.UserID;
            }
            else
            {
                bank.InsertDate = DateTime.Now;
                bank.InsertUserId = UserProfile.Current.UserID;
            }
            return bank;
        }
    }
}
