using TwoFactorAuthNet;

namespace BAL
{
    public static class GoogleAuthenticator
    {
        // Install Package -> TwoFactorAuth.Net
        private static TwoFactorAuth tfa = new TwoFactorAuth("EmpManagement-Rahul-Sharma");

        public static string GenerateKey()
        {
            return tfa.CreateSecret(160);
        }

        public static string GenerateQrCodeUrl(string userEmail, string secretKey)
        {
            return tfa.GetQrCodeImageAsDataUri(userEmail, secretKey, 300);
        }

        public static bool ValidateCode(string secretKey, string code)
        {
            return tfa.VerifyCode(secretKey, code, 0);
        }
    }
}
