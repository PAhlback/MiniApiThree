﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniApiThree.Data;

#nullable disable

namespace MiniApiThree.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.Property<int>("InterestsId")
                        .HasColumnType("int");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.HasKey("InterestsId", "PeopleId");

                    b.HasIndex("PeopleId");

                    b.ToTable("InterestPerson");
                });

            modelBuilder.Entity("MiniApiThree.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("MiniApiThree.Models.InterestLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InterestId");

                    b.HasIndex("PersonId");

                    b.ToTable("InterestLinks");
                });

            modelBuilder.Entity("MiniApiThree.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.HasOne("MiniApiThree.Models.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniApiThree.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniApiThree.Models.InterestLink", b =>
                {
                    b.HasOne("MiniApiThree.Models.Interest", "Interest")
                        .WithMany("InterestLinks")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniApiThree.Models.Person", "Person")
                        .WithMany("InterestLinks")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MiniApiThree.Models.Interest", b =>
                {
                    b.Navigation("InterestLinks");
                });

            modelBuilder.Entity("MiniApiThree.Models.Person", b =>
                {
                    b.Navigation("InterestLinks");
                });
#pragma warning restore 612, 618
        }
    }
}