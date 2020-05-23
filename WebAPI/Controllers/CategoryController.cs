
using CommonType;
using Microsoft.AspNetCore.Mvc;
using Service.Category;
using WebApi.Models.Category;

using WebApi.Extensions.Category;

namespace WebApi.Controllers
{
    //[EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    //[Authorize]

    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryController(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        [HttpGet]
        public IActionResult Get(CategorySearchModel model)
        {
            var Category = _CategoryRepository.Get(model.ToSearchModel());
            return Successful(Category);
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
            var Products = _CategoryRepository.GetAll();
            return Successful(Products);
        }



        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var Category = _CategoryRepository.GetById(id);
            if (Category.Data == null)
                return NoDataFound();
            return Successful(Category);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoryEditModel model)
        {
            if (ModelState.IsValid)
            {

                var response = _CategoryRepository.Create(model.ToEntity());
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
        public IActionResult Put(long id, [FromBody] CategoryEditModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id;

                var response = _CategoryRepository.Update(model.ToEntity());
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