using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamBusinessLogic.Interfaces
{
    public interface IArticleLogic
    {
        List<ArticleViewModel> Read(ArticleBindingModel model);
        void CreateOrUpdate(ArticleBindingModel model);
        void Delete(ArticleBindingModel model);
    }
}
