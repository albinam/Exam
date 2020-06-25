using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.Interfaces;
using ExamBusinessLogic.ViewModels;
using ExamDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamDatabaseImplement.Implements
{
    public class AuthorLogic : IAuthorLogic
    {
        public void CreateOrUpdate(AuthorBindingModel model)
        {
            using (var context = new Database())
            {
                Author element = context.Authors.FirstOrDefault(rec => rec.FIO == model.FIO && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть автор с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Authors.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Author();
                    context.Authors.Add(element);
                }
                element.FIO = model.FIO;
                element.Birthday = model.Birthday;
                element.Email = model.Email;
                element.Work = model.Work;
                element.ArticleId = model.ArticleId;
                context.SaveChanges();
            }
        }
        public void Delete(AuthorBindingModel model)
        {
            using (var context = new Database())
            {
                Author element = context.Authors.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Authors.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<AuthorViewModel> Read(AuthorBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Authors
                .Where(rec => model == null 
                || (rec.Id == model.Id))
                .Select(rec => new AuthorViewModel
                {
                    Id = rec.Id,
                    ArticleId = rec.ArticleId,
                    FIO = rec.FIO,
                    Email = rec.Email,
                    Birthday = rec.Birthday,
                    Work = rec.Work,
                    Name = rec.Article.Name,
                })
                .ToList();
            }
        }
    }
}