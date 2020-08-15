using BabyFace.Domain.Model.Models.Entities;
using BabyFace.Domain.Model.ViewModels;
using BabyFace.Domain.Model.ViewModels.Identity;
using BabyFace.Domain.Model.ViewModels.BabyFaceUser;
using BabyFace.Domain.Model.ViewModels.UserProfile;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace BabyFace.Domain.Services.Contracts
{
  public interface IBabyFaceUserService
  {
    BabyFaceUser GetById(string id);
    BabyFaceUser GetByPhone(string msisdn);
    Task<BabyFaceUser> FindByIdAsync(string userId);
    Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
    Task ChangePasswordAsync(ChangePasswordBindingModel model);
    Task<IdentityResult> AddPasswordAsync(string userId, string password);
    Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);
    Task<IdentityResult> RemovePasswordAsync(string userId);
    Task<IdentityResult> RemoveLoginAsync(string userId, UserLoginInfo login);
    Task<BabyFaceUserProperties> Register(RegisterBindingModel user);
    Task<AccessTokenViewModel> ValidateRegistrationOtp(ValidateOtpViewModel model, OAuthAuthorizationServerOptions oAuthBearerOptions);
    Task<IdentityResult> CreateAsync(BabyFaceUser user);
    Task SendPasswordResetLink(string email);
    Task ResetPasswordAsync(ResetPasswordViewModel model);
    //Task<UserProfileProperties> GetProfile(string userId, int languageId);
    //Task ChangeEmail(ChangeEmailConfirmationInput model);
    //Task VerifyEmailChange(VerifyEmailChangeInput model);
    //Task ChangePhoneNumber(ChangePhoneNumberInput model);
    //Task CorrectPhoneNumber(CorrectPhoneNumberInput model);
    //Task VerifyPhoneNumberChange(VerifyPhoneNumberChangeInput model);
    Task<int> CommitAsync();
    void Update(BabyFaceUser item);
    Task<bool> SendPasswordResetSMS(string phone, int languageId);
    Task<BabyFaceUser> FindActiveByEmailAsync(
  string email,
  bool mustBeActive = true,
  bool throwIfNotActive = true,
  bool throwIfNotFound = true
);

    Task<BabyFaceUser> FindActiveByIdAsync(
      string userId,
      bool mustBeActive = true,
      bool throwIfNotActive = true,
      bool throwIfNotFound = true);
    Task<BabyFaceUser> FindActiveByPhoneAsync(
     string phone,
     bool mustBeActive = true,
     bool throwIfNotActive = true,
     bool throwIfNotFound = true);
    Task<VerifyPhoneNumberChangeInput> ValidateResetPasswordBySMSOtp(ValidateResetPasswordBySMSOtpViewModel model, OAuthAuthorizationServerOptions oAuthOptions);
    Task<BabyFaceUserInfo> FindByEmailOrMobileAsync(
           string identifier,
           bool mustBeActive = false,
           bool throwIfNotActive = true,
           bool throwIfNotFound = true
         );
    BabyFaceUser FindActiveById(
string userId,
bool mustBeActive = true,
bool throwIfNotActive = true,
bool throwIfNotFound = true);
    BabyFaceUser FindActiveByEmail(
  string userEmail,
  bool mustBeActive = true,
  bool throwIfNotActive = true,
  bool throwIfNotFound = true
);
    Task<string> UpdateProfilePic(string userId);
    IQueryable<BabyFaceUser> GetAll();
    Task<IdentityResult> DeleteUserByPhoneNumber(string phoneNumber);
    Task<AccessTokenViewModel> Login(LoginViewModel model, OAuthAuthorizationServerOptions oAuthBearerOptions);
    Task ResendRegistrationOtp(string email);
    Task<AccessTokenViewModel> UpdateProfile(UpdateUserBindingModel model, OAuthAuthorizationServerOptions oAuthBearerOptions);
    void DeleteFcmToken(string token);
    Task<int> GenerateReferralCodeForOldUsersAsync();
    Task<decimal> GetTotalSavings(string userId);

    Task<AccessTokenViewModel> RefreshUsingRefreshToken(RefreshExpiredAccessTokenViewModel model,
      OAuthAuthorizationServerOptions oAuthAuthorizationBearerOptions);

    Task<AccessTokenViewModel> ValidateOtpWithRefresh(ValidateOtpViewModel model,
      OAuthAuthorizationServerOptions oAuthBearerOptions);

    Task<AccessTokenViewModel> LoginWithRefresh(LoginViewModel model,
      OAuthAuthorizationServerOptions oAuthBearerOptions);
    Task<AccessTokenViewModel> UpdateProfileWithRefresh(UpdateUserBindingModel model,
      OAuthAuthorizationServerOptions oAuthBearerOptions);

    Task<RegisterationOtpInfoViewModel> GetRegisterationOtp(string phone);

    Task<RegisterationOtpInfoViewModel> GetResetPasswordOtp(string phone);
    void UpdateBulkUserAccountTypesToPaid(List<string> phoneNumbers);
    void UpdateBulkUserAccountTypesToRegular(List<string> phoneNumbers);
    Task<bool> IsActiveUserAsync(string mobileNumber);
    bool IsActiveUser(string mobileNumber);

    BabyFaceUser FindActiveByPhone(
      string phone,
      bool mustBeActive = true,
      bool throwIfNotActive = true,
      bool throwIfNotFound = true);

   
    Task LoginFailedChecksAsync(BabyFaceUser user);

  

    }
}
