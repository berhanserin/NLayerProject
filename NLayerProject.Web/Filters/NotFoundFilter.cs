using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.Web.ApiService;
using NLayerProject.Web.DTOs;

namespace NLayerProject.Web.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly CategoryApiService _categoryApiService;

        public NotFoundFilter(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }


        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            int id = (int) context.ActionArguments.Values.FirstOrDefault();

            var product = await _categoryApiService.GetByIdAsync(id);
            if (product!=null)
            {
                await next();
            }

            else
            {
                ErrorDto errorDto=new ErrorDto();


                errorDto.Erors.Add($"id'si {id} olan Kategory veri tabanında bulunamadı.");
                context.Result=new RedirectToActionResult("Error","Home",errorDto);
            }
        }
    }
}
