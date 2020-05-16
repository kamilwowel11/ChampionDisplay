using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.Context
{
  public class ChampionsContext : DbContext
  {
    public DbSet<ChampionEntity> Champions { get; set; }

    public ChampionsContext(DbContextOptions options):base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChampionEntity>()
        .HasKey(e=>e.Id);
        modelBuilder.Entity<ChampionEntity>()
        .Property(e=>e.Id)
        .ValueGeneratedOnAdd();

        modelBuilder.Entity<ChampionEntity>().HasData(
        new ChampionEntity() { Id = 1, FirstName = "Aatrox", DefaultPosition = "Toplane", Bio = "Once honored defenders of Shurima against the Void, Aatrox and his brethren would eventually become an even greater threat to Runeterra.", PictureUrl = "assets/Aatrox.png", AvatarUrl = "assets/Aatrox.png" },
        new ChampionEntity() { Id = 2, FirstName = "Akali", DefaultPosition = "Toplane/Midlane", Bio = "Abandoning the Kinkou Order and her title of the Fist of Shadow, Akali now strikes alone, ready to be the deadly weapon her people need.", PictureUrl = "assets/Akali.png", AvatarUrl = "assets/Akali.png" },
        new ChampionEntity() { Id = 3, FirstName = "Lux", DefaultPosition = "Midlane", Bio = "Luxanna Crownguard hails from Demacia, an insular realm where magical abilities are viewed with fear and suspicion.", PictureUrl = "assets/Lux.png", AvatarUrl = "assets/Lux.png" },
        new ChampionEntity() { Id = 4, FirstName = "Nautilus", DefaultPosition = "BottomLane", Bio = "A lonely legend as old as the first piers sunk in Bilgewater, the armored goliath known as Nautilus roams the dark waters off the coast of the Blue Flame Isles.", PictureUrl = "assets/Nautilus.png", AvatarUrl = "assets/Nautilus.png" },
        new ChampionEntity() { Id = 5, FirstName = "Udyr", DefaultPosition = "Jungle", Bio = "Udyr is more than a man; he is a vessel for the untamed power of four primal animal spirits.", PictureUrl = "assets/Udyr.png", AvatarUrl = "assets/Udyr.png" },
        new ChampionEntity() { Id = 6, FirstName = "Volibear", DefaultPosition = "Toplane/Jungle", Bio = "The thunderous demigod known as the Thousand-Pierced Bear is the battle-spirit of the Freljord.", PictureUrl = "assets/Volibear.png", AvatarUrl = "assets/Volibear.png" },
        new ChampionEntity() { Id = 7, FirstName = "Yuumi", DefaultPosition = "Bottomlane", Bio = "A magical cat from Bandle City, Yuumi was once the familiar of a yordle enchantress, Norra.", PictureUrl = "assets/Yuumi.png", AvatarUrl = "assets/Yuumi.png" }
      );
    }
  }
}
