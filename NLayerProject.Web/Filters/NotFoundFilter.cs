﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.Web.DTOs;
using NLayerProject.Core.Service;

namespace NLayerProject.Web.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly ICategoryService _categoryService;

        public NotFoundFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            int id = (int) context.ActionArguments.Values.FirstOrDefault();

            var product = await _categoryService.GetByIdAsync(id);
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
