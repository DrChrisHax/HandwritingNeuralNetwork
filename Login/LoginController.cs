using HandwritingNeuralNetwork.AIModel;
using HandwritingNeuralNetwork.App;
using HandwritingNeuralNetwork.Models;
using HandwritingNeuralNetwork.Shared;
using System;
using System.Security.Cryptography;
using System.Text;

namespace HandwritingNeuralNetwork.Login
{
    public class LoginController : ControllerBase<IViewLogin>
    {

        public event EventHandler LoginSuccessful;

        public LoginController(IViewLogin view) : base(view)
        {

        }

        #region Controller Actions

        public void CreateAccount()
        {
            String username = View.UserName;
            String password = encryptPassword(View.Password + View.UserName);

            // Doesn't allow empty usernames
            if (string.IsNullOrWhiteSpace(username))
            {
                View.ShowWarningMessage("This username cannot be blank.");
                return;
            }

            // Doesn't allow empty passwords
            if (string.IsNullOrWhiteSpace(View.Password)) // Check original input, not hashed password
            {
                View.ShowWarningMessage("The password cannot be blank.");
                return;
            }

            SystemUser su = new SystemUser();
            su.LoadByUsername(username);

            
            if (su.ID_SystemUser > 0)
            {
                View.ShowWarningMessage("This username is already taken.");
            }
            else
            {
                su.UserName = username;
                su.Password = password;
                su.DateCreated = DateTime.Now;
                su.IsAdmin = false;
                su.AddRecord();

                AppSession.systemUser = su;

                //Login with the new account
                LoginSuccessful?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool Login()
        {
            String username = View.UserName;
            String password = encryptPassword(View.Password + View.UserName);

            SystemUser su = new SystemUser();
            su.LoadByUsername(username);

            if(su.ID_SystemUser <= 0 || string.Compare(su.Password, password) != 0)
            {
                View.ShowWarningMessage("Invalid username or password.");
            } else
            {
                //Login Success!
                AppSession.systemUser = su;

                LoginSuccessful?.Invoke(this, EventArgs.Empty);
                return true;
            }
            return false;
        }

        #endregion

        #region Support Methods

        private string encryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Convert byte array to a hex string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2")); // Convert to hexadecimal
                }
                return builder.ToString();
            }
        }


        #endregion





    }
}
