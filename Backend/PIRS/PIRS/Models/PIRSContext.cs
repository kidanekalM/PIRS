﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PIRS.Models.ReportModel;

namespace PIRS.Models
{
    public class PirsContext : IdentityDbContext<UserModel.AppUser>
    {
        public PirsContext(DbContextOptions<PirsContext> options):base(options)
        {

        }
        public DbSet<ImageGallery> ? ImageGallerys { get; set; }
        public DbSet<Report> ? Reports { get; set; }
        public DbSet<InventoryModel.Inventory>? Inventory { get; set; }
        public DbSet<RatingModel.Rating> ? Ratings { get; set;}
        public DbSet<TransactionModel.Transaction>? Transactions { get; set; }
        public DbSet<ReportUpvote>? ReportUpvotes { get; set;}
        public DbSet<Location>? Locations { get; set; }
    }
}
