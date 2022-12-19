using Database_Service.Models;
using Database_Service.Services;
using Database_Service.Services.DataServices;
using Microsoft.EntityFrameworkCore;
using ProtoBuf;
using ProtoBuf.Grpc.Reflection;
using ProtoBuf.Meta;
using System.Collections.Generic;

namespace Database_Service
{
    public class PDatabase : DbContext
    {
        public PDatabase()
        { }

        #region DataSets
        public DbSet<User> Users { get; set; }

        public DbSet<Qr> Qrs { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        #endregion

        #region Overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=host.docker.internal;Database=tokendb;Username=postgres;Password=root");
        }

  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {/*
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");*/
            });

            modelBuilder.Entity<Qr>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }

        #endregion

        public static void UpdateDatabase()
        {
            using (PDatabase dbContext = new PDatabase())
            {

                if (dbContext.Database.GetPendingMigrations().Any())
                    dbContext.Database.Migrate();

            }
        }


        #region Private Methods
        public static void UpdateDatabase(IServiceProvider service)
        {
            var dbContext = service.GetRequiredService<PDatabase>();
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                Console.WriteLine("Database de migrate edilmemiş migrationlar bulundu migrate ediliyor");
                try
                {
                    dbContext.Database.Migrate();
                    Console.WriteLine("Başarıyla Migrate Edildi.");
                }
                catch (Exception ex)
                {
                    //Log.ExceptionW(ex.Message, "Migration Gerçekleştirilemedi");
                    //Log.InfoW("Program Kapatılıyor");
                    throw;
                }
            }
            else
            {
                Console.WriteLine("Migration Bulunamadı");
            }
            //Log.InfoW("Default User Varmı Yokmu Kontrol Ediliyor");
          /*  try
            {
                var user = dbContext.Users.Where(user => user.Id == 1).FirstOrDefault();
                if (user is null)
                {
                    Console.WriteLine("User Bulunamadı Ekleme işlemi yapılıyor");
                    dbContext.Users.Add(new User());
                    dbContext.SaveChanges();
                    Console.WriteLine("Default Eleman Eklendi");
                }
                else
                {
                    Console.WriteLine("Default User zaten var");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Default User eklenirken hata");
            }
          */
        }
        #endregion

    }
}
