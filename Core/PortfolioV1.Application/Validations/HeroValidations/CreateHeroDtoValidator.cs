using FluentValidation;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Validations.HeroValidations;

public class CreateHeroDtoValidator : AbstractValidator<CreateHeroDto>
{
    public CreateHeroDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty.");
        RuleFor(x => x.SubTitle).NotEmpty().WithMessage("SubTitle cannot be empty.");
        RuleFor(x => x.BackgroundImageUrl).NotEmpty().WithMessage("BackgroundImageUrl cannot be empty.");
    }   
}
