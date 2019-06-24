using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoManager.Models;
using ToDoManager.Service;

namespace ToDoManager.Controllers
{
    [Route("api/categories")]
    [ApiController]
    [Authorize]
    public class CategoryController : BaseController
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(200)]
        public IActionResult CreateCategory(CreateUpdateCategoryModel categoryModel)
        {
            categoryModel.UserId = GetCurrentUserId();
            _categoryService.CreateCategory(categoryModel);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(200)]
        public IActionResult UpdateCategory(CreateUpdateCategoryModel categoryModel)
        {
            categoryModel.UserId = GetCurrentUserId();
            _categoryService.UpdateCategory(categoryModel);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(200)]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok();
        }


        [Route("list")]
        [ProducesResponseType(200, Type = typeof(List<CategoryModel>))]
        public IActionResult GetCategoryList()
        {
            int userId = GetCurrentUserId();
            var categoryList = _categoryService.GetCategoryList(userId);
            return Ok(categoryList);
        }

        [Route("detail/{id}")]
        [ProducesResponseType(200, Type = typeof(CategoryModel))]
        public IActionResult GetCategoryDetail(int id)
        {
            CategoryModel category = _categoryService.GetCategoryDetail(id);
            return Ok(category);
        }
    }
}

//TODO:
//1. Use category detail instead GetCategoryTasks
//2. Invalid route handling
//3. CategoryId should be of same user -Custom exception will be raised
//4. Only authenticated user should be able to create task on his category.