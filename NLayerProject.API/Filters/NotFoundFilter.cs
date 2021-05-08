using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Service;

namespace NLayerProject.API.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            int id = (int) context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetByIdAsync(id);
            if (product!=null)
            {
                await next();
            }

            else
            {
                ErrorDto errorDto=new ErrorDto();

                errorDto.Status = 404;
                errorDto.Erors.Add($"id'si {id} olan ürün veri tabanında bulunamadı.");
                context.Result=new NotFoundObjectResult(errorDto);
            }
        }
    }
}
