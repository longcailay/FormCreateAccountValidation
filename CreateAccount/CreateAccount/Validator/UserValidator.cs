using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace CreateAccount.Validator
{
    public class UserValidator : AbstractValidator<UserAccount>
    {
      public UserValidator()
        {
            RuleFor(p => p.LastName) //cái ô họ
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Họ không được bỏ trống")
                .Length(2, 10).WithMessage("Độ dài họ trong khoản từ 2 đến 10")
                .Must(BeAValidName).WithMessage("Họ không được chứa kí tự đặc biệt");


            RuleFor(p => p.FirstName) //cái ô tên
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Tên không được bỏ trống")
                .Length(2, 10).WithMessage("Độ dài tên trong khoản từ 2 đến 10")
                .Must(BeAValidName).WithMessage("Tên không được chứa kí tự đặc biệt");


            RuleFor(p => p.Telephone)
                .NotEmpty().WithMessage("Số điện thoại không được bỏ trống")
                .Must(BeAValidTelephone).WithMessage("Số điện thoại không hợp lệ");

            RuleFor(p => p.NewPassword)
              .NotEmpty().WithMessage("Password không được bỏ trống")
              .Must(BeAValidPassword).WithMessage("Password không hợp lệ");

            RuleFor(p => p.Birthday) //nhỏ hơn 5 tuổi không cho tạo tài khoản
                .Must(BeAValidBirthday).WithMessage("Dưới 5 tuổi không cho tạo tài khoản");

           

            RuleFor(p => p.Website)
                .NotEmpty()
                .WithMessage("Địa chỉ Website không được bỏ trống!")
                .Must(BeAValidUrl)
                .WithMessage("Địa chỉ Website không hợp lệ");
        }
        protected bool BeAValidName(string name)
        {
            name = name.Replace("*", "");
            name = name.Replace("_", "");
            return name.All(Char.IsLetter);
        }
        
        protected bool BeAValidTelephone(string tel)
        {
            foreach(char c in tel)
            {
                if(!(c > '0' && c < '9'))
                {
                    return false;
                }
            }
            return true;
        }

        protected bool BeAValidPassword(string pass)// mật khẩu ít nhất 8 kí tự, chỉ gồm số (0-9), chữ hoa (A-Z) và chữ thường (a-z)
        {
            if(pass.Length < 8)
            {
                return false;
            }
            foreach(char c in pass)
            {
                if( !(c > '0' && c <'9') && !(c > 'a' && c < 'z') && !(c > 'A' && c < 'Z'))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool BeAValidUrl(string arg)//địa chỉ website hoặc đường dẫn file
        {
            Uri result;
            return Uri.TryCreate(arg, UriKind.Absolute, out result);
        }    


        protected bool BeAValidBirthday(DateTime date)// <5 tuổi k cho tạo tài khoản
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;
            if (dobYear < currentYear - 5) 
            {
                return true;
            }
            return false;
        }
    }
}
