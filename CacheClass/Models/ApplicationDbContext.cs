// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;
// using CacheClass.Models;
//
// namespace CacheClass.Models
// {
//     public class ApplicationDbContext : IdentityDbContext<Account>
//     {
//         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//             : base(options)
//         {
//         }
//
//         protected override void OnModelCreating(ModelBuilder builder)
//         {
//             base.OnModelCreating(builder);
//
//             // Configure additional properties for the Account model if needed
//             builder.Entity<Account>(entity =>
//             {
//                 entity.Property(e => e.Role)
//                     .IsRequired();
//             });
//         }
//
//         // Add DbSet for Account if you want to perform additional operations
//         public DbSet<Account> Accounts { get; set; }
//     }
// }