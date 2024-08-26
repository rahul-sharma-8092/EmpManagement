using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpManagement
{
    public partial class Setup2FA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSetup2FA_Click(object sender, EventArgs e)
        {
            string userName = "Rohan Sharma";

            string secretKey = BAL.GoogleAuthenticator.GenerateKey(); // Store this to DataBase with Encrypted
            Session["SecretKey"] = secretKey;


            string qrCodeUrl = BAL.GoogleAuthenticator.GenerateQrCodeUrl(userName, secretKey);

            qrCodeImage.Visible = true;
            qrCodeImage.ImageUrl = qrCodeUrl;
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            string otp = txtOTP.Text;
            string secretKey = Session["SecretKey"].ToString();

            bool IsVerified = BAL.GoogleAuthenticator.ValidateCode(secretKey, otp);

            if (IsVerified)
            {
                resultLabel.Text = "Verification successful!";
                resultLabel.Style.Add("color", "green");
            }
            else
            {
                resultLabel.Text = "Invalid code, please try again.";
                resultLabel.Style.Add("color", "red");
            }
        }
    }
}