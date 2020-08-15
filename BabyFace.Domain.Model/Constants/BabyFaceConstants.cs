namespace BabyFace.Domain.Model.Constants
{
  public class BabyFaceConstants
  {
    public const string UserRoleName = "user";
    public const string AdminRoleName = "admin";
    public const string ApiSuccessMessage = "Success";
    public const string DomainEntitiesAssemblyName = "BabyFace.Domain.Model";
    public const string DomainEntitiesNamespace = "BabyFace.Domain.Model.Models.Entities";
        public class ValidationErrorKey
        {
            public const string PasswordLength = "InvalidPasswordFormat";
            public const string MailFormat = "InvalidEmailFormat";
            public const string PasswordMatching = "PasswordMatchingFailed";
        }
    }

}
