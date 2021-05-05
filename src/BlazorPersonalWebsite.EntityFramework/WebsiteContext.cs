using BlazorPersonalWebsite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BlazorPersonalWebsite.EntityFramework
{
    public class WebsiteContext : DbContext
    {
        public DbSet<JobApplication> JobApplications { get; set; }

        public DbSet<SoftwareProject> SoftwareProjects { get; set; }

        public DbSet<WoodworkProject> WoodworkProjects { get; set; }

        public WebsiteContext(DbContextOptions<WebsiteContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobApplication>()
               .ToTable("JobApplication");

            modelBuilder.Entity<JobApplication>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<JobApplication>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SoftwareProject>()
                .ToTable("SoftwareProject");

            modelBuilder.Entity<SoftwareProject>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<SoftwareProject>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<WoodworkProject>()
                .ToTable("WoodworkProject");

            modelBuilder.Entity<WoodworkProject>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<WoodworkProject>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SoftwareProjectImage>()
                .Property(x => x.SoftwareProjectImageId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SoftwareProjectImage>()
                .HasKey(k => k.SoftwareProjectImageId);

            modelBuilder.Entity<SoftwareProjectImage>()
               .ToTable("SoftwareProjectImage");

            modelBuilder.Entity<WoodworkProjectImage>()
               .ToTable("WoodworkProjectImage");

            modelBuilder.Entity<WoodworkProjectImage>()
                .Property(x => x.WoodworkProjectImageId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<WoodworkProjectImage>()
                .HasKey(k => k.WoodworkProjectImageId);

            AddSoftwareProjects(modelBuilder);
            AddWoodworkProjects(modelBuilder);
        }

        private void AddWoodworkProjects(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WoodworkProjectImage>()
                .HasData(
                    new WoodworkProjectImage
                    {
                        WoodworkProjectImageId = 1,
                        Description = "Unhung gate",
                        ImageUrl = "images\\woodwork-images\\side-gate\\sidegate-unhung.jpg",
                        WoodworkProjectId = 1
                    },
                    new WoodworkProjectImage
                    {
                        WoodworkProjectImageId = 2,
                        Description = "Unfinished workbench",
                        ImageUrl = "images\\woodwork-images\\workbench\\workbench-unfinished.jpg",
                        WoodworkProjectId = 2
                    },
                    new WoodworkProjectImage
                    {
                        WoodworkProjectImageId = 3,
                        Description = "Unfinished workbench",
                        ImageUrl = "images\\woodwork-images\\bird-table\\bird-table.jpg",
                        WoodworkProjectId = 3
                    },
                    new WoodworkProjectImage
                    {
                        WoodworkProjectImageId = 4,
                        Description = "All raised garden beds",
                        ImageUrl = "images\\woodwork-images\\raised-garden-bed\\all-in-view.jpg",
                        WoodworkProjectId = 4
                    },
                    new WoodworkProjectImage
                    {
                        WoodworkProjectImageId = 5,
                        Description = "All raised garden beds",
                        ImageUrl = "images\\woodwork-images\\raised-garden-bed\\all-in-view.jpg",
                        WoodworkProjectId = 5
                    }
            );


            modelBuilder.Entity<WoodworkProject>()
                .HasData(
                    new WoodworkProject
                    {
                        Id = 1,
                        Name = "Side Gate",
                        ProjectRef = "sideGate",
                        DateCreated = DateTime.Parse("2017/07/05")
                    },
                    new WoodworkProject
                    {
                        Id = 2,
                        Name = "Workbench",
                        ProjectRef = "workbench",
                        DateCreated = DateTime.Parse("2017/08/21")
                    },
                    new WoodworkProject
                    {
                        Id = 3,
                        Name = "Bird table",
                        ProjectRef = "birdTable",
                        DateCreated = DateTime.Parse("2017/08/21"),
                    },
                    new WoodworkProject
                    {
                        Id = 4,
                        Name = "Raised Garden bed (Small)",
                        ProjectRef = "raisedGardenBendSmall",
                        DateCreated = DateTime.Parse("2020/05/01"),
                    },
                    new WoodworkProject
                    {
                        Id = 5,
                        Name = "Raised Garden bed (Large)",
                        ProjectRef = "raisedGardenBendLarge",
                        DateCreated = DateTime.Parse("2020/09/01"),
                    }
                );
        }

        private void AddSoftwareProjects(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoftwareProjectImage>()
                .HasData(
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 1,
                        ImageUrl = "images\\software-images\\rs-calculator\\1.png",
                        Description = "Agility skill calculator",
                        SoftwareProjectId = 1
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 2,
                        ImageUrl = "images\\software-images\\rs-calculator\\2.png",
                        Description = "Fishing skill calculator",
                        SoftwareProjectId = 1
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 3,
                        ImageUrl = "images\\software-images\\rs-calculator\\3.png",
                        Description = "Dropdown showing which skills are included",
                        SoftwareProjectId = 1
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 4,
                        ImageUrl = "images\\software-images\\rs-calculator\\4.png",
                        Description = "Dropdown showing skill subcategories",
                        SoftwareProjectId = 1
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 5,
                        ImageUrl = "images\\software-images\\ecommerce-site\\1.png",
                        Description = "Ecommerce homepage",
                        SoftwareProjectId = 2
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 6,
                        ImageUrl = "images\\software-images\\ecommerce-site\\2.png",
                        Description = "Ecommerce product page",
                        SoftwareProjectId = 2
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 7,
                        ImageUrl = "images\\software-images\\ecommerce-site\\3.png",
                        Description = "Ecommerce basket page",
                        SoftwareProjectId = 2
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 8,
                        ImageUrl = "images\\software-images\\ecommerce-site\\4.png",
                        Description = "Ecommerce admin page",
                        SoftwareProjectId = 2
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 9,
                        ImageUrl = "images\\software-images\\ecommerce-site\\5.png",
                        Description = "Ecommerce admin page - Edit listing",
                        SoftwareProjectId = 2
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 10,
                        ImageUrl = "images\\software-images\\ecommerce-site\\6.png",
                        Description = "Ecommerce contact us page",
                        SoftwareProjectId = 2
                    },
                     new SoftwareProjectImage
                     {
                         SoftwareProjectImageId = 11,
                         ImageUrl = "images\\software-images\\loyalty-pro-app\\1.png",
                         Description = "Main menu",
                         SoftwareProjectId = 3
                     },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 12,
                        ImageUrl = "images\\software-images\\loyalty-pro-app\\2.png",
                        Description = "Balance overview page",
                        SoftwareProjectId = 3
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 13,
                        ImageUrl = "images\\software-images\\loyalty-pro-app\\3.png",
                        Description = "Personal details page",
                        SoftwareProjectId = 3
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 14,
                        ImageUrl = "images\\software-images\\loyalty-pro-app\\4.png",
                        Description = "Vouchers overview page",
                        SoftwareProjectId = 3
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 15,
                        ImageUrl = "images\\software-images\\loyalty-pro-app\\5.png",
                        Description = "Initial unlogged in page",
                        SoftwareProjectId = 3
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 16,
                        ImageUrl = "images\\software-images\\loyalty-pro-app\\6.png",
                        Description = "Manual log in page",
                        SoftwareProjectId = 3
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 17,
                        ImageUrl = "images\\software-images\\gps-logger\\1.png",
                        Description = "Display showing journeys between two staypoints",
                        SoftwareProjectId = 4
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 18,
                        ImageUrl = "images\\software-images\\gps-logger\\2.png",
                        Description = "Individual journey view",
                        SoftwareProjectId = 4
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 19,
                        ImageUrl = "images\\software-images\\gps-logger\\3.png",
                        Description = "Staypoint overview showing individual visits",
                        SoftwareProjectId = 4
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 20,
                        ImageUrl = "images\\software-images\\gps-logger\\4.png",
                        Description = "Staypoint shown on map",
                        SoftwareProjectId = 4
                    },
                    new SoftwareProjectImage
                    {
                        SoftwareProjectImageId = 21,
                        ImageUrl = "images\\software-images\\gps-logger\\5.png",
                        Description = "Open side bar",
                        SoftwareProjectId = 4
                    }
                );

            modelBuilder.Entity<SoftwareProject>()
                .HasData(
                    new SoftwareProject
                    {
                        Id = 1,
                        Name = "Runescape Calculator",
                        ProjectRef = "rsCalc",
                        Description = "Skill action calculator for video game Runescape",
                        DateCreated = DateTime.Parse("2013/01/01"),
                    },
                    new SoftwareProject
                    {
                        Id = 2,
                        Name = "University e-commerce book store",
                        ProjectRef = "uniEcomm",
                        DateCreated = DateTime.Parse("2016/10/01"),
                    },
                    new SoftwareProject
                    {
                        Id = 3,
                        Name = "Loyalty Pro Android App",
                        ProjectRef = "loyaltyProApp",
                        DateCreated = DateTime.Parse("2016/10/01"),
                    },
                    new SoftwareProject
                    {
                        Id = 4,
                        Name = "University Dissertation - GPS Logger",
                        ProjectRef = "uniDis",
                        DateCreated = DateTime.Parse("2017/05/01"),
                    }
            );
        }
    }
}
