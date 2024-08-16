using AutoMapper;
using BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities;
using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Contacts;
using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;
using BaseProject.Domain.Entities.GCrm.Definitions.UserManagement.Users;
using GCrm.Application.Features.Commands.Definitions.Customer.Create;
using GCrm.Application.Features.Commands.Definitions.Customer.Update;
using GCrm.Application.Features.Commands.Definitions.CustomerActivity.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerActivity.Update;
using GCrm.Application.Features.Commands.Definitions.CustomerActivityKind.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerActivityStatus.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerActivitySubject.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerActivityTeam.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerActivityType.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerAddress.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerAddress.Update;
using GCrm.Application.Features.Commands.Definitions.CustomerCategory.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerCategory.Update;
using GCrm.Application.Features.Commands.Definitions.CustomerContact.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerContact.Update;
using GCrm.Application.Features.Commands.Definitions.CustomerGroup.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerGroup.Update;
using GCrm.Application.Features.Commands.Definitions.CustomerKind.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerKind.Update;
using GCrm.Application.Features.Commands.Definitions.CustomerOffer.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerProject.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerRepresentative.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerRepresentative.Update;
using GCrm.Application.Features.Commands.Definitions.CustomerSector.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerSector.Update;
using GCrm.Application.Features.Commands.Definitions.CustomerSource.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerSource.Update;
using GCrm.Application.Features.Commands.Definitions.CustomerStatus.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerStatus.Update;
using GCrm.Application.Features.Commands.Definitions.CustomerSubject.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerType.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerType.Update;
using GCrm.Application.Features.Commands.Definitions.Opportunity.Create;
using GCrm.Application.Features.Commands.Definitions.Opportunity.Update;
using GCrm.Application.Features.Commands.Definitions.OpportunityReference.Create;
using GCrm.Application.Features.Commands.Definitions.OpportunityReference.Update;
using GCrm.Application.Features.Commands.Definitions.OpportunitySector.Create;
using GCrm.Application.Features.Commands.Definitions.OpportunitySector.Update;
using GCrm.Application.Features.Commands.Definitions.OpportunityStage.Create;
using GCrm.Application.Features.Commands.Definitions.OpportunityStage.Update;
using GCrm.Application.Features.Commands.Definitions.Users.Create;
using GCrm.Application.Features.Commands.Definitions.Users.Update;
using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Customer
            CreateMap<Customer, CreateCustomerRequest>().ReverseMap();
            CreateMap<Customer, CreateCustomerResponse>().ReverseMap();
            CreateMap<CustomerCategory, CustomerCategoryVM>().ReverseMap();
            CreateMap<UpdateCustomerRequest, Customer>().ForAllMembers(opts => opts.Condition((src, dest, srcMember, destMember) =>
            {
                if (srcMember != null && srcMember.GetType() == typeof(Guid) && (Guid)srcMember == Guid.Empty)
                {
                    return false; // Boş GUID'leri atama
                }
                // Diğer özellikler için atama yapma
                return srcMember != null;
                #region MyRegion
                //object destDefaultValue = null;
                //if (destMember != null)
                //{
                //    Type destType = destMember.GetType();
                //    if (destType.IsValueType)
                //    {
                //        destDefaultValue = Activator.CreateInstance(destType);
                //    }
                //    else
                //    {
                //        destDefaultValue = null;
                //    }
                //}
                //bool destinationHasNoValue = Object.Equals(destMember, destDefaultValue);
                //return destinationHasNoValue; 
                #endregion
            }));
            CreateMap<Customer, UpdateCustomerResponse>().ReverseMap();
            #endregion

            #region CustomerContact

            CreateMap<CustomerContact, CreateCustomerContactRequest>().ReverseMap();
            CreateMap<CustomerContact, CreateCustomerContactResponse>().ReverseMap();
            CreateMap<UpdateCustomerContactRequest, CustomerContact>().ForAllMembers(opts => opts.Condition((src, dest, srcMember, destMember) =>
            {
                if (srcMember != null && srcMember.GetType() == typeof(Guid) && (Guid)srcMember == Guid.Empty)
                {
                    return false; // Boş GUID'leri atama
                }
                return srcMember != null;
            
            }));
            CreateMap<CustomerContact, UpdateCustomerContactResponse>().ReverseMap();
            CreateMap<CustomerContact, CustomerContactListVM>().ReverseMap();
           
            #endregion

            #region CustomerGroup

            CreateMap<CustomerGroup, CreateCustomerGroupRequest>().ReverseMap();
            CreateMap<CustomerGroup, CreateCustomerGroupResponse>().ReverseMap();
            CreateMap<UpdateCustomerGroupRequest, CustomerGroup>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<CustomerGroup, UpdateCustomerGroupResponse>().ReverseMap();
            #endregion

            #region CustomerKind
            CreateMap<CustomerKind, CreateCustomerKindRequest>().ReverseMap();
            CreateMap<CustomerKind, CreateCustomerKindResponse>().ReverseMap();
            CreateMap<UpdateCustomerKindRequest, CustomerKind>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<CustomerKind, UpdateCustomerKindResponse>().ReverseMap();
            #endregion

            #region CustomerSource
            CreateMap<CustomerSource, CreateCustomerSourceRequest>().ReverseMap();
            CreateMap<CustomerSource, CreateCustomerSourceResponse>().ReverseMap();
            CreateMap<UpdateCustomerSourceRequest, CustomerSource>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<CustomerSource, UpdateCustomerSourceResponse>().ReverseMap();
            #endregion

            #region CustomerStatus
            CreateMap<CustomerStatus, CreateCustomerStatusRequest>().ReverseMap();
            CreateMap<CustomerStatus, CreateCustomerStatusResponse>().ReverseMap();
            CreateMap<UpdateCustomerStatusRequest, CustomerStatus>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<CustomerStatus, UpdateCustomerStatusResponse>().ReverseMap();
            #endregion

            #region CustomerType
            CreateMap<CustomerType, CreateCustomerTypeRequest>().ReverseMap();
            CreateMap<CustomerType, CreateCustomerTypeResponse>().ReverseMap();
            CreateMap<UpdateCustomerTypeRequest, CustomerType>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<CustomerType, UpdateCustomerTypeResponse>().ReverseMap();
            #endregion

            #region CustomerCategory
            CreateMap<CustomerCategory, CreateCustomerCategoryRequest>().ReverseMap();
            CreateMap<CustomerCategory, CreateCustomerCategoryResponse>().ReverseMap();
            CreateMap<CustomerCategoryCreateVM, CustomerCategory>().ReverseMap();
            //CreateMap<CreateCustomerCategoryRequest, CustomerCategory>().ReverseMap();
            CreateMap<UpdateCustomerCategoryRequest, CustomerCategory>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<CustomerCategory, UpdateCustomerCategoryResponse>().ReverseMap();
            #endregion

            #region CustomerAddress
            CreateMap<CustomerAddress, CreateCustomerAddressRequest>().ReverseMap();
            CreateMap<CustomerAddress, CreateCustomerAddressResponse>().ReverseMap();
            CreateMap<UpdateCustomerAddressRequest, CustomerAddress>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<CustomerAddress, UpdateCustomerAddressResponse>().ReverseMap();
            CreateMap<CustomerAddress, CustomerAddressCreateVM>().ReverseMap();
            CreateMap<CustomerAddressVM, CustomerAddress>().ReverseMap();
            #endregion

            #region CustomerSector
            CreateMap<CustomerSector, CreateCustomerSectorRequest>().ReverseMap();
            CreateMap<CustomerSector, CreateCustomerSectorResponse>().ReverseMap();
            CreateMap<UpdateCustomerSectorRequest, CustomerSector>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<CustomerSector, UpdateCustomerSectorResponse>().ReverseMap();
            #endregion

            #region CustomerActivity
            CreateMap<CustomerActivity, CreateCustomerActivityRequest>().ReverseMap();
            CreateMap<CustomerActivity, CreateCustomerActivityResponse>().ReverseMap();
            CreateMap<UpdateCustomerActivityRequest, CustomerActivity>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<CustomerActivity, UpdateCustomerActivityResponse>().ReverseMap();
            #endregion

            #region CustomerActivityKind
            CreateMap<CustomerActivityKind, CreateCustomerActivityKindRequest>().ReverseMap();
            CreateMap<CustomerActivityKind, CreateCustomerActivityKindResponse>().ReverseMap();

            #endregion

            #region CustomerActivityStatus
            CreateMap<CustomerActivityStatus, CreateCustomerActivityStatusRequest>().ReverseMap();
            CreateMap<CustomerActivityStatus, CreateCustomerActivityStatusResponse>().ReverseMap();

            #endregion

            #region CustomerActivitySubject
            CreateMap<CustomerActivitySubject, CreateCustomerActivitySubjectRequest>().ReverseMap();
            CreateMap<CustomerActivitySubject, CreateCustomerActivitySubjectResponse>().ReverseMap();

            #endregion

            #region CustomerActivityTeam
            CreateMap<CustomerActivityTeam, CreateCustomerActivityTeamRequest>().ReverseMap();
            CreateMap<CustomerActivityTeam, CreateCustomerActivityTeamResponse>().ReverseMap();
            CreateMap<CustomerActivityTeam, CustomerActivityTeamVM>().ReverseMap();

            #endregion

            #region CustomerActivityType
            CreateMap<CustomerActivityType, CreateCustomerActivityTypeRequest>().ReverseMap();
            CreateMap<CustomerActivityType, CreateCustomerActivityTypeResponse>().ReverseMap();

            #endregion

            #region CustomerOffer
            CreateMap<CustomerOffer, CreateCustomerOfferRequest>().ReverseMap();
            CreateMap<CustomerOffer, CreateCustomerOfferResponse>().ReverseMap();

            #endregion

            #region CustomerProject
            CreateMap<CustomerProject, CreateCustomerProjectRequest>().ReverseMap();
            CreateMap<CustomerProject, CreateCustomerProjectResponse>().ReverseMap();

            #endregion

            #region CustomerSubject
            CreateMap<CustomerSubject, CreateCustomerSubjectRequest>().ReverseMap();
            CreateMap<CustomerSubject, CreateCustomerSubjectResponse>().ReverseMap();

            #endregion

            #region Opportunity
            CreateMap<Opportunity, CreateOpportunityRequest>().ReverseMap();
            CreateMap<Opportunity, CreateOpportunityResponse>().ReverseMap();
            CreateMap<UpdateOpportunityRequest, Opportunity>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Opportunity, UpdateOpportunityResponse>().ReverseMap();

            #endregion

            #region OpportunityReference
            CreateMap<OpportunityReference, CreateOpportunityReferenceRequest>().ReverseMap();
            CreateMap<OpportunityReference, CreateOpportunityReferenceResponse>().ReverseMap();
            CreateMap<UpdateOpportunityReferenceRequest, OpportunityReference>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<OpportunityReference, UpdateOpportunityReferenceResponse>().ReverseMap();

            #endregion

            #region OpportunitySector
            CreateMap<OpportunitySector, CreateOpportunitySectorRequest>().ReverseMap();
            CreateMap<OpportunitySector, CreateOpportunitySectorResponse>().ReverseMap();
            CreateMap<UpdateOpportunitySectorRequest, OpportunitySector>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<OpportunitySector, UpdateOpportunitySectorResponse>().ReverseMap();

            #endregion

            #region OpportunityStage
            CreateMap<OpportunityStage, CreateOpportunityStageRequest>().ReverseMap();
            CreateMap<OpportunityStage, CreateOpportunityStageResponse>().ReverseMap();
            CreateMap<UpdateOpportunityStageRequest, OpportunityStage>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<OpportunityStage, UpdateOpportunityStageResponse>().ReverseMap();

            #endregion

            //#region SolutionOffer
            //CreateMap<SolutionOffer, CreateOpportunityStageRequest>().ReverseMap();
            //CreateMap<SolutionOffer, CreateOpportunityStageResponse>().ReverseMap();
            //CreateMap<UpdateOpportunityStageRequest, SolutionOffer>().ForAllMembers(opts =>
            //{
            //    opts.Condition((src, dest, srcMember) => srcMember != null);
            //});
            //CreateMap<OpportunityStage, UpdateOpportunityStageResponse>().ReverseMap();

            //#endregion

            #region CustomerRepresentative
            CreateMap<CustomerRepresentative, CreateCustomerRepresentativeRequest>().ReverseMap();
            CreateMap<CustomerRepresentative, CreateCustomerRepresentativeResponse>().ReverseMap();
            CreateMap<UpdateCustomerRepresentativeRequest, CustomerRepresentative>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<CustomerRepresentative, UpdateCustomerRepresentativeResponse>().ReverseMap();

            #endregion

            #region Users
            CreateMap<Users, CreateUsersRequest>().ReverseMap();
            CreateMap<Users, CreateUsersResponse>().ReverseMap();
            CreateMap<UpdateUsersRequest, Users>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Users, UpdateUsersResponse>().ReverseMap();

            #endregion

        }
    }
}