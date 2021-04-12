using ElevenNote.Data;
using ElevenNote.Services;
using ElevneNote.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        public IHttpActionResult Get()
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetCategory();
            return Ok(category);
        }

        public IHttpActionResult Get(int categoryId)
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetCategoryById(categoryId);
            return Ok(category);
        }

        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }

        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var categoryService = new CategoryService(userId);
            return categoryService;
        }

        public IHttpActionResult Put(CategoryEdit category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.UpdateCategory(category))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int categoryId)
        {
            var service = CreateCategoryService();

            if (!service.DeleteCategory(categoryId))
                return InternalServerError();

            return Ok();
        }
    }
}
