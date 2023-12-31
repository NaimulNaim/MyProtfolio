﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigitalPortfolio.Models;
using DigitalPortfolio.Models.Entities;
using System.Text.Json;
using DigitalPortfolio.Services;

namespace DigiPortfoli.Controllers
{
    public class CategoryInfoesController : Controller
    {
        private readonly DBConfiguration _context;
        CategoryManager _categoryManager = new CategoryManager();

        public CategoryInfoesController(DBConfiguration context)
        {
            _context = context;
        }

        // GET: CategoryInfoes
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<string> GetAllCategory()
        {
            return JsonSerializer.Serialize(await _categoryManager.GetCategoryInfoList(_context));
        }

        [HttpGet]
        public async Task<string> GetCategory(int id)
        {
            return JsonSerializer.Serialize(await _categoryManager.GetCategoryInfo(_context, id));
        }

        [HttpPost]
        public async Task<string> AddOrUpdate(CategoryInfo model)
        {
            Result result = new Result();
            if (model == null)
            {
                result.Msg = "Nothing to update. Please insert valid data";
                result.Status = "Error";
                return JsonSerializer.Serialize(result);
            }
            else
            {
                result = await _categoryManager.AddOrUpdate(_context, model);
                return JsonSerializer.Serialize(result);

            }
        }
        [HttpPost]
        public async Task<string> DeleteCategory(int Id)
        {
            Result result = new Result();
            if (Id == 0)
            {
                result.Msg = "Nothing to delete. Please select valid data";
                result.Status = "Error";
                return JsonSerializer.Serialize(result);
            }
            else
            {
                result = await _categoryManager.DeleteCategory(_context, Id);
                return JsonSerializer.Serialize(result);

            }
        }

    }
}