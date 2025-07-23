using QuestionSpace;
using Core.Interfaces.Repositories.Context;
using Data.Repositories.Context.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using TabSpace;
using DeckSpace;
using UserSpace;

namespace Data.Repositories.Context
{
    public class YouDbContext : DbContext, IYouDbContext
    { 
        public YouDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var result = Environment.GetEnvironmentVariable("ConStrYouKnowForSearch");
            optionsBuilder.UseSqlServer(result);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configuration

            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new MainTabsConfiguration()); 
            modelBuilder.ApplyConfiguration(new QuestionsConfiguration()); 
            #endregion

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Tab> Tabs { get; set; }
        public DbSet<QuestionTab> QuestionTabs { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}