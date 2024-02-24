using Autofac;
using N.Core.Repositories;
using N.Core.Services;
using N.Core.UnitOfWorks;
using N.Repository.Repositories;
using N.Repository.UnitOfWorks;
using N.Repository;
using N.Service.Mapping;
using N.Service.Services;
using System.Reflection;
using N.Caching;

namespace N.API.Modules;
public class RepoServiceModule : Autofac.Module
{

    protected override void Load(ContainerBuilder builder)
    {

        builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();



        var apiAssembly = Assembly.GetExecutingAssembly();
        var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
        var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

        builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


        builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

        builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();

    }
}