[assembly: WebActivator.PostApplicationStartMethod(typeof(TMS_Services.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace TMS_Services.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;
    using OdooRpcWrapper;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    using TMS_Services.App_Data;
    using TMS_Services.Infraestructure.Interfaces;
    using TMS_Services.Infraestructure.Repository;
    using TMS_Services.Models.DAL;
    using TMS_Services.Models.DTO;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            
        }
     
        private static void InitializeContainer(Container container)
        {

            container.Register<DeltaDBEntities>(Lifestyle.Scoped);
            
            // dependency injection 
            container.Register(typeof(IRepository<>), typeof(Repository<>),Lifestyle.Transient);

            // registro de clases de acceso a datos : Desing Pattern Repository with Unit of Work
            container.Register<IEnvironmentApiOdooRepository, EnvironmentApiOdooRepository>(Lifestyle.Transient);
            container.Register<IConnectionApiOdooRepository, ConnectionApiOdooRepository>(Lifestyle.Transient);
            container.Register<ICarrierRepository, CarrierRepository>(Lifestyle.Transient);
            container.Register<ICarrierRouteRepository, CarrierRouteRepository>(Lifestyle.Transient);
            container.Register<ICarrierMembershipRepository, CarrierMembershipRepository>(Lifestyle.Transient);
            container.Register<IRouteRepository, RouteRepository>(Lifestyle.Transient);
            container.Register<ITruckTypeRepository, TruckTypeRepository>(Lifestyle.Transient);
            container.Register<IServiceTypeRepository, ServiceTypeRepository>(Lifestyle.Transient);
            container.Register<IUnitMeasurementRepository, UnitMeasurementRepository>(Lifestyle.Transient);
            container.Register<IUnitMeasurementTypeRepository, UnitMeasurementTypeRepository>(Lifestyle.Transient);
            container.Register<IUserRepository, UserRepository>(Lifestyle.Transient);
            container.Register<IQuotationRepository, QuotationRepository>(Lifestyle.Transient);
            container.Register<IClientRepository, ClientRepository>(Lifestyle.Transient);
            container.Register<IMembershipRepository, MembershipRepository>(Lifestyle.Transient);
            container.Register<IInformationFileRepository, InformationFileRepository>(Lifestyle.Transient);
            container.Register<ITaskConfigurationRepository, TaskConfigurationRepository>(Lifestyle.Transient);
            container.Register<IOperationRepository, OperationRepository>(Lifestyle.Transient);
            container.Register<ITaskOperationRepository, TaskOperationRepository>(Lifestyle.Transient);
            container.Register<IStageOperationRepository, StageOperationRepository>(Lifestyle.Transient);
            container.Register<IServiceTypeMembershipRepository, ServiceTypeMembershipRepository>(Lifestyle.Transient);


            // terminar de agregar las clases necesarias par el proyecto

            // registro de clases de tipo: data access layer (DAL)
            container.Register<CarrierDAL>(Lifestyle.Transient);
            container.Register<TruckTypeDAL>(Lifestyle.Transient);
            container.Register<ServiceTypeDAL>(Lifestyle.Transient);
            container.Register<UnitMeasurementDAL>(Lifestyle.Transient);
            container.Register<UnitMeasurementTypeDAL>(Lifestyle.Transient);
            container.Register<UserDAL>(Lifestyle.Transient);
            container.Register<QuotationDAL>(Lifestyle.Transient);
            container.Register<ClientDAL>(Lifestyle.Transient);
            container.Register<ProjectDAL>(Lifestyle.Transient);
            container.Register<MembershipDAL>(Lifestyle.Transient);
            container.Register<InformationFileDAL>(Lifestyle.Transient);
            container.Register<TaskConfigurationDAL>(Lifestyle.Transient);
            container.Register<ContactDAL>(Lifestyle.Transient);
            container.Register<EnvironmentApiOdooDAL>(Lifestyle.Transient);
            container.Register<ConnectionApiOdooDAL>(Lifestyle.Transient);
            container.Register<MailServiceDAL>(Lifestyle.Transient);
            container.Register<ServiceTypeMembershipDAL>(Lifestyle.Transient);

            //container.RegisterInitializer<OdooAPI>(s => s = new OdooAPI(new OdooConnectionCredentials("","","","")) );
            //container.RegisterSingleton<>
            //            container.Register<IRepository<CarrierDTO>, CarrierDAL>(Lifestyle.Scoped);
            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
        }
    }
}