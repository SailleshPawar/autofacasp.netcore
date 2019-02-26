using Autofac;
using Autofac.Core;
using System;
using System.Net.Http;

namespace WebApplication1
{
    public class AutofacModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new HttpClient() { BaseAddress = new Uri("https://api.ipify.org") })
                 .Named<HttpClient>("ipify")
                 .SingleInstance();

            builder.Register(ctx => new HttpClient() { BaseAddress = new Uri("https://api.postcodes.io") })
                .Named<HttpClient>("postcodes.io")
                .SingleInstance();

            builder.RegisterType<Customer>().As<ICustomer>();
        }
    }

    public class Customer: ICustomer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName => "saillesh";
    }

    public interface ICustomer
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; }
    }

}
