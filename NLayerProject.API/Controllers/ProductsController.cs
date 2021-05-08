using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NLayerProject.API.DTOs;
using NLayerProject.API.Filters;
using NLayerProject.Core.Models;
using NLayerProject.Core.Service;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(product));
        }

        [ServiceFilter(typeof(NotFoundFilter))]//Böyle bir id databasede yoksa notfoundFilter çalışacak içine girmeden geri dönecek
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTask(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetByWithCategoryById(int id)
        {
            var categoryCome = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDto>(categoryCome));
        }

        [ValidationsFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto dto)
        {
            var newproduct = await _productService.AddAsync(_mapper.Map<Product>(dto));

            return Created(string.Empty, _mapper.Map<ProductDto>(newproduct));
        }
         
        [ValidationsFilter]
        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            if (productDto.Id==0)
            {
                throw new Exception("Id alanı gereklidir.");
            }

            var product = _productService.Update(_mapper.Map<Product>(productDto));

            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);

            return NoContent();
        }
    }
}
