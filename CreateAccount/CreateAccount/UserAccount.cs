using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAccount
{
    public class UserAccount
    {
        public string FirstName;
        public string LastName;
        public string Telephone;
        public string NewPassword;
        public DateTime Birthday;
        public bool Gender;//true is Male, false is Female
        public string Website;
        public UserAccount(string firstName, string lastName, string tel, string newPassword, DateTime birthday, bool gender, string website)
        {
            FirstName = firstName;
            LastName = lastName;
            Telephone = tel;
            NewPassword = newPassword;
            Birthday = birthday;
            Gender = gender;
            Website = website;         
        }   
        
        public string printAccount()//cái này in ra cho có thôi, cho biết thông tin nhập vào đúng hay không

        {
           string acc = $"Họ và tên: {FirstName}" +
                        $"\nSố điện thoại: {Telephone}" +
                        $"\nMật khẩu: {NewPassword}" +
                        $"\nNgày sinh: {Birthday}" +
                        $"\nGiới tính: {Gender}" +
                        $"\nWebsite: {Website}";
            return acc;
        }
    }
}
