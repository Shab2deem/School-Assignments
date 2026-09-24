using LibraryWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI.DBMODEL
{
    public class DataBaseContext:DbContext
    {
        public DbSet<Book> Books {  get; set; }
       public DbSet<BorrowRecord> BorrowRecords {  get; set; }
        public DbSet<Category> Categories {  get; set; }
       public DbSet<Member> Members {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Book>().HasKey(a => a.Id);
            modelBuilder.Entity<BorrowRecord>().HasKey(a => a.Id);
            modelBuilder.Entity<Category>().HasKey(a => a.Id);
            modelBuilder.Entity<Member>().HasKey(a => a.Id);
            modelBuilder.Entity<Category>().HasMany(a=>a.Books).WithOne(c=>c.Category).HasForeignKey(a=>a.CategoryId);
            modelBuilder.Entity<Member>().HasMany(m=>m.BorrowRecords).WithOne(b=>b.member).HasForeignKey(a=>a.memberId);
            modelBuilder.Entity<Book>().HasMany(a=>a.BorrowRecords).WithOne(b=>b.book).HasForeignKey(a=>a.bookId);
            modelBuilder.Entity<Category>().HasIndex(a=>a.Name).IsUnique();
            modelBuilder.Entity<Member>().HasIndex(a=>a.Email).IsUnique();
            modelBuilder.Entity<BorrowRecord>().Property(a => a.BorrowDate).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Book>().Property(k => k.Price).HasPrecision(10, 2);
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id=1,
                    Name="Action",
                    
                }
                
                );
            modelBuilder.Entity<Book>().HasData(new Book()
            {

                Id = 1,
                Title = "Elshafa3a",
                Author = "Mostafa Mahmoud",
                PublishedYear = 1972,
                Price = 10,
                AvailableCopies = 1,
                CategoryId=1
             




            }, new Book()
            {

                Id = 2,
                Title = "3ala 7afet El Ente7ar",
                Author = "Mostafa Mahmoud",
                PublishedYear = 1984,
                Price = 5,
                AvailableCopies = 5,
              CategoryId=1
                

            });
            

            

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\LibraryServer;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
