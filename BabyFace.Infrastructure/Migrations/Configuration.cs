using BabyFace.Domain.Model.Constants;
using BabyFace.Domain.Model.Enums;
using BabyFace.Domain.Model.Models.Entities;
using System.Collections.Generic;
using System.Configuration;
using Gender = BabyFace.Domain.Model.Models.Entities.Gender;

namespace BabyFace.Infrastructure.Migrations
{

  using System;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<BabyFace.Infrastructure.BabyFaceEntities>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(BabyFace.Infrastructure.BabyFaceEntities context)
    {
      

      if (!context.EmailActions.Any())
      {
        context.EmailActions.AddRange(new List<EmailAction>
        {
          new EmailAction { Name= "ResetPassword"},
          new EmailAction { Name = "EmailConfirmation"},

        });
      }

      if (!context.EmailConfigurations.Any())
      {
        context.EmailConfigurations.AddRange(new List<EmailConfiguration>
        {
          new EmailConfiguration { EmailActionId= 2,LanguageId=1,FileUrl= "~/EmailTemplates/EmailConfirmation_BabyFace.html",FileName="EmailConfirmation_BabyFace.html"},
          new EmailConfiguration { EmailActionId= 1,LanguageId=1,FileUrl= "~/EmailTemplates/ResetPassword.html",FileName="ResetPassword.html"}

        });
      }

      if (!context.Genders.Any())
      {
        context.Genders.AddRange(new List<Gender>
        {
          new Gender {Id = 1, Name = "Male"},
          new Gender {Id = 2, Name = "Female"}
        });
      }

 
     

      }
      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data.
    }
  }

