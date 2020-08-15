using System;
using System.Configuration;
using System.Security.Cryptography;

namespace BabyFace.Domain.Model.Helpers
{
   public static class ConfigurationHelper
    {
        public static string GetConfig(string key)
        {
            return ConfigurationManager.AppSettings[key] != null ? ConfigurationManager.AppSettings[key].ToString().Trim() : null;
        }
        public static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);
        }
    }
}
