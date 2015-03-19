﻿using MySocialNetwork2.Models;
using MySocialNetwork2.Repository.Implementation;
using MySocialNetwork2.Repository.Interfaces;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MySocialNetwork2.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MySocialNetwork2.App_Start.NinjectWebCommon), "Stop")]

namespace MySocialNetwork2.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>().InRequestScope();
            kernel.Bind<ICommentRepository>().To<CommentRepository>().InRequestScope();
            kernel.Bind<IAnswersRepository>().To<AnswersRepository>().InRequestScope();
            kernel.Bind<ITagRepository>().To<TagRepository>().InRequestScope();
            //kernel.Bind<IImmagesRepozitory>().To<ImmagesRepozitory>().InRequestScope();
            kernel.Bind<IReferenceToTaskRepository>().To<ReferenceToTaskRepository>().InRequestScope();
            kernel.Bind<ISolvedTaskRepository>().To<SolvedTaskRepository>().InRequestScope();
            kernel.Bind<ITaskRepository>().To<TaskRepository>().InRequestScope();
            //kernel.Bind<IVideosRepozitory>().To<VideosRepozitory>().InRequestScope();
        }        
    }
}
