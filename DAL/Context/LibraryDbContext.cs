using LibraryModelling.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModelling.DAL.Context
{
    public class LibraryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;DataBase=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get;}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<BookStore> BookStores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region PropertyOptions

              #region AuthorProperties

            modelBuilder.Entity<Author>(entity=>
            {
                entity.Property(a => a.AuthorName).IsRequired().HasMaxLength(50);
                entity.Property(a => a.AuthorLastName).IsRequired().HasMaxLength(50);
                entity.Property(a => a.AuthorCountry).HasMaxLength(50);
            }
            );
            #endregion

              #region BookProperties
            modelBuilder.Entity<Book>()
              .Property(b => b.BookName).IsRequired().HasMaxLength(50);
            
              #endregion

              #region CategoryProperties

            modelBuilder.Entity<Category>()
                .Property(c=> c.CategoryName).IsRequired().HasMaxLength(100);

            #endregion

              #region BookStoreProperties

            modelBuilder.Entity<BookStore>(entity =>
            {
                entity.Property(bs => bs.BookPublishingHouse).HasMaxLength(100);
                entity.Property(bs => bs.BookStatus).HasMaxLength(100);

            }
            );

              #endregion

              #region LibraryProperties

            modelBuilder.Entity<Library>(entity =>
            {
                entity.Property(l => l.LibraryName).IsRequired().HasMaxLength(100);
                entity.Property(l => l.LibraryAdressPostalCode).HasMaxLength(5);
                entity.Property(l => l.LibraryAdressCity).HasMaxLength(20);
                entity.Property(l => l.LibraryAdressDistrict).HasMaxLength(20);
                entity.Property(l => l.LibraryAdressDetail).HasMaxLength(100);
                entity.Property(l => l.LibraryPhoneNumber).HasMaxLength(20);
                entity.Property(l => l.LibraryStatus).HasMaxLength(100);
            }
            );

            #endregion

              #region UserBookStoreProperties

            modelBuilder.Entity<UserBookStore>(entity =>
            {
                entity.Property(ubs => ubs.BookReceiveDate).IsRequired();
                entity.Property(ubs => ubs.BookDeliveryTime).IsRequired();
            }
            );

            #endregion

              #region UserProperties

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.UserName).IsRequired().HasMaxLength(50);
                entity.Property(u => u.UserLastName).IsRequired().HasMaxLength(50);
                entity.Property(u => u.UserTcIdentityNo).IsRequired().HasMaxLength(11);
                entity.Property(u => u.UserAdressPostalCode).HasMaxLength(5);
                entity.Property(u => u.UserAdressCity).HasMaxLength(20);
                entity.Property(u => u.UserAdressDistrict).HasMaxLength(20);
                entity.Property(u => u.UserAdressDetail).HasMaxLength(10);
                entity.Property(u => u.UserEMail).HasMaxLength(50);
                entity.Property(u => u.UserPhoneNumber).IsRequired().HasMaxLength(20);
                entity.Property(u => u.UserStatus).HasMaxLength(100);

            });

              #endregion

            #endregion

            #region Relationships Between Tables

              #region BookAuthor(Book-Author)

            modelBuilder.Entity<BookAuthor>()
             .HasKey(ba => new { ba.AuthorId, ba.BookId });
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book).WithMany(b => b.Authors)
                .HasForeignKey(ba => ba.BookId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author).WithMany(a => a.Books)
                .HasForeignKey(ba => ba.AuthorId);

            #endregion

              #region AuthorCategory(Author-Category)

            modelBuilder.Entity<AuthorCategory>()
                .HasKey(ac => new { ac.AuthorId, ac.CategoryId });
            modelBuilder.Entity<AuthorCategory>()
                .HasOne(ac => ac.Author).WithMany(a => a.Categories)
                .HasForeignKey(ac => ac.AuthorId);
            modelBuilder.Entity<AuthorCategory>()
                .HasOne(ac => ac.Category).WithMany(c => c.Authors)
                .HasForeignKey(ac => ac.CategoryId);

            #endregion

              #region BookCategory(Book-Category)

            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book).WithMany(b => b.Categories)
                .HasForeignKey(bc=> bc.BookId);
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category).WithMany(c => c.Books)
                .HasForeignKey(bc => bc.CategoryId);
            #endregion

              #region BookStore(BookStore-Book)

            modelBuilder.Entity<BookStore>()
                .HasOne(bs => bs.Book)
                .WithMany(b => b.BookStores)
                .HasForeignKey(bs => bs.BookId);

            #endregion

              #region UserBookStore(User-BookStore)

            modelBuilder.Entity<UserBookStore>()
                .HasKey(ubs => new {ubs.BookStoreId, ubs.UserId});
            modelBuilder.Entity<UserBookStore>()
                .HasOne(ubs => ubs.BookStore).WithMany(bs => bs.Users)
                .HasForeignKey(ubs => ubs.BookStoreId);
            modelBuilder.Entity<UserBookStore>()
                .HasOne(ubs => ubs.User).WithMany(u => u.UserBookStores)
                .HasForeignKey(ubs => ubs.UserId);

            #endregion

              #region LibraryBookStore(Library-BookStore)

            modelBuilder.Entity<LibraryBookStore>()
                .HasKey(lbs => new { lbs.LibraryId, lbs.BookStoreId });
            modelBuilder.Entity<LibraryBookStore>()
                .HasOne(lbs => lbs.Library).WithMany(l => l.BookStores)
                .HasForeignKey(lbs => lbs.LibraryId);
            modelBuilder.Entity<LibraryBookStore>()
                .HasOne(lbs => lbs.BookStore).WithMany(bs => bs.Libraries)
                .HasForeignKey(lbs => lbs.BookStoreId);

            #endregion

              #region LibraryUser(Library-User)

            modelBuilder.Entity<LibraryUser>()
                .HasKey(lu => new { lu.LibraryId, lu.UserId });
            modelBuilder.Entity<LibraryUser>()
                .HasOne(lu => lu.Library).WithMany(l => l.Users)
                .HasForeignKey(lu => lu.LibraryId);
            modelBuilder.Entity<LibraryUser>()
                .HasOne(lu => lu.User).WithMany(u => u.Libraries)
                .HasForeignKey(lu => lu.UserId);

              #endregion


            #endregion

        }
    }
}
