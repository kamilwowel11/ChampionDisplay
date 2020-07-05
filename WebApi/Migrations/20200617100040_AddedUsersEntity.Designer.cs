﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Infrastructure.Context;

namespace WebApi.Migrations
{
    [DbContext(typeof(ChampionsContext))]
    [Migration("20200617100040_AddedUsersEntity")]
    partial class AddedUsersEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("WebApi.Infrastructure.Models.ChampionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("DefaultPosition")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Champions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvatarUrl = "assets/Aatrox.png",
                            Bio = "Once honored defenders of Shurima against the Void, Aatrox and his brethren would eventually become an even greater threat to Runeterra.",
                            DefaultPosition = "Toplane",
                            FirstName = "Aatrox",
                            PictureUrl = "assets/Aatrox.png"
                        },
                        new
                        {
                            Id = 2,
                            AvatarUrl = "assets/Akali.png",
                            Bio = "Abandoning the Kinkou Order and her title of the Fist of Shadow, Akali now strikes alone, ready to be the deadly weapon her people need.",
                            DefaultPosition = "Toplane/Midlane",
                            FirstName = "Akali",
                            PictureUrl = "assets/Akali.png"
                        },
                        new
                        {
                            Id = 3,
                            AvatarUrl = "assets/Lux.png",
                            Bio = "Luxanna Crownguard hails from Demacia, an insular realm where magical abilities are viewed with fear and suspicion.",
                            DefaultPosition = "Midlane",
                            FirstName = "Lux",
                            PictureUrl = "assets/Lux.png"
                        },
                        new
                        {
                            Id = 4,
                            AvatarUrl = "assets/Nautilus.png",
                            Bio = "A lonely legend as old as the first piers sunk in Bilgewater, the armored goliath known as Nautilus roams the dark waters off the coast of the Blue Flame Isles.",
                            DefaultPosition = "BottomLane",
                            FirstName = "Nautilus",
                            PictureUrl = "assets/Nautilus.png"
                        },
                        new
                        {
                            Id = 5,
                            AvatarUrl = "assets/Udyr.png",
                            Bio = "Udyr is more than a man; he is a vessel for the untamed power of four primal animal spirits.",
                            DefaultPosition = "Jungle",
                            FirstName = "Udyr",
                            PictureUrl = "assets/Udyr.png"
                        },
                        new
                        {
                            Id = 6,
                            AvatarUrl = "assets/Volibear.png",
                            Bio = "The thunderous demigod known as the Thousand-Pierced Bear is the battle-spirit of the Freljord.",
                            DefaultPosition = "Toplane/Jungle",
                            FirstName = "Volibear",
                            PictureUrl = "assets/Volibear.png"
                        },
                        new
                        {
                            Id = 7,
                            AvatarUrl = "assets/Yuumi.png",
                            Bio = "A magical cat from Bandle City, Yuumi was once the familiar of a yordle enchantress, Norra.",
                            DefaultPosition = "Bottomlane",
                            FirstName = "Yuumi",
                            PictureUrl = "assets/Yuumi.png"
                        });
                });

            modelBuilder.Entity("WebApi.Infrastructure.Models.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
