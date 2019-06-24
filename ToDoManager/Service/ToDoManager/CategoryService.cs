using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoManager.DataModel;
using ToDoManager.Models;
using ToDoManager.Repository;
using System.Linq.Expressions;

namespace ToDoManager.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void CreateCategory(CreateUpdateCategoryModel categoryModel)
        {
            var categoryToCreate = _mapper.Map<Categories>(categoryModel);
            _unitOfWork.CategoryRepository.Insert(categoryToCreate);
            _unitOfWork.SaveChanges();
        }

        public List<CategoryModel> GetCategoryList(int userId)
        {
            var categories = _unitOfWork.CategoryRepository.Get(category => category.UserId == userId);
            return _mapper.Map<List<CategoryModel>>(categories);
        }

        public void UpdateCategory(CreateUpdateCategoryModel categoryModel)
        {
            var categoryToUpdate = _mapper.Map<Categories>(categoryModel);
            _unitOfWork.CategoryRepository.Update(categoryToUpdate);
            _unitOfWork.SaveChanges();
        }

        public CategoryModel GetCategoryDetail(int id)
        {
            var categoryDetail = _unitOfWork.CategoryRepository.Get(category => category.Id == id,
                includeProperties: new Expression<Func<Categories, object>>[] { x => x.Tasks }).FirstOrDefault();

            return _mapper.Map<CategoryModel>(categoryDetail);
        }

        public void DeleteCategory(int id)
        {
            var categoryDetail = _unitOfWork.CategoryRepository.Get(category => category.Id == id,
               includeProperties: new Expression<Func<Categories, object>>[] { x => x.Tasks }).FirstOrDefault();

            if (categoryDetail != null)
            {
                if (categoryDetail.Tasks != null)
                {
                    foreach (var task in categoryDetail.Tasks)
                    {
                        _unitOfWork.TaskRepository.Delete(task);
                    }
                    _unitOfWork.CategoryRepository.Delete(categoryDetail);
                    _unitOfWork.SaveChanges();
                }
            }
        }

        public void CreateDefaultCategoriesForNewUser(int userId)
        {
            Categories category1 = new Categories
            {
                Name = "Personal Tasks",
                UserId = userId
            };
            Categories category2 = new Categories
            {
                Name = "Office Tasks",
                UserId = userId
            };

            _unitOfWork.CategoryRepository.Insert(category1);
            _unitOfWork.CategoryRepository.Insert(category2);
            _unitOfWork.SaveChanges();
        }
    }
}
