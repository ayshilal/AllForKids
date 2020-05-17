using CommonType;
using CommonTypes.Page;
using Service.Product.Model;
using System;
using System.Collections.Generic;
using WebApi.Models.Product;

namespace WebApi.Extensions.Product
{
    public static class ProductEditModelMappingExtension
    {
        public static IEnumerable<ProductGridModel> ToGridModel(this IPagedList<EntityLibrary.Model.Product> entity)
        {
            return entity.MapTo<IEnumerable<EntityLibrary.Model.Product>, IEnumerable<ProductGridModel>>();
        }

        public static ProductDtoSearchModel ToSearchModel(this ProductSearchModel entity)
        {
            return entity.MapTo<ProductSearchModel, ProductDtoSearchModel>();
        }

        public static ProductEditModel ToModel(this EntityLibrary.Model.Product entity)
        {
            return entity.MapTo<EntityLibrary.Model.Product, ProductEditModel>();
        }



        public static ProductDtoEditModel ToEntity(this ProductEditModel model)
        {
            var bank = model.MapTo<ProductEditModel, ProductDtoEditModel>();
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
