﻿using ms.category.api.Helpers.Services.Blocks.Categories.Contracts;

namespace ms.category.api.Helpers.Services.Blocks.Categories
{
    public class CategoriesControllerDependencyBlock : ICategoriesControllerDependencyBlock
    {
        public CategoriesControllerDependencyBlock(ICreateCategoryProcessor createCategoryProcessor,
                                                        IInquiryCategoryProcessor inquiryCategoryProcessor,
                                                        IUpdateCategoryProcessor updateCategoryProcessor,
                                                        IInquiryAllCategoriesProcessor allCategoryProcessor,
                                                        IDeleteCategoryProcessor deleteCategoryProcessor)

        {
            CreateCategoryProcessor = createCategoryProcessor;
            InquiryCategoryProcessor = inquiryCategoryProcessor;
            UpdateCategoryProcessor = updateCategoryProcessor;
            InquiryAllCategoriesProcessor = allCategoryProcessor;
            DeleteCategoryProcessor = deleteCategoryProcessor;
        }

        public ICreateCategoryProcessor CreateCategoryProcessor { get; private set; }
        public IInquiryCategoryProcessor InquiryCategoryProcessor { get; private set; }
        public IUpdateCategoryProcessor UpdateCategoryProcessor { get; private set; }
        public IInquiryAllCategoriesProcessor InquiryAllCategoriesProcessor { get; private set; }
        public IDeleteCategoryProcessor DeleteCategoryProcessor { get; private set; }
    }
}