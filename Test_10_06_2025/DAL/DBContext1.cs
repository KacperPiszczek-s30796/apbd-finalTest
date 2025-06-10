using Microsoft.EntityFrameworkCore;
using Test_10_06_2025.models;

namespace Test_10_06_2025.DAL;

public class DbContext1: DbContext
{
    
    public DbSet<Author> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<PublishingHouse> PublishingHouses { get; set; }

    public DbContext1(DbContextOptions<DbContext1> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasKey(pm => new { pm.IdBook, pm.IdAuthor });

        modelBuilder.Entity<BookAuthor>()
            .HasOne(pm => pm.Book)
            .WithMany()
            .HasForeignKey(pm => pm.IdBook);

        modelBuilder.Entity<BookAuthor>()
            .HasOne(pm => pm.Author)
            .WithMany()
            .HasForeignKey(pm => pm.IdAuthor);
        
        modelBuilder.Entity<BookGenre>()
            .HasKey(pm => new { pm.IdBook, pm.IdGenre });

        modelBuilder.Entity<BookGenre>()
            .HasOne(pm => pm.Book)
            .WithMany()
            .HasForeignKey(pm => pm.IdBook);

        modelBuilder.Entity<BookGenre>()
            .HasOne(pm => pm.Genre)
            .WithMany()
            .HasForeignKey(pm => pm.IdGenre);
        
        modelBuilder.Entity<Book>()
            .HasKey(pm => new { pm.IdPublishingHouse});

        modelBuilder.Entity<Book>()
            .HasOne(pm => pm.PublishingHouse)
            .WithMany()
            .HasForeignKey(pm => pm.IdPublishingHouse);
    }
}