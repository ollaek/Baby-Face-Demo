using BabyFace.Domain.Model.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;

namespace BabyFace.Infrastructure
{
  using System.Data.Entity;

  public class BabyFaceEntities : DbContext
  {
    public BabyFaceEntities()
        : base("name=BabyFaceEntities")
    {
      //   Configuration.ProxyCreationEnabled = false;
    }

    public static BabyFaceEntities Create()
    {
      return new BabyFaceEntities();
    }

   
    public virtual DbSet<EnvironmentResource> EnvironmentResources { get; set; }
        public virtual DbSet<BabyFaceUser> BabyFaceUsers { get; set; }
        public virtual DbSet<BabyFaceUserRole> BabyFaceUserRoles { get; set; }

        public virtual DbSet<ImageType> ImageTypes { get; set; }
   public virtual DbSet<BabyFaceUserClaim> BabyFaceUserClaims { get; set; }
    public virtual DbSet<BabyFaceUserLogin> BabyFaceUserLogins { get; set; }
   
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    public virtual DbSet<RoleForBabyFaceUser> RoleForBabyFaceUsers { get; set; }
    public virtual DbSet<Status> Status { get; set; }
    public virtual DbSet<Gender> Genders { get; set; }
    public virtual DbSet<ResponseMessageResource> ResponseMessageResources { get; set; }
    public virtual DbSet<EmailAction> EmailActions { get; set; }
    public virtual DbSet<EmailConfiguration> EmailConfigurations { get; set; }
    public virtual DbSet<BabyFaceRefreshTokenClientMaster> RefreshTokenClientMasters { get; set; }
    public virtual DbSet<BabyFaceRefreshToken> BabyFaceRefreshTokens { get; set; }
        public virtual DbSet<BasicShape> BasicShapes { get; set; }
        public virtual DbSet<BookOrder> BookOrders { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<ClothesShape> ClothesShapes { get; set; }
        public virtual DbSet<EyesShape> EyesShapes { get; set; }
        public virtual DbSet<FaceAdd> FaceAdds { get; set; }
        public virtual DbSet<Glass> Glasses { get; set; }
        public virtual DbSet<HairColor> HairColors { get; set; }
        public virtual DbSet<HairCut> HairCuts { get; set; }
        public virtual DbSet<SkinColor> SkinColors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    
      var user = modelBuilder
    .Entity<BabyFaceUser>().HasKey(s => s.Id)
    .ToTable("BabyFaceUser", "dbo");

      user.Property(u => u.UserName)
          .IsRequired()
          .HasMaxLength(256)
          .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = true }));
      user.Property(u => u.Email)
          .HasMaxLength(256)
          .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserEmailIndex") { IsUnique = true }));

      user.Property(u => u.PhoneNumber)
        .HasMaxLength(20)
        .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("PhoneNumberIndex") { IsUnique = true }));

      user.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
      user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
      user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
      user.Property(u => u.ReferralCode).HasMaxLength(50).HasColumnAnnotation("Index",
        new IndexAnnotation(new IndexAttribute("refUnique") { IsUnique = true }));
     
      modelBuilder.Entity<RoleForBabyFaceUser>()
          .HasKey(r => new { r.UserId, r.RoleId })
          .ToTable("RoleForBabyFaceUser", "dbo");

      modelBuilder.Entity<BabyFaceUserLogin>()
          .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
          .ToTable("BabyFaceUserLogin", "dbo");

      modelBuilder.Entity<BabyFaceUserClaim>()
          .ToTable("BabyFaceUserClaim", "dbo");

     
    }

    protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry,
        IDictionary<object, object> items)
    {
      if (entityEntry != null && entityEntry.State == EntityState.Added)
      {
        var errors = new List<DbValidationError>();
        var user = entityEntry.Entity as BabyFaceUser;
        //check for uniqueness of user name and email
        if (user != null)
        {
          if (BabyFaceUsers.Any(u => String.Equals(u.UserName, user.UserName)))
          {
            errors.Add(new DbValidationError("User",
                string.Format(CultureInfo.CurrentCulture, "DuplicateUserName")));
          }
          if (BabyFaceUsers.Any(u => String.Equals(u.Email, user.Email)))
          {
            errors.Add(new DbValidationError("User",
                String.Format(CultureInfo.CurrentCulture, "DuplicateEmail")));
          }
        }
        else
        {
          var role = entityEntry.Entity as BabyFaceUserRole;
          //check for uniqueness of role name
          if (role != null && BabyFaceUserRoles.Any(r => String.Equals(r.Name, role.Name)))
          {
            errors.Add(new DbValidationError("Role",
                String.Format(CultureInfo.CurrentCulture, "RoleAlreadyExists")));
          }
        }
        if (errors.Any())
        {
          return new DbEntityValidationResult(entityEntry, errors);
        }
      }
      return base.ValidateEntity(entityEntry, items);
    }
  }
}
