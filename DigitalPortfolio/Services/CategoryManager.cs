using DigitalPortfolio.Models.Entities;
using DigitalPortfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalPortfolio.Services
{
    public class CategoryManager
    {

        public async Task<CategoryInfo> GetCategoryInfo(DBConfiguration _context, int id)
        {
            return await _context.CategoryInfo.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<CategoryInfo>> GetCategoryInfoList(DBConfiguration _context)
        {
            return await _context.CategoryInfo.ToListAsync();
        }

        public async Task<Result> AddOrUpdate(DBConfiguration _context, CategoryInfo model)
        {
            Result result = new Result();

            try
            {
                if (model.Id == 0)
                {
                    _context.Add(model);
                    _context.SaveChanges();
                    result.Msg = "Data inserted successfully!";
                    result.Status = "success";
                }
                else
                {
                    CategoryInfo updateModel = await GetCategoryInfo(_context, model.Id);
                    updateModel.Name = model.Name;
                    _context.Update(updateModel);
                    _context.SaveChanges();
                    result.Msg = "Data updated successfully!";
                    result.Status = "success";
                }
            }
            catch (Exception ex)
            {
                result.Msg = ex.Message;
                result.Status = "error";
            }
            return result;

        }
        public async Task<Result> DeleteCategory(DBConfiguration _context, int id)
        {
            CategoryInfo cat = await GetCategoryInfo(_context, id);
            _context.CategoryInfo.Remove(cat);
            _context.SaveChanges();
            Result result = new Result();
            result.Status = "success";
            result.Msg = "Data Deleted Successfully!";
            return result;
        }

    }
}