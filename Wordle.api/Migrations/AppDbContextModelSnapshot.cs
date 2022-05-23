﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wordle.api.Data;

#nullable disable

namespace Wordle.api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Wordle.api.Data.DateWord", b =>
                {
                    b.Property<int>("DateWordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DateWordId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("DateWordId");

                    b.HasIndex("WordId");

                    b.ToTable("DateWords");
                });

            modelBuilder.Entity("Wordle.api.Data.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"), 1L, 1);

                    b.Property<DateTime?>("DateEnded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStarted")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("WordId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Wordle.api.Data.Guess", b =>
                {
                    b.Property<int>("GuessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuessId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuessId");

                    b.HasIndex("GameId");

                    b.ToTable("Guess");
                });

            modelBuilder.Entity("Wordle.api.Data.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"), 1L, 1);

                    b.Property<double>("AverageAttempts")
                        .HasColumnType("float");

                    b.Property<int>("AverageSecondsPerGame")
                        .HasColumnType("int");

                    b.Property<int>("GameCount")
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Wordle.api.Data.ScoreStat", b =>
                {
                    b.Property<int>("ScoreStatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScoreStatId"), 1L, 1);

                    b.Property<int>("AverageSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("TotalGames")
                        .HasColumnType("int");

                    b.HasKey("ScoreStatId");

                    b.ToTable("ScoreStats");

                    b.HasData(
                        new
                        {
                            ScoreStatId = 1,
                            AverageSeconds = 0,
                            Score = 1,
                            TotalGames = 0
                        },
                        new
                        {
                            ScoreStatId = 2,
                            AverageSeconds = 0,
                            Score = 2,
                            TotalGames = 0
                        },
                        new
                        {
                            ScoreStatId = 3,
                            AverageSeconds = 0,
                            Score = 3,
                            TotalGames = 0
                        },
                        new
                        {
                            ScoreStatId = 4,
                            AverageSeconds = 0,
                            Score = 4,
                            TotalGames = 0
                        },
                        new
                        {
                            ScoreStatId = 5,
                            AverageSeconds = 0,
                            Score = 5,
                            TotalGames = 0
                        },
                        new
                        {
                            ScoreStatId = 6,
                            AverageSeconds = 0,
                            Score = 6,
                            TotalGames = 0
                        });
                });

            modelBuilder.Entity("Wordle.api.Data.Word", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WordId"), 1L, 1);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WordId");

                    b.ToTable("Words");

                    b.HasData(
                        new
                        {
                            WordId = 1,
                            Value = "thing"
                        },
                        new
                        {
                            WordId = 2,
                            Value = "think"
                        },
                        new
                        {
                            WordId = 3,
                            Value = "thong"
                        },
                        new
                        {
                            WordId = 4,
                            Value = "throb"
                        },
                        new
                        {
                            WordId = 5,
                            Value = "thunk"
                        },
                        new
                        {
                            WordId = 6,
                            Value = "wrong"
                        });
                });

            modelBuilder.Entity("Wordle.api.Data.DateWord", b =>
                {
                    b.HasOne("Wordle.api.Data.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Wordle.api.Data.Game", b =>
                {
                    b.HasOne("Wordle.api.Data.Player", "Player")
                        .WithMany("Games")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wordle.api.Data.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Wordle.api.Data.Guess", b =>
                {
                    b.HasOne("Wordle.api.Data.Game", "Game")
                        .WithMany("Guesses")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Wordle.api.Data.Game", b =>
                {
                    b.Navigation("Guesses");
                });

            modelBuilder.Entity("Wordle.api.Data.Player", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}