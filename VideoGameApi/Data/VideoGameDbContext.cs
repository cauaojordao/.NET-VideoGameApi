using Microsoft.EntityFrameworkCore;

namespace VideoGameApi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VideoGame>().HasData(

                new VideoGame
                {
                    Title = "Spider-Man 2",
                    Platform = "Ps5",
                    Developer = "Insomniac Games",
                    Publisher = "Sony Interactive Entertainment"
                },
            new VideoGame
            {
                Title = "The Legend of Zelda Breath of the Wild",
                Platform = " Nintendo Switch",
                Developer = "Nintendo EPD",
                Publisher = "Nintendo"
            }
        );
        }
    }
}
