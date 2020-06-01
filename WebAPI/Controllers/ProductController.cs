
using CommonType;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.Product;
using WebApi.Extensions.Product;
using WebApi.Models.Product;

namespace WebApi.Controllers
{
    
    [Route("api/[controller]")]
    //[Authorize]
    [EnableCors("_myAllowSpecificOrigins")]
    public class ProductController : BaseController
    {
        private readonly IProductRepository _ProductRepository;

        public ProductController(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        [HttpGet]
        public IActionResult Get(ProductSearchModel model)
        {
            var Products = _ProductRepository.Get(model.ToSearchModel());
            return Successful(Products);
        }

        //[HttpGet]
        //public IActionResult GetAll(ProductSearchModel model)
        //{
        //    var Products = _ProductRepository.GetAll(model.ToSearchModel());
        //    return Successful(Products);
        //}

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var Products = _ProductRepository.GetAll();
            return Successful(Products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var Product = _ProductRepository.GetById(id);
            if (Product.Data == null)
                return NoDataFound();
            return Successful(Product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductEditModel model)
        {
            if (ModelState.IsValid)
            {

                var response = _ProductRepository.Create(model.ToEntity());
                if (response.ResponseCode == ResponseCode.SUCCESSFUL)
                {
                    return Successful(ResponseMessage.SUCCESSFUL);
                }
                if (response.Errors.Count > 0)
                {
                    return Errors(response.Errors);
                }
            }
            return Errors(ModelState);
        }

        [HttpPut("{id:long}")]
        public IActionResult Put(long id, [FromBody] ProductEditModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id;

                var response = _ProductRepository.Update(model.ToEntity());
                if (response.ResponseCode == ResponseCode.SUCCESSFUL)
                {
                    return Successful(ResponseMessage.SUCCESSFUL);
                }
                if (response.Errors.Count > 0)
                {
                    return Errors(response.Errors);
                }
            }
            return Errors(ModelState);
        }
    }
}