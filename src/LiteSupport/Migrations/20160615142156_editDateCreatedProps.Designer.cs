using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LiteSupport.Models;

namespace LiteSupport.Migrations
{
    [DbContext(typeof(LSContext))]
    [Migration("20160615142156_editDateCreatedProps")]
    partial class editDateCreatedProps
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LiteSupport.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentMsg");

                    b.Property<DateTime>("DateCreatedC");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("TicketId");

                    b.HasKey("CommentId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TicketId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("LiteSupport.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<string>("URL");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("LiteSupport.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentName");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("LiteSupport.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<string>("Username");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("LiteSupport.Models.Priority", b =>
                {
                    b.Property<int>("PriorityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PriorityName");

                    b.HasKey("PriorityId");

                    b.ToTable("Priority");
                });

            modelBuilder.Entity("LiteSupport.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DateClosed");

                    b.Property<DateTime>("DateCreatedT");

                    b.Property<string>("Description");

                    b.Property<bool>("IsComplete");

                    b.Property<int>("PriorityId");

                    b.Property<string>("Title");

                    b.Property<int>("TtypeId");

                    b.HasKey("TicketId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("TtypeId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("LiteSupport.Models.Ttype", b =>
                {
                    b.Property<int>("TtypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TtypeName");

                    b.HasKey("TtypeId");

                    b.ToTable("Ttype");
                });

            modelBuilder.Entity("LiteSupport.Models.Comment", b =>
                {
                    b.HasOne("LiteSupport.Models.Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LiteSupport.Models.Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LiteSupport.Models.Employee", b =>
                {
                    b.HasOne("LiteSupport.Models.Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LiteSupport.Models.Ticket", b =>
                {
                    b.HasOne("LiteSupport.Models.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LiteSupport.Models.Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LiteSupport.Models.Ttype")
                        .WithMany()
                        .HasForeignKey("TtypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
