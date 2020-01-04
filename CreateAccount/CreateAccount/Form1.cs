using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CreateAccount.Validator;
using FluentValidation.Results;
namespace CreateAccount
{
    public partial class Form1 : Form
    {
        BindingList<string> errors = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
            lboxError.DataSource = errors;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            errors.Clear();
            //Sau khi validation xong thì tạo tài khoản
            bool geder = true;// Male as default
            if (radioMale.Checked == false)
            {
                geder = false;
            }
            UserAccount userAccount = new UserAccount(txtFirstName.Text, txtLastName.Text, txtTelephone.Text, txtNewPassword.Text, dtpBirthday.Value, geder, txtWebsite.Text);

            //chổ này ta thực hiện các công đoạn validation cho các input

            //Validate my data
            UserValidator validator = new UserValidator();

            ValidationResult results = validator.Validate(userAccount);
            if(results.IsValid == false)
            {
                foreach(ValidationFailure failure in results.Errors)
                {
                    errors.Add(failure.ErrorMessage);
                }
                return;
            }

             MessageBox.Show("Tạo tài khoản thành công!");
             //MessageBox.Show(userAccount.printAccount());
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
