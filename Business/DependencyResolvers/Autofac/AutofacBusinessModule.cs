using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{   //Autofac bize eyni zamanda AOP destegi veriyor deye istifade edirik 
    public class AutofacBusinessModule : Module
    {   //load uygulama hayata gecdiyi zaman meselen iss decrise(yayinlamaq) elediyim an
        // bu kodlar islyecek (her ortam)
        protected override void Load(ContainerBuilder builder)
        {
            //registertype services.AddSingletona qarsiliq gelir
            //biri senden IProductService isterse ona ProductManager instance ver
            //singleinstance bir kere uredib hami ile paylasir
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            
            //calisan uygulama icerisieinde
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //implemente edilmis interfaceleri tap
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {//onlar icin aspectinerceptorselecteri cagir
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
