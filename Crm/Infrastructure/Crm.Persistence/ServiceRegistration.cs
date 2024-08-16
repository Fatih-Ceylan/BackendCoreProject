using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.ReadRepository.Files;
using GCrm.Application.Repositories.WriteRepository;
using GCrm.Application.Repositories.WriteRepository.Files;
using GCrm.Persistence.Repositories.ReadRepository;
using GCrm.Persistence.Repositories.ReadRepository.Files;
using GCrm.Persistence.Repositories.WriteRepository;
using GCrm.Persistence.Repositories.WriteRepository.Files;
using Microsoft.Extensions.DependencyInjection;

namespace GCrm.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddGCrmPersistenceServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<BaseProjectDbContext>();
            //#region AppUser
            //services.AddScoped<IAppUserService, AppUserService>();
            //services.AddScoped<IAuthService, AuthService>();
            //#endregion

            #region Definitions

            #region Customer

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            #endregion

            #region CustomerRepresentative

            services.AddScoped<ICustomerRepresentativeReadRepository, CustomerRepresentativeReadRepository>();
            services.AddScoped<ICustomerRepresentativeWriteRepository, CustomerRepresentativeWriteRepository>();
            #endregion

            #region CustomerAddress

            services.AddScoped<ICustomerAddressReadRepository, CustomerAddressReadRepository>();
            services.AddScoped<ICustomerAddressWriteRepository, CustomerAddressWriteRepository>();
            #endregion

            #region CustomerCategory

            services.AddScoped<ICustomerCategoryReadRepository, CustomerCategoryReadRepository>();
            services.AddScoped<ICustomerCategoryWriteRepository, CustomerCategoryWriteRepository>();
            #endregion

            #region CustomerGroup

            services.AddScoped<ICustomerGroupReadRepository, CustomerGroupReadRepository>();
            services.AddScoped<ICustomerGroupWriteRepository, CustomerGroupWriteRepository>();
            #endregion

            #region CustomerContact

            services.AddScoped<ICustomerContactReadRepository, CustomerContactReadRepository>();
            services.AddScoped<ICustomerContactWriteRepository, CustomerContactWriteRepository>();
            #endregion

            #region CustomerKind

            services.AddScoped<ICustomerKindReadRepository, CustomerKindReadRepository>();
            services.AddScoped<ICustomerKindWriteRepository, CustomerKindWriteRepository>();
            #endregion

            #region CustomerSector

            services.AddScoped<ICustomerSectorReadRepository, CustomerSectorReadRepository>();
            services.AddScoped<ICustomerSectorWriteRepository, CustomerSectorWriteRepository>();
            #endregion

            #region CustomerSource

            services.AddScoped<ICustomerSourceReadRepository, CustomerSourceReadRepository>();
            services.AddScoped<ICustomerSourceWriteRepository, CustomerSourceWriteRepository>();
            #endregion

            #region CustomerStatus

            services.AddScoped<ICustomerStatusReadRepository, CustomerStatusReadRepository>();
            services.AddScoped<ICustomerStatusWriteRepository, CustomerStatusWriteRepository>();
            #endregion

            #region CustomerType

            services.AddScoped<ICustomerTypeReadRepository, CustomerTypeReadRepository>();
            services.AddScoped<ICustomerTypeWriteRepository, CustomerTypeWriteRepository>();
            #endregion

            #region CustomerSubject

            services.AddScoped<ICustomerSubjectReadRepository, CustomerSubjectReadRepository>();
            services.AddScoped<ICustomerSubjectWriteRepository, CustomerSubjectWriteRepository>();

            #endregion

            #region CustomerActivityKind

            services.AddScoped<ICustomerActivityKindReadRepository, CustomerActivityKindReadRepository>();
            services.AddScoped<ICustomerActivityKindWriteRepository, CustomerActivityKindWriteRepository>();

            #endregion

            #region CustomerActivity

            services.AddScoped<ICustomerActivityReadRepository, CustomerActivityReadRepository>();
            services.AddScoped<ICustomerActivityWriteRepository, CustomerActivityWriteRepository>();

            #endregion

            #region CustomerActivitySubject

            services.AddScoped<ICustomerActivitySubjectReadRepository, CustomerActivitySubjectReadRepository>();
            services.AddScoped<ICustomerActivitySubjectWriteRepository, CustomerActivitySubjectWriteRepository>();

            #endregion

            #region CustomerActivityStatus

            services.AddScoped<ICustomerActivityStatusReadRepository, CustomerActivityStatusReadRepository>();
            services.AddScoped<ICustomerActivityStatusWriteRepository, CustomerActivityStatusWriteRepository>();

            #endregion

            #region CustomerActivityTeam

            services.AddScoped<ICustomerActivityTeamReadRepository, CustomerActivityTeamReadRepository>();
            services.AddScoped<ICustomerActivityTeamWriteRepository, CustomerActivityTeamWriteRepository>();

            #endregion

            #region CustomerActivityType

            services.AddScoped<ICustomerActivityTypeReadRepository, CustomerActivityTypeReadRepository>();
            services.AddScoped<ICustomerActivityTypeWriteRepository, CustomerActivityTypeWriteRepository>();

            #endregion

            #region CustomerOffer

            services.AddScoped<ICustomerOfferReadRepository, CustomerOfferReadRepository>();
            services.AddScoped<ICustomerOfferWriteRepository, CustomerOfferWriteRepository>();

            #endregion

            #region CompanyOffer

            services.AddScoped<ICompanyOfferReadRepository, CompanyOfferReadRepository>();
            services.AddScoped<ICompanyOfferWriteRepository, CompanyOfferWriteRepository>();

            #endregion

            #region CompanyTender

            services.AddScoped<ICompanyTenderReadRepository, CompanyTenderReadRepository>();
            services.AddScoped<ICompanyTenderWriteRepository, CompanyTenderWriteRepository>();

            #endregion

            #region CustomerProject

            services.AddScoped<ICustomerProjectReadRepository, CustomerProjectReadRepository>();
            services.AddScoped<ICustomerProjectWriteRepository, CustomerProjectWriteRepository>();

            #endregion

            #region Employee

            //services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            //services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();

            #endregion

            #region Opportunity

            services.AddScoped<IOpportunityReadRepository, OpportunityReadRepository>();
            services.AddScoped<IOpportunityWriteRepository, OpportunityWriteRepository>();

            #endregion

            #region OpportunityStage

            services.AddScoped<IOpportunityStageReadRepository, OpportunityStageReadRepository>();
            services.AddScoped<IOpportunityStageWriteRepository, OpportunityStageWriteRepository>();

            #endregion

            #region OpportunityReference

            services.AddScoped<IOpportunityReferenceReadRepository, OpportunityReferenceReadRepository>();
            services.AddScoped<IOpportunityReferenceWriteRepository, OpportunityReferenceWriteRepository>();

            #endregion

            #region OpportunitySector

            services.AddScoped<IOpportunitySectorReadRepository, OpportunitySectorReadRepository>();
            services.AddScoped<IOpportunitySectorWriteRepository, OpportunitySectorWriteRepository>();

            #endregion

            #region SolutionOffer

            services.AddScoped<ISolutionOfferReadRepository, SolutionOfferReadRepository>();
            services.AddScoped<ISolutionOfferWriteRepository, SolutionOfferWriteRepository>();

            #endregion

            #region CompanyContactName

            services.AddScoped<ICompanyContactNameReadRepository, CompanyContactNameReadRepository>();
            services.AddScoped<ICompanyContactNameWriteRepository, CompanyContactNameWriteRepository>();

            #endregion

            #region Users

            services.AddScoped<IUsersReadRepository, UsersReadRepository>();
            services.AddScoped<IUsersWriteRepository, UsersWriteRepository>();
            #endregion

            //#region Offers

            //services.AddScoped<IOffersReadRepository, OffersReadRepository>();
            //services.AddScoped<IOffersWriteRepository, OffersWriteRepository>();
            //#endregion

            //#region Sales

            //services.AddScoped<ISalesReadRepository, SalesReadRepository>();
            //services.AddScoped<ISalesWriteRepository, SalesWriteRepository>();
            //#endregion
            #region Product

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            #endregion
            #region ProductBrand

            services.AddScoped<IProductBrandReadRepository, ProductBrandReadRepository>();
            services.AddScoped<IProductBrandWriteRepository, ProductBrandWriteRepository>();
            #endregion
            #region ProductCategory

            services.AddScoped<IProductCategoryReadRepository, ProductCategoryReadRepository>();
            services.AddScoped<IProductCategoryWriteRepository, ProductCategoryWriteRepository>();
            #endregion
            #region ProductMainCategory

            services.AddScoped<IProductMainCategoryReadRepository, ProductMainCategoryReadRepository>();
            services.AddScoped<IProductMainCategoryWriteRepository, ProductMainCategoryWriteRepository>();
            #endregion
            #region ProductManufacturer

            services.AddScoped<IProductManufacturerReadRepository, ProductManufacturerReadRepository>();
            services.AddScoped<IProductManufacturerWriteRepository, ProductManufacturerWriteRepository>();
            #endregion
            #region ProductModel

            services.AddScoped<IProductModelReadRepository, ProductModelReadRepository>();
            services.AddScoped<IProductModelWriteRepository, ProductModelWriteRepository>();
            #endregion
            #region ProductSubCategory

            services.AddScoped<IProductSubCategoryReadRepository, ProductSubCategoryReadRepository>();
            services.AddScoped<IProductSubCategoryWriteRepository, ProductSubCategoryWriteRepository>();
            #endregion
            #region ProductType

            services.AddScoped<IProductTypeReadRepository, ProductTypeReadRepository>();
            services.AddScoped<IProductTypeWriteRepository, ProductTypeWriteRepository>();
            #endregion



            #region Project

            services.AddScoped<IProjectReadRepository, ProjectReadRepository>();
            services.AddScoped<IProjectWriteRepository, ProjectWriteRepository>();
            #endregion

            #region ProjectManager

            services.AddScoped<IProjectManagerReadRepository, ProjectManagerReadRepository>();
            services.AddScoped<IProjectManagerWriteRepository, ProjectManagerWriteRepository>();
            #endregion

            #region ProjectTeam

            services.AddScoped<IProjectTeamReadRepository, ProjectTeamReadRepository>();
            services.AddScoped<IProjectTeamWriteRepository, ProjectTeamWriteRepository>();
            #endregion

            #region ProjectStatues

            services.AddScoped<IProjectStatuesReadRepository, ProjectStatuesReadRepository>();
            services.AddScoped<IProjectStatuesWriteRepository, ProjectStatuesWriteRepository>();
            #endregion

            #region ProjectType

            services.AddScoped<IProjectTypeReadRepository, ProjectTypeReadRepository>();
            services.AddScoped<IProjectTypeWriteRepository, ProjectTypeWriteRepository>();
            #endregion

            #region Files

            services.AddScoped<ICustomerFileReadRepository, CustomerFileReadRepository>();
            services.AddScoped<ICustomerFileWriteRepository, CustomerFileWriteRepository>();

            services.AddScoped<IProjectFileReadRepository, ProjectFileReadRepository>();
            services.AddScoped<IProjectFileWriteRepository, ProjectFileWriteRepository>();

            #endregion

            #endregion

        }
    }
}