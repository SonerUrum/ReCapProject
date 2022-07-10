using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{  //database tabloları ile proje classları burada bağlanır. DbContext indirdiğimiz paketten gelen bir yapı bunu kullanarak context yapıyoruz.
    public class CarDatabaseContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //bu method projenin veritabanıyla ilişkili olduğunu belirteceğimiz yer
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarDatabase;Trusted_Connection=true"); //database'in adresini veriyoruz.
        }
        public DbSet<Car> Cars { get; set; } //car nesnemi database tablosu olan cars ile bağla
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
