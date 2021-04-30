using System;
using System.Collections.Generic;
using System.Text;

using Autofac;

namespace Schedule.Infrastructure.Data
{
    public class Module : Autofac.Module
    {
        //public string endPoint { get; set; }
        public string ConnectionString { get; set; }
       // public string accessKeyId { get; set; }
        //public string secretKey { get; set; }
        //public string bucket { get; set; }
        //public string bucketProduct { get; set; }
        //public string bucketUser { get; set; }
        //public string temporaryFilesPath { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace.Contains("Repositories"))
                .WithParameter("connectionString", ConnectionString)
                //.WithParameter("baseEndpoint", endPoint)
                //.WithParameter("accessKeyId", accessKeyId)
                //.WithParameter("secretKey", secretKey)
               // .WithParameter("bucket", bucket)
                //.WithParameter("bucketProduct", bucketProduct)
                //.WithParameter("bucketUser", bucketUser)
               // .WithParameter("temporaryFilesPath", temporaryFilesPath)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //base.Load(builder);
        }
    }
}
