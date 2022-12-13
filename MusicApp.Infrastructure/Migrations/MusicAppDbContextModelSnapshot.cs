﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicApp.Data;

#nullable disable

namespace MusicApp.Infrastructure.Migrations
{
    [DbContext(typeof(MusicAppDbContext))]
    partial class MusicAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MusicApp.Infrastructure.Data.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("UserId");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Artist = "Marvin Gaye",
                            Description = "Marvin Gaye’s masterpiece began as a reaction to police brutality. In May 1969, Renaldo “Obie” Benson, the Four Tops’ bass singer, watched TV coverage of hundreds of club-wielding cops breaking up the People’s Park, a protest hub in Berkeley. Aghast at the violence, Benson began to write a song with Motown lyricist Al Cleveland, trying to capture the confusion and pain of the times.",
                            GenreId = 4,
                            ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-001-Marvin-Gaye-WHATS-GOING-ON.jpg?w=1000",
                            IsActive = true,
                            Likes = 0,
                            Title = "What’s Going On",
                            UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c89",
                            Year = 1971
                        },
                        new
                        {
                            Id = 2,
                            Artist = "The Beach Boys",
                            Description = "“Who’s gonna hear this shit?” Beach Boys singer Mike Love asked the band’s resident genius, Brian Wilson, in 1966, as Wilson played him the new songs he was working on. “The ears of a dog?” Confronted with his bandmate’s contempt, Wilson made lemonade of lemons. “Ironically,” he observed, “Mike’s barb inspired the album’s title.”",
                            GenreId = 3,
                            ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-002-Beach-Boys-PET-SOUNDS-update.jpg?w=1000",
                            IsActive = true,
                            Likes = 0,
                            Title = "Pet Sounds",
                            UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c89",
                            Year = 1966
                        },
                        new
                        {
                            Id = 3,
                            Artist = "Joni Mitchell",
                            Description = "In 1971, Joni Mitchell represented the West Coast feminine ideal — celebrated by Robert Plant as “a girl out there with love in her eyes and flowers in her hair” on Led Zeppelin’s “Goin’ to California.” It was a status that Mitchell hadn’t asked for and did not want: “I went, ‘Oh, my God, a lot of people are listening to me,’” she recalled in 2013. “’They better find out who they’re worshiping. Let’s see if they can take it. Let’s get real.’ So I wrote Blue.”",
                            GenreId = 1,
                            ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-003-JoniMitchell-BLUE-HR.jpg?w=1000",
                            IsActive = true,
                            Likes = 0,
                            Title = "Blue",
                            UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c89",
                            Year = 1971
                        },
                        new
                        {
                            Id = 4,
                            Artist = "Stevie Wonder",
                            Description = "Months before the recording sessions for Songs in the Key of Life ended, the musicians in Stevie Wonder’s band had T-shirts made up that proclaimed, “We’re almost finished.” It was the stock answer to casual fans and Motown executives and everybody who’d fallen in love with Wonder’s early-Seventies gems – 1972’s Talking Book, 1973’s Innervisions, and 1974’s Fulfillingness’ First Finale – and who had been waiting two years for the next chapter.",
                            GenreId = 4,
                            ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-004-Stevie-Wonder-SONGS-IN-THE-KEY-OF-LIFE.jpg?w=1000",
                            IsActive = true,
                            Likes = 0,
                            Title = "Songs in the Key of Life",
                            UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c89",
                            Year = 1976
                        },
                        new
                        {
                            Id = 5,
                            Artist = "The Beatles",
                            Description = "“It was a very happy record,” said producer George Martin, describing this album in The Beatles Anthology. “I guess it was happy because everybody thought it was going to be the last.” Indeed, Abbey Road — recorded in two months during the summer of 1969 — almost never got made at all. That January, the Beatles were on the verge of a breakup, exhausted and angry with one another after the disastrous sessions for the aborted Get Back LP, later salvaged as Let It Be [see No. 342].",
                            GenreId = 3,
                            ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-005-Beatles-ABBEY-ROAD.jpg?w=1000",
                            IsActive = true,
                            Likes = 0,
                            Title = "Abbey Road",
                            UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c89",
                            Year = 1969
                        },
                        new
                        {
                            Id = 6,
                            Artist = "Nirvana",
                            Description = "An overnight-success story of the 1990s, Nirvana’s second album and its totemic ﬁrst single, “Smells Like Teen Spirit,” shot up from the Northwest underground — the nascent grunge scene in Seattle — to kick Michael Jackson’s Dangerous off the top of the Billboard charts and blow hair metal off the map. Few albums have had such an overpowering impact on a generation — a nation of teens suddenly turned punk — and such a catastrophic effect on its main creator. ",
                            GenreId = 3,
                            ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-006-Nirvana-NEVERMIND-HR.jpg?w=1000",
                            IsActive = true,
                            Likes = 0,
                            Title = "Nevermind",
                            UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c89",
                            Year = 1991
                        },
                        new
                        {
                            Id = 7,
                            Artist = "Fleetwood Mac",
                            Description = "With Rumours, Fleetwood Mac turned private turmoil into gleaming, melodic public art. The band’s two couples — bassist John McVie and singer-keyboard player Christine McVie, who were married; guitarist Lindsey Buckingham and vocalist Stevie Nicks, who were not — broke up during the protracted sessions for the album.",
                            GenreId = 3,
                            ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-007-Fleetwood-Mac-RUMOURS.jpg?w=1000",
                            IsActive = true,
                            Likes = 0,
                            Title = "Rumours",
                            UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c89",
                            Year = 1977
                        },
                        new
                        {
                            Id = 8,
                            Artist = "Prince and the Revolution",
                            Description = "“I think Purple Rain is the most avant-garde, ‘purple’ thing I’ve ever done,” Prince told Ebony in 1986. He was still a rising star with only a couple of hits when he got the audacious idea to make a movie based on his life, and make his next LP the movie’s soundtrack. When it was released in 1984, he became the first artist to have the Number One song, album, and movie in North America. ",
                            GenreId = 1,
                            ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-008-Prince-PURPLE-RAIN.jpg?w=1000",
                            IsActive = true,
                            Likes = 0,
                            Title = "Purple Rain",
                            UserId = "43a3b5b6-a7e5-4949-a539-d7029f18f747",
                            Year = 1984
                        },
                        new
                        {
                            Id = 9,
                            Artist = "Bob Dylan",
                            Description = "Bob Dylan once introduced this album’s opening song, “Tangled Up in Blue,” onstage as taking him 10 years to live and two years to write. It was, for him, a pointed reference to the personal crisis — the collapse of his marriage to Sara Lowndes — that at least partly inspired this album, Dylan’s best of the 1970s. ",
                            GenreId = 3,
                            ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-009-Bob-Dylan-BLOOD-ON-THE-TRACKS.jpg?w=1000",
                            IsActive = true,
                            Likes = 0,
                            Title = "Blood on the Tracks",
                            UserId = "43a3b5b6-a7e5-4949-a539-d7029f18f747",
                            Year = 1975
                        },
                        new
                        {
                            Id = 10,
                            Artist = "Lauryn Hill",
                            Description = "“This is a very sexist industry,” Lauryn Hill told Essence magazine in 1998. “They’ll never throw the ‘genius’ title to a sister.” Though already a star as co-leader of the Fugees, with Wyclef Jean, she was hungry to express her own vision. “I wanted to write songs that lyrically move me and have the integrity of reggae and the knock of hip-hop and the instrumentation of classic soul,” the singer said of her debut album.",
                            GenreId = 4,
                            ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-010-Lauryn-Hill-MISEDUCATION.jpg?w=1000",
                            IsActive = true,
                            Likes = 0,
                            Title = "The Miseducation of Lauryn Hill",
                            UserId = "43a3b5b6-a7e5-4949-a539-d7029f18f747",
                            Year = 1998
                        },
                        new
                        {
                            Id = 11,
                            Artist = "The Beatles",
                            Description = "Revolver was the sound of the Beatles fully embracing the recording studio as a sonic canvas, free to pursue musical ideas and possibilities that would reshape rock forever. It speaks volumes that the first song the band worked on upon entering Abbey Road studios in April 1966 would have been impossible to replicate live — a swirl of hazy guitar, backward tape loops, kaleidoscopic drum tumble, and John Lennon’s voice recorded to sound like “the Dalai Lama singing from the highest mountaintop.”",
                            GenreId = 3,
                            ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-011-BeatlesREVOLVER-updated.jpg?w=1000",
                            IsActive = true,
                            Likes = 0,
                            Title = "Revolver",
                            UserId = "43a3b5b6-a7e5-4949-a539-d7029f18f747",
                            Year = 1966
                        });
                });

            modelBuilder.Entity("MusicApp.Infrastructure.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MusicApp.Infrastructure.Data.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Artist = "Лили Иванова",
                            Date = new DateTime(2022, 12, 4, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.eventim.bg%2Fbg%2Fartist%2Flili-ivanova-2%2Fprofile.html&psig=AOvVaw3IDtRNU1-18kn24xJVnSN8&ust=1671022386647000&source=images&cd=vfe&ved=2ahUKEwj53bTP0fb7AhWRYPEDHUnCBqAQjRx6BAgAEAo",
                            Location = "Зала Армеец"
                        });
                });

            modelBuilder.Entity("MusicApp.Infrastructure.Data.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pop"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hip hop"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rock"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Soul"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Reggae"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Jazz"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Funk"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Country"
                        });
                });

            modelBuilder.Entity("MusicApp.Infrastructure.Data.Entities.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("MusicApp.Infrastructure.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "42c8f95a-e61d-445a-bb23-67b2fd181c89",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ae367bf7-7155-48b8-bfc5-1b9dad9020fd",
                            Email = "user@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Pesho",
                            LastName = "Petrov",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@MAIL.COM",
                            NormalizedUserName = "USER@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAECb+cD0OYN1YMvJ3GVRJ6FBr6vHT5swbeffLF4Mc946gUXS0ZoMw3GAX+r07MpacEg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "91708607-692d-4bde-a5cc-3af74e7d983b",
                            TwoFactorEnabled = false,
                            UserName = "user@mail.com"
                        },
                        new
                        {
                            Id = "43a3b5b6-a7e5-4949-a539-d7029f18f747",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3e89a7c6-685d-4d7c-9bbe-07a84499bad9",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Ivan",
                            LastName = "Ivanov",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKPRC33hJB8o+18I0gtyUUse3ZldG8p9XlAmtBrSxnSy+vTVUfJc4Y9/K+EcFOKHQg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "86f1a727-46dc-4ffc-a7fe-5dc22e0362b5",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MusicApp.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MusicApp.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicApp.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MusicApp.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicApp.Infrastructure.Data.Entities.Album", b =>
                {
                    b.HasOne("MusicApp.Infrastructure.Data.Entities.Genre", "Genre")
                        .WithMany("Albums")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MusicApp.Infrastructure.Data.Entities.User", "User")
                        .WithMany("Albums")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MusicApp.Infrastructure.Data.Entities.Comment", b =>
                {
                    b.HasOne("MusicApp.Infrastructure.Data.Entities.Album", "Album")
                        .WithMany("Comments")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicApp.Infrastructure.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MusicApp.Infrastructure.Data.Entities.Like", b =>
                {
                    b.HasOne("MusicApp.Infrastructure.Data.Entities.User", null)
                        .WithMany("Likes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MusicApp.Infrastructure.Data.Entities.Album", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("MusicApp.Infrastructure.Data.Entities.Genre", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("MusicApp.Infrastructure.Data.Entities.User", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
