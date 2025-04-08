using FluentValidation;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Validations.HeroValidations;

public class UpdateHeroDtoValidator :AbstractValidator<UpdateHeroDto>
{
    public UpdateHeroDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty.");
        RuleFor(x => x.SubTitle).NotEmpty().WithMessage("SubTitle cannot be empty.");
        RuleFor(x => x.BackgroundImageUrl).NotEmpty().WithMessage("BackgroundImageUrl cannot be empty.");
    }
}
