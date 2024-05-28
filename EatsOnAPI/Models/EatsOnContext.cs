using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EatsOnAPI.Models;

namespace EatsOnAPI.Models
{
    public partial class EatsOnContext : DbContext
    {
        public EatsOnContext()
        {
        }

        public EatsOnContext(DbContextOptions<EatsOnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Component> Components { get; set; } = null!;
        public virtual DbSet<DayPlan> DayPlans { get; set; } = null!;
        public virtual DbSet<Dish> Dishes { get; set; } = null!;
        public virtual DbSet<DishComponent> DishComponents { get; set; } = null!;
        public virtual DbSet<Favourite> Favourites { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Logss> Logsses { get; set; } = null!;
        public virtual DbSet<PartDay> PartDays { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<RecipeRequest> RecipeRequests { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserQuestion> UserQuestions { get; set; } = null!;
        public virtual DbSet<Vitamin> Vitamins { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.NameCategory)
                    .HasName("PK_name_category");

                entity.ToTable("Category");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_category");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.HasKey(e => e.NumberComponent)
                    .HasName("PK_number_component");

                entity.Property(e => e.NumberComponent).HasColumnName("number_component");

                entity.Property(e => e.CountComponent).HasColumnName("count_component");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NameComponent)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_component");
            });

            modelBuilder.Entity<RequestIngredient>(entity =>
            {
                entity.HasKey(e => e.IDRequestIngredient)
                    .HasName("PK_RequestIngredient");

                entity.Property(e => e.IDRequestIngredient).HasColumnName("ID_RequestIngredient");

                entity.Property(e => e.count).HasColumnName("count");

                entity.Property(e => e.RequestId).HasColumnName("Request_ID");

                entity.Property(e => e.name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

            });

            modelBuilder.Entity<DayPlan>(entity =>
            {
                entity.HasKey(e => e.NumberPlan)
                    .HasName("PK_number_plan");

                entity.ToTable("Day_plan");

                entity.Property(e => e.NumberPlan).HasColumnName("number_plan");

                entity.Property(e => e.ArticleDish).HasColumnName("article_dish");

                entity.Property(e => e.CountDish).HasColumnName("count_dish");

                entity.Property(e => e.DateEating)
                    .HasColumnType("date")
                    .HasColumnName("date_eating");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdUser).HasColumnName("ID_user");

                entity.Property(e => e.NamePart)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_part");
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.HasKey(e => e.ArticleDish)
                    .HasName("PK_article_dish");

                entity.ToTable("Dish");

                entity.Property(e => e.ArticleDish).HasColumnName("article_dish");

                entity.Property(e => e.Coast)
                    .HasColumnType("decimal(28, 2)")
                    .HasColumnName("coast");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DescriptionDish)
                    .IsUnicode(false)
                    .HasColumnName("description_dish");

                entity.Property(e => e.ImageDish)
                    .HasColumnType("image")
                    .HasColumnName("image_dish");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_category");

                entity.Property(e => e.NameDish)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name_dish");

                entity.Property(e => e.NameProperty)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_property");

                entity.Property(e => e.TimeCook)
                    .HasColumnType("decimal(28, 2)")
                    .HasColumnName("time_cook");

                entity.Property(e => e.CuisineTypeID)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CuisineTypeID");

                entity.Property(e => e.DietTypeID)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DietTypeID");

                entity.Property(e => e.MealTimeID)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MealTimeID");

                entity.Property(e => e.Calories)
                    .IsUnicode(false)
                    .HasColumnName("Calories");
            });

