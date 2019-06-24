using System.Collections.Generic;
using ToDoManager.Models;

namespace ToDoManager.Service
{
    public interface ICategoryService
    {
        void CreateCategory(CreateUpdateCategoryModel categoryModel);
        void UpdateCategory(CreateUpdateCategoryModel categoryModel);
        void DeleteCategory(int id);
        List<CategoryModel> GetCategoryList(int userId);
        CategoryModel GetCategoryDetail(int id);
        void CreateDefaultCategoriesForNewUser(int userId);
    }
}
