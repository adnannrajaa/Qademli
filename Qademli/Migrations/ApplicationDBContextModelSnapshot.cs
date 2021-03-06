﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Qademli;

namespace Qademli.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Qademli.Models.DatabaseModel.Application", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Fee")
                        .HasColumnType("int");

                    b.Property<int>("GoalID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<int?>("TopicID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GoalID");

                    b.HasIndex("StatusID");

                    b.HasIndex("TopicID");

                    b.HasIndex("UserID");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.ApplicationStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ApplicationStatus");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.CallSchedule", b =>
                {
                    b.Property<int>("CallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CallDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CallId");

                    b.ToTable("callSchedule");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.CallStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("callStatus");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.Goal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Fee")
                        .HasColumnType("real");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TopicID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TopicID");

                    b.ToTable("Goal");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.GoalDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GoalID")
                        .HasColumnType("int");

                    b.Property<int>("GoalPropertyID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GoalID");

                    b.HasIndex("GoalPropertyID");

                    b.ToTable("GoalDetail");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.GoalProperty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("GoalProperty");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.GoalPropertyHeading", b =>
                {
                    b.Property<int>("HeadingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GoalPropId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HeadingId");

                    b.ToTable("GoalPropertyHeading");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.GoalPropertyValue", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GoalHeadingID")
                        .HasColumnType("int");

                    b.Property<int>("GoalId")
                        .HasColumnType("int");

                    b.Property<int>("GoalPropertyID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("GoalPropertyID");

                    b.ToTable("GoalPropertyValue");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.Topic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isVerified")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.UserEducationDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FinancialSupport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HighSchoolDegree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ILETSorTOEFL")
                        .HasColumnType("int");

                    b.Property<string>("LastDegree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MinistryofHigherEducationDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitsPassed")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserEducationDetail");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.UserFamilyDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CollegeUniversity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanionI20")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanionPassport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyMemberFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FamilyMemberImmigrant")
                        .HasColumnType("bit");

                    b.Property<bool>("FamilyMemberInUS")
                        .HasColumnType("bit");

                    b.Property<string>("FamilyMemberLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyMemberRelation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyMemberRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FamilyMemberUSCitizen")
                        .HasColumnType("bit");

                    b.Property<string>("FatherCivilIDBack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherCivilIDFront")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FriendAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FriendInUS")
                        .HasColumnType("bit");

                    b.Property<string>("FriendMobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Major")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonthlySalary")
                        .HasColumnType("int");

                    b.Property<string>("MotherCivilIDBack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherCivilIDFront")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentMobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentPassport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpouseCivilIDBack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpouseCivilIDFront")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpousePassport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserFamilyDetail");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.UserPersonalDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CivilIDBack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CivilIDFront")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationDocNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OccupationLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OccupationSector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TownCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("ZipPostalCode")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserPersonalDetail");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.UserVisaDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountriesVisted")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("DaysSpentInUS")
                        .HasColumnType("int");

                    b.Property<bool>("Employee")
                        .HasColumnType("bit");

                    b.Property<string>("I20Doc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastVisitToUS")
                        .HasColumnType("datetime2");

                    b.Property<string>("MyProperty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonOfRejection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recommendations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TravelDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("VisaPermit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VisaPermitRejected")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserVisaDetail");
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.Application", b =>
                {
                    b.HasOne("Qademli.Models.DatabaseModel.Goal", "Goal")
                        .WithMany()
                        .HasForeignKey("GoalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Qademli.Models.DatabaseModel.ApplicationStatus", "ApplicationStatus")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Qademli.Models.DatabaseModel.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicID");

                    b.HasOne("Qademli.Models.DatabaseModel.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.Goal", b =>
                {
                    b.HasOne("Qademli.Models.DatabaseModel.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.GoalDetail", b =>
                {
                    b.HasOne("Qademli.Models.DatabaseModel.Goal", "Goal")
                        .WithMany()
                        .HasForeignKey("GoalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Qademli.Models.DatabaseModel.GoalProperty", "GoalProperty")
                        .WithMany()
                        .HasForeignKey("GoalPropertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.GoalPropertyValue", b =>
                {
                    b.HasOne("Qademli.Models.DatabaseModel.GoalProperty", "GoalProperty")
                        .WithMany()
                        .HasForeignKey("GoalPropertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.UserEducationDetail", b =>
                {
                    b.HasOne("Qademli.Models.DatabaseModel.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.UserFamilyDetail", b =>
                {
                    b.HasOne("Qademli.Models.DatabaseModel.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.UserPersonalDetail", b =>
                {
                    b.HasOne("Qademli.Models.DatabaseModel.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Qademli.Models.DatabaseModel.UserVisaDetail", b =>
                {
                    b.HasOne("Qademli.Models.DatabaseModel.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
