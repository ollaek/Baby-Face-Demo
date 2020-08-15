using BabyFace.Domain.Model.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.UserProfile
{
    public class UserProfileProperties
    {
        public string FullName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Phone { get; set; }
        public string UserId { get; set; }
        public Gender Gender { get; set; }
        public string ProfilePicName { get; set; }
        public string ProfilePicPath { get; set; }
      


    }

  public class AccountTypeViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
  }
}
