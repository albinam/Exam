using ExamBusinessLogic.Interfaces;
using ExamDatabaseImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace ExamView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormArticles>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IAuthorLogic, AuthorLogic>(new
             HierarchicalLifetimeManager());
            currentContainer.RegisterType<IArticleLogic, ArticleLogic>(new
           HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
