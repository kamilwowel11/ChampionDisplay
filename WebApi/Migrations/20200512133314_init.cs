using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    DefaultPosition = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    AvatarUrl = table.Column<string>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "AvatarUrl", "Bio", "DefaultPosition", "FirstName", "PictureUrl" },
                values: new object[] { 1, "assets/Aatrox.png", "Once honored defenders of Shurima against the Void, Aatrox and his brethren would eventually become an even greater threat to Runeterra.", "Toplane", "Aatrox", "assets/Aatrox.png" });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "AvatarUrl", "Bio", "DefaultPosition", "FirstName", "PictureUrl" },
                values: new object[] { 2, "assets/Akali.png", "Abandoning the Kinkou Order and her title of the Fist of Shadow, Akali now strikes alone, ready to be the deadly weapon her people need.", "Toplane/Midlane", "Akali", "assets/Akali.png" });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "AvatarUrl", "Bio", "DefaultPosition", "FirstName", "PictureUrl" },
                values: new object[] { 3, "assets/Lux.png", "Luxanna Crownguard hails from Demacia, an insular realm where magical abilities are viewed with fear and suspicion.", "Midlane", "Lux", "assets/Lux.png" });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "AvatarUrl", "Bio", "DefaultPosition", "FirstName", "PictureUrl" },
                values: new object[] { 4, "assets/Nautilus.png", "A lonely legend as old as the first piers sunk in Bilgewater, the armored goliath known as Nautilus roams the dark waters off the coast of the Blue Flame Isles.", "BottomLane", "Nautilus", "assets/Nautilus.png" });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "AvatarUrl", "Bio", "DefaultPosition", "FirstName", "PictureUrl" },
                values: new object[] { 5, "assets/Udyr.png", "Udyr is more than a man; he is a vessel for the untamed power of four primal animal spirits.", "Jungle", "Udyr", "assets/Udyr.png" });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "AvatarUrl", "Bio", "DefaultPosition", "FirstName", "PictureUrl" },
                values: new object[] { 6, "assets/Volibear.png", "The thunderous demigod known as the Thousand-Pierced Bear is the battle-spirit of the Freljord.", "Toplane/Jungle", "Volibear", "assets/Volibear.png" });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "AvatarUrl", "Bio", "DefaultPosition", "FirstName", "PictureUrl" },
                values: new object[] { 7, "assets/Yuumi.png", "A magical cat from Bandle City, Yuumi was once the familiar of a yordle enchantress, Norra.", "Bottomlane", "Yuumi", "assets/Yuumi.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Champions");
        }
    }
}
