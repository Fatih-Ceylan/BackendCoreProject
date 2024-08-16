using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.CustomerAddress.Update;

namespace GCrm.Application.Validators.CustomerAddress
{
    public class UpdateCustomerAddressRequestValidator : AbstractValidator<UpdateCustomerAddressRequest>
    {

        public UpdateCustomerAddressRequestValidator()
        {

            //RuleFor(c => c.CustomerId)
            // .NotEmpty()
            // .WithMessage("CustomerId cannot be empty.")
            // .MaximumLength(150)
            // .MinimumLength(1)
            // .WithMessage("Character length must be between 1 and 150.");

            //RuleFor(c => c.Address1)
            //.NotEmpty()
            //.WithMessage("Address1 cannot be empty.")
            //.MaximumLength(150)
            //.MinimumLength(1)
            //.WithMessage("Character length must be between 1 and 150.");

            //RuleFor(c => c.CountryId)
            //.NotEmpty()
            //.WithMessage("CountryId cannot be empty.")
            //.MaximumLength(150)
            //.MinimumLength(1)
            //.WithMessage("Character length must be between 1 and 150.");

            //RuleFor(c => c.CityId)
            //.NotEmpty()
            //.WithMessage("CityId cannot be empty.")
            //.MaximumLength(150)
            //.MinimumLength(1)
            //.WithMessage("Character length must be between 1 and 150.");

            //RuleFor(c => c.DistrictId)
            //.NotEmpty()
            //.WithMessage("DistrictId cannot be empty.")
            //.MaximumLength(150)
            //.MinimumLength(1)
            //.WithMessage("Character length must be between 1 and 150.");

          //  RuleFor(c => c.Email1)
          //.NotEmpty()
          //.WithMessage("Email1 cannot be empty.")
          //.MaximumLength(150)
          //.MinimumLength(1)
          //.WithMessage("Character length must be between 1 and 150.");

        }
    }
}
