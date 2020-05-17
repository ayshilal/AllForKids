using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using EntityLibrary;
using Service.Repository;
using Service.Product.Model;
using CommonType.Response;
using CommonType;
using Service.Base;
using CommonTypes.Response;
using static CommonType.Enums;
using System.Collections.Generic;

namespace Service.Product.Atom
{
    public class ProductService : GenericRepository<EntityLibrary.Model.Product>, IProductRepository
    {
        public ProductService(AppDBContext stockTrackingEntities) : base(stockTrackingEntities)
        {

        }


        public ResponseModel<ProductDtoViewModel> GetAll(ProductDtoSearchModel model)
        {
            var query = Context.Product.AsQueryable();

            if (!string.IsNullOrEmpty(model.Name))
                query = query.Where(r => r.Name.Contains(model.Name));


            var result = query.OrderByDescending(r => r.ID).Select(p => new ProductDtoViewModel
            {
                //ID = p.ID,
                Name = p.Name,
            }).ToList();

            return new ResponseModel<ProductDtoViewModel>((int)Enums.ResponseCode.SUCCESS, result);
        }
        public List<ProductDtoViewModel> Get(ProductDtoSearchModel model)
        {
            var query = Context.Product.AsQueryable();

            if (!string.IsNullOrEmpty(model.Name))
                query = query.Where(r => r.Name.Contains(model.Name));


            var result = query.OrderByDescending(r => r.ID).Select(p => new ProductDtoViewModel
            {
                Name = p.Name,
                Slug = p.Name,
            }).ToList();

            return result;
        }
        public ResponseModel<DropdownListModel> GetAll()
        {
            var query = Context.Product.AsQueryable().Where(p => p.Status == (int)Enums.Flag.ACTIVE);
            var result = query.OrderBy(r => r.Name).Select(p => new DropdownListModel
            {
                Value = p.ID,
                Text = p.Name
            }).ToList();

            return new ResponseModel<DropdownListModel>((int)Enums.ResponseCode.SUCCESS, result);
        }


        public ServicePrimitiveResponseObject<ProductDtoEditModel> GetById(long id)
        {
            var result = new ServicePrimitiveResponseObject<ProductDtoEditModel>();
            var data = FindFirstBy(p => p.ID == id);
            if (data != null)
            {
                var product = new ProductDtoEditModel();
                product.Id = data.ID;
                product.Name = data.Name;
                product.InsertUserId = data.InsertUserId;
                product.InsertDate = data.InsertDate;
                product.Status = data.Status;

                result.Data = product;
            }
            return result;
        }


        public ServicePrimitiveResponse Create(ProductDtoEditModel model)
        {

            var bank = FindFirstBy(p => p.Name == model.Name);
            if (bank != null)
            {
                if (bank.Name == model.Name)
                    return IncorrectData("This Product Name already exist");
            }


            //var data = new EntityLibrary.Model.User();
            //data.Name = model.Name;
            //data.InsertDate = DateTime.Now;
            //data.InsertUserId = model.InsertUserId;
            //data.Status = model.Status;
            //Add(data);

            var servicePrimitiveResponse = UnitOfWork.Commit(model.InsertUserId);


            var product = new EntityLibrary.Model.Product();
            product.Name = model.Name;
            product.InsertDate = DateTime.Now;
            product.InsertUserId = model.InsertUserId;
            product.Status = (int)Flag.ACTIVE;
            Context.Product.Add(product);


            UnitOfWork.Commit(model.InsertUserId);

            return servicePrimitiveResponse;

        }


        public ServicePrimitiveResponse Update(ProductDtoEditModel model)
        {
            var productControl = FindFirstBy(p => (p.Name == model.Name) && p.ID != model.Id);
            if (productControl != null)
            {
                if (productControl.Name == model.Name)
                    return IncorrectData("This product Name already exist");
            }

            var product = FindFirstBy(p => p.ID == model.Id);
            if (product == null)
                return NoDataFound();


            product.Name = model.Name;
            product.InsertDate = DateTime.Now;
            product.LastUpdateUserId = model.LastUpdateUserId;
            product.Status = model.Status;

            Edit(product);

            var servicePrimitiveResponse = UnitOfWork.Commit(model.InsertUserId);
            return servicePrimitiveResponse;
        }
    }
}