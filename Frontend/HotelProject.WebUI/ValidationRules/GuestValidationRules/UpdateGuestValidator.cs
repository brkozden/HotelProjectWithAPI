using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen En Az İki Karakter Giriniz.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim Alanı 50 Karakterden Fazla Olamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim Alanı Boş Geçilemez.");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Lütfen En Az İki Karakter Giriniz.");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Soyisim Alanı 50 Karakterden Fazla Olamaz.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir Alanı Boş Geçilemez.");
            RuleFor(x => x.City).MinimumLength(2).WithMessage("Lütfen En Az İki Karakter Giriniz.");
            RuleFor(x => x.City).MaximumLength(50).WithMessage("Şehir Alanı 50 Karakterden Fazla Olamaz.");
        }
    }
}
