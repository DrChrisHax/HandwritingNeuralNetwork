using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork.Login
{
    public partial class ctlLogin : UserControl, IViewLogin
    {

        private bool _newAccount = false;
        private LoginController _controller;

        public ctlLogin()
        {
            InitializeComponent();
            txtUsername.KeyDown += TextBox_KeyDown;
            txtPassword.KeyDown += TextBox_KeyDown;
        }


        #region IViewLogin

        public string UserName => txtUsername.Text;

        public string Password => txtPassword.Text;

        public bool NewAccount => _newAccount;

        public UserControl GetControlSurface()
        {
            return this;
        }

        public void SetController(object controller)
        {
           _controller = (LoginController)controller;
        }

        public void ShowWarningMessage(string message)
        {
            lblWarning.Text = message;

            //Show for three seconds then hide
            Task.Run(async () =>
            {
                if (lblWarning.InvokeRequired)
                {
                    lblWarning.Invoke(new Action(() => lblWarning.Visible = true));
                }
                else
                {
                    lblWarning.Visible = true;
                }

                await Task.Delay(3000);

                if (lblWarning.InvokeRequired)
                {
                    lblWarning.Invoke(new Action(() => lblWarning.Visible = false));
                }
                else
                {
                    lblWarning.Visible = false;
                }
            });
        }


        #endregion

        #region Events

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(_newAccount)
            {
                if(String.Compare(txtPassword.Text, txtConfirmPassword.Text) != 0)
                {
                    this.ShowWarningMessage("The passwords do not match!");
                    return;
                }
                _controller.CreateAccount();
            } else
            {
                if (_controller.Login())
                {
                    Clear(); // Clear UI on succesful login
                }
            }
        }

        private void lnkCreateAccount_Click(object sender, EventArgs e)
        {
            if (_newAccount == false)
            {
                //Switch to Create Account Mode
                lblConfirmPassword.Visible = true;
                txtConfirmPassword.Visible = true;

                btnLogin.Text = "Create Account";
                lnkCreateAccount.Text = "Go Back to Login";

                lblTitle.Text = "Create Account";

                _newAccount = true;
            }
            else
            {
                //Go back to Login Mode
                lblConfirmPassword.Visible = false;
                txtConfirmPassword.Visible = false;

                lblTitle.Text = "Login";

                btnLogin.Text = "Login";
                lnkCreateAccount.Text = "Create Account";

                _newAccount = false;
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    _controller.Login(); // Triggers the same logic as clicking the login button
                    
                   
                    break;
            }
        }


        #endregion

        #region Support Methods

        private void Clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }


        #endregion


    }
}
