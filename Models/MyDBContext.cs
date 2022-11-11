using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMS02.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Ouners> Ouners { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permisions> Permisions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            builder.Entity<Ouners>()
                .HasKey(o => new { o.UserId, o.DocumentId });
            builder.Entity<Roles>()
                .HasKey(o => new { o.UserId, o.RoleId });

            base.OnModelCreating(builder);
        }
    }



    public class User
    {
        [Required]
        public int UserId { get; set; }
        
        [StringLength(255)]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        // this I shoul include some hash strategy to store passwords, this may be implemented in a future version.
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Required]
        [ForeignKey("State")]
        public int StateId { get; set; }
    }

    public class State
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string StateName { get; set; }
    }

    public class Ouners
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int DocumentId { get; set; }
    }

    public class Document
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int DocumentId { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        // 0 = photo, 1 = video, 2 = pfd, 3 = txt, -1 = generic file
        [Required]
        public int DocTipe { get; set; }

        [Required]
        [DisplayName("Show description?")]
        public Boolean ShowDescription { get; set; }

        [Required]
        [DisplayName("Make public?")]
        public Boolean Public { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }

    public class Roles
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoleId { get; set; }
    }

    public class Permisions
    {
        [Required]
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }

        [Required]
        public int MaxPictureSize { get; set; }

        [Required]
        public int MaxVideoSize { get; set; }

        [Required]
        public int MaxPDFSize { get; set; }

        [Required]
        public int MaxPictureAmount { get; set; }

        [Required]
        public int MaxVideoAmount { get; set; }

        [Required]
        public int MaxPDFAmount { get; set; }

        [Required]
        public Boolean CanShare { get; set; }

        [Required]
        public Boolean CanUseGenerics { get; set; }
    }
}
