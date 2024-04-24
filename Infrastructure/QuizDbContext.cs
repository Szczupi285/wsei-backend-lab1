using Infrastructure.EF;
using Infrastructure.EF.Nowy_folder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure
{
    public class QuizDbContext : IdentityDbContext<UserEntity, UserRole, int>
    {
        public DbSet<QuizEntity> Quizzes { get; set; }
        public DbSet<QuizItemEntity> QuizItems { get; set; }
        public DbSet<QuizItemUserAnswerEntity> UserAnswers { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"DATA SOURCE=NY-13\SQLEXPRESS;DATABASE=Lab1;Integrated Security=true;TrustServerCertificate=True", b => b.MigrationsAssembly("Web"));
            optionsBuilder.UseSqlServer(
                @"DATA SOURCE=NY-13\SQLEXPRESS;DATABASE=Lab1;Integrated Security=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuizItemUserAnswerEntity>()
                .HasOne(e => e.QuizItem);

            modelBuilder.Entity<UserEntity>()
                .HasData(
                new UserEntity(1,"321@gmail.com", "strong")
                );

            modelBuilder.Entity<QuizItemAnswerEntity>()
                .HasData(
                    new QuizItemAnswerEntity() { Id = 1, Answer = "1" },
                    new QuizItemAnswerEntity() { Id = 2, Answer = "2" },
                    new QuizItemAnswerEntity() { Id = 3, Answer = "3" },
                    new QuizItemAnswerEntity() { Id = 4, Answer = "4" },
                    new QuizItemAnswerEntity() { Id = 5, Answer = "5" },
                    new QuizItemAnswerEntity() { Id = 6, Answer = "6" },
                    new QuizItemAnswerEntity() { Id = 7, Answer = "7" },
                    new QuizItemAnswerEntity() { Id = 8, Answer = "8" },
                    new QuizItemAnswerEntity() { Id = 9, Answer = "9" },
                    new QuizItemAnswerEntity() { Id = 10, Answer = "0" }
                );

            modelBuilder.Entity<QuizItemEntity>()
                .HasData(
                    new QuizItemEntity()
                    {
                        Id = 1,
                        Question = "2 + 3",
                        CorrectAnswer = "5"
                    },
                    new QuizItemEntity()
                    {
                        Id = 2,
                        Question = "2 * 3",
                        CorrectAnswer = "6"
                    },
                    new QuizItemEntity()
                    {
                        Id = 3,
                        Question = "8 - 3",
                        CorrectAnswer = "5"
                    },
                    new QuizItemEntity()
                    {
                        Id = 4,
                        Question = "8 : 2",
                        CorrectAnswer = "4"
                    }
                );

            modelBuilder.Entity<QuizEntity>()
                .HasData(
                    new QuizEntity()
                    {
                        Title = "Matematyka",
                        Id = 1
                    },
                    new QuizEntity()
                    {
                        Title = "Arytmetyka",
                        Id = 2
                    }
                );

            modelBuilder.Entity<QuizEntity>()
                .HasMany<QuizItemEntity>(q => q.Items)
                .WithMany(e => e.Quizzes)
                .UsingEntity(
                    join => join.HasData(
                        new { QuizzesId = 1, ItemsId = 1 },
                        new { QuizzesId = 1, ItemsId = 2 },
                        new { QuizzesId = 1, ItemsId = 3 }
                    )
                );

            modelBuilder.Entity<QuizItemEntity>()
                .HasMany<QuizItemAnswerEntity>(q => q.IncorrectAnswers)
                .WithMany(e => e.QuizItems)
                .UsingEntity(join => join.HasData(
                        // "2 + 3"
                        new { QuizItemsId = 1, IncorrectAnswersId = 1 },
                        new { QuizItemsId = 1, IncorrectAnswersId = 2 },
                        new { QuizItemsId = 1, IncorrectAnswersId = 3 },
                        // "2 * 3"
                        new { QuizItemsId = 2, IncorrectAnswersId = 3 },
                        new { QuizItemsId = 2, IncorrectAnswersId = 4 },
                        new { QuizItemsId = 2, IncorrectAnswersId = 7 },
                        // "8 - 3"
                        new { QuizItemsId = 3, IncorrectAnswersId = 1 },
                        new { QuizItemsId = 3, IncorrectAnswersId = 3 },
                        new { QuizItemsId = 3, IncorrectAnswersId = 9 },
                        // "8 : 2"
                        new { QuizItemsId = 4, IncorrectAnswersId = 2 },
                        new { QuizItemsId = 4, IncorrectAnswersId = 6 },
                        new { QuizItemsId = 4, IncorrectAnswersId = 8 }
                    )
                );

            modelBuilder.Entity<QuizItemEntity>()
                .HasData(
                    new QuizItemEntity()
                    {
                        Id = 5,
                        Question = "2 + 3",
                        CorrectAnswer = "5"
                    },
                    new QuizItemEntity()
                    {
                        Id = 6,
                        Question = "2 * 3",
                        CorrectAnswer = "6"
                    },
                    new QuizItemEntity()
                    {
                        Id = 7,
                        Question = "8 - 3",
                        CorrectAnswer = "5"
                    },
                    new QuizItemEntity()
                    {
                        Id = 8,
                        Question = "8 : 2",
                        CorrectAnswer = "4"
                    }
                );

            modelBuilder.Entity<QuizEntity>()
                .HasMany<QuizItemEntity>(q => q.Items)
                .WithMany(e => e.Quizzes)
                .UsingEntity(
                    join => join.HasData(
                        new { QuizzesId = 2, ItemsId = 1 },
                        new { QuizzesId = 2, ItemsId = 2 },
                        new { QuizzesId = 2, ItemsId = 3 }
                    )
                );
            modelBuilder.Entity<QuizItemUserAnswerEntity>()
           .HasOne<QuizEntity>()
           .WithMany()
           .HasForeignKey(a => a.QuizId);

            modelBuilder.Entity<QuizItemUserAnswerEntity>()
                .HasOne<UserEntity>()
                .WithMany()
                .HasForeignKey(a => a.UserId);
            modelBuilder.Entity<QuizItemEntity>()
                .HasMany<QuizItemAnswerEntity>(q => q.IncorrectAnswers)
                .WithMany(e => e.QuizItems)
                .UsingEntity(join => join.HasData(
                        // "2 + 3"
                        new { QuizItemsId = 5, IncorrectAnswersId = 1 },
                        new { QuizItemsId = 5, IncorrectAnswersId = 2 },
                        new { QuizItemsId = 5, IncorrectAnswersId = 3 },
                        // "2 * 3"
                        new { QuizItemsId = 6, IncorrectAnswersId = 3 },
                        new { QuizItemsId = 6, IncorrectAnswersId = 4 },
                        new { QuizItemsId = 6, IncorrectAnswersId = 7 },
                        // "8 - 3"
                        new { QuizItemsId = 7, IncorrectAnswersId = 1 },
                        new { QuizItemsId = 7, IncorrectAnswersId = 3 },
                        new { QuizItemsId = 7, IncorrectAnswersId = 9 },
                        // "8 : 2"
                        new { QuizItemsId = 8, IncorrectAnswersId = 2 },
                        new { QuizItemsId = 8, IncorrectAnswersId = 6 },
                        new { QuizItemsId = 8, IncorrectAnswersId = 8 }
                    )
                );
        }
    }
}