            modelBuilder.Entity<DishComponent>(entity =>
            {
                entity.HasKey(e => e.Number)
                    .HasName("PK_number");

                entity.ToTable("DishComponent");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.ArticleDish).HasColumnName("article_dish");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NumberComponent).HasColumnName("number_component");

            });

            modelBuilder.Entity<Favourite>(entity =>
            {
                entity.HasKey(e => e.NumberFavourite)
                    .HasName("PK_number_favourite");

                entity.ToTable("Favourite");

                entity.Property(e => e.NumberFavourite).HasColumnName("number_favourite");

                entity.Property(e => e.ArticleDish).HasColumnName("article_dish");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdUser).HasColumnName("ID_user");

            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.NumberFeedback)
                    .HasName("PK_number_feedback");

                entity.ToTable("Feedback");

                entity.Property(e => e.NumberFeedback).HasColumnName("number_feedback");

                entity.Property(e => e.Advantages)
                    .IsUnicode(false)
                    .HasColumnName("advantages");

                entity.Property(e => e.ArticleDish).HasColumnName("article_dish");

                entity.Property(e => e.DateFeedback)
                    .HasColumnType("date")
                    .HasColumnName("date_feedback");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Disadvantages)
                    .IsUnicode(false)
                    .HasColumnName("disadvantages");

                entity.Property(e => e.IdUser).HasColumnName("ID_user");

                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(28, 2)")
                    .HasColumnName("rating");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.NameIngredient)
                    .HasName("PK_name_ingredient");

                entity.Property(e => e.NameIngredient)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_ingredient");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.ImageIngredient)
                    .HasColumnType("image")
                    .HasColumnName("image_ingredient");

                entity.Property(e => e.NameProperty)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_property");

                entity.Property(e => e.NameVitamin)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_vitamin");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.NumberLog)
                    .HasName("PK_number_log");

                entity.Property(e => e.NumberLog).HasColumnName("number_log");

                entity.Property(e => e.DateLog)
                    .HasColumnType("date")
                    .HasColumnName("date_log");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IdUser).HasColumnName("ID_user");

            });

            modelBuilder.Entity<Logss>(entity =>
            {
                entity.ToTable("Logss");

                entity.Property(e => e.Level)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<PartDay>(entity =>
            {
                entity.HasKey(e => e.NamePart)
                    .HasName("PK_Name_part");

                entity.ToTable("Part_day");

                entity.Property(e => e.NamePart)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Name_part");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<CuisineTypes>(entity =>
            {
                entity.HasKey(e => e.CuisineName)
                   .HasName("PK_CuisineName");

                entity.ToTable("CuisineTypes");
                entity.Property(e => e.CuisineName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CuisineName");
            });


            modelBuilder.Entity<DietTypes>(entity =>
            {
                entity.HasKey(e => e.DietTypeName)
                  .HasName("PK_DietTypeName");
                entity.ToTable("DietTypes");
                entity.Property(e => e.DietTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DietTypeName");
            });

            modelBuilder.Entity<MealTimes>(entity =>
            {
                entity.HasKey(e => e.MealTimeName)
                  .HasName("PK_MealTimeName");
                entity.ToTable("MealTimes");
                entity.Property(e => e.MealTimeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MealTimeName");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.NameProperty)
                    .HasName("PK_name_property");

                entity.ToTable("Property");

                entity.Property(e => e.NameProperty)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_property");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DescriptionProperty)
                    .IsUnicode(false)
                    .HasColumnName("description_property");
            });

            modelBuilder.Entity<RecipeRequest>(entity =>
            {
                entity.HasKey(e => e.IdRecipeRequest);

                entity.ToTable("Recipe_request");

                entity.Property(e => e.IdRecipeRequest).HasColumnName("ID_Recipe_request");

                entity.Property(e => e.Coast)
                    .HasColumnType("decimal(28, 2)")
                    .HasColumnName("coast");

                entity.Property(e => e.DescriptionRecipe)
                    .IsUnicode(false)
                    .HasColumnName("description_recipe");

                entity.Property(e => e.ImageRecipe)
                    .IsUnicode(false)
                    .HasColumnName("image_recipe");

                entity.Property(e => e.NameRecipe)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_recipe");

                entity.Property(e => e.UserId).HasColumnName("User_ID");
                entity.Property(e => e.TimeCook)
                   .HasColumnType("decimal(28, 2)")
                   .HasColumnName("time_cook");

                entity.Property(e => e.status)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("status");

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.NameRole)
                    .HasName("PK_name_role");

                entity.ToTable("Role");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_role");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK_ID_user");

                entity.ToTable("User");

                entity.HasIndex(e => e.Nickname, "UQ_nickname")
                    .IsUnique();

                entity.HasIndex(e => e.NumberPhone, "UQ_number_phone")
                    .IsUnique();

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_user");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Image)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_role");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nickname");

                entity.Property(e => e.NumberPhone)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("number_phone");

                entity.Property(e => e.Password)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Salt)
                    .IsUnicode(false)
                    .HasColumnName("salt");
            });

            modelBuilder.Entity<UserQuestion>(entity =>
            {
                entity.HasKey(e => e.IdUserQuestion);

                entity.ToTable("User_question");

                entity.Property(e => e.IdUserQuestion).HasColumnName("ID_User_question");

                entity.Property(e => e.DescriptionQuestion)
                    .IsUnicode(false)
                    .HasColumnName("description_question");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");


                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.Answer)
       .IsUnicode(false)  // Assuming you want to keep consistency with other string properties.
       .HasColumnName("answer")
       .HasMaxLength(255)  // Explicitly stating there is no limit, but this is optional as strings are unlimited by default.
       .IsRequired(false);  // Specifies that the column can contain null values.

            });

            modelBuilder.Entity<Vitamin>(entity =>
            {
                entity.HasKey(e => e.NameVitamin)
                    .HasName("PK_name_vitamin");

                entity.Property(e => e.NameVitamin)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_vitamin");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UsefulProperties)
                    .IsUnicode(false)
                    .HasColumnName("useful_properties");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<EatsOnAPI.Models.RequestIngredient>? RequestIngredient { get; set; }

        public DbSet<EatsOnAPI.Models.DietTypes>? DietTypes { get; set; }

        public DbSet<EatsOnAPI.Models.CuisineTypes>? CuisineTypes { get; set; }

        public DbSet<EatsOnAPI.Models.MealTimes>? MealTimes { get; set; }
    }
}
