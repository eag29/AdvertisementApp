using EmirAliGirgin.AdvertisementApp2.UI.Models;
using FluentValidation;

namespace EmirAliGirgin.AdvertisementApp2.UI.ValidationRules
{
    public class UserCreateValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Lütfen bir isim giriniz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen bir soyisim giriniz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Lütfen bir kullanıcı adı giriniz");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı adı 3 karakterden az olamaz");
            RuleFor(x => x.Username).MaximumLength(10).WithMessage("Kullanıcı adı 10 karakterden fazla olamaz");
            RuleFor(x => x.Password).MinimumLength(4).WithMessage("Şifre minimum 4 karakterden oluşmalıdır.");
            RuleFor(x => x.Password).MaximumLength(10).WithMessage("Şifre maksimum 10 karakterden oluşmalıdır.");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Şifreler uyuşmuyor");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Lütfen bir telefon numarası giriniz");
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Lütfen bir cinsiyet seçiniz");
            RuleFor(x => new
            {
                x.Username,
                x.FirstName
            }).Must(x => CanNotFirstName(x.Username, x.FirstName)).WithMessage("Kullanıcı adı, adınızı içeremez").When(x => x.Username != null && x.FirstName != null);
        }
        private bool CanNotFirstName(string username, string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}
