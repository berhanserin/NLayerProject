using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLayerProject.Web.ApiService;
using NLayerProject.Web.Filters;

namespace NLayerProject.Web.Controllers
{
    public class categoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly CategoryApiService _categoryApiService;
        public categoriesController(IMapper mapper, CategoryApiService categoryApiService)
        {
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {

            var categories = await _categoryApiService.GetAllAsyncTask();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryApiService.AddAsync(categoryDto);

            return RedirectToAction("Index");
        }
        // Update/5
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryApiService.Update(categoryDto);

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryApiService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
