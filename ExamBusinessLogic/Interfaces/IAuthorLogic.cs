using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamBusinessLogic.Interfaces
{
    public interface IAuthorLogic
    {
        List<AuthorViewModel> Read(AuthorBindingModel model);
        void CreateOrUpdate(AuthorBindingModel model);
        void Delete(AuthorBindingModel model);
    }
}
