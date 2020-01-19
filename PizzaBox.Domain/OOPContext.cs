using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Domain
{
    public partial class OOPContext : DbContext
    {
        public OOPContext()
        {
        }

        public OOPContext(DbContextOptions<OOPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompletedOrders> CompletedOrders { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizzas> Pizzas { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-AC2TTFB6\\SQLEXPRESS;Database=OOP;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompletedOrders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Complete__0809335D77822873");

                entity.Property(e => e.OrderId)
                    .HasColumnName("orderId")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.CompletedOrders)
                    .HasForeignKey<CompletedOrders>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Completed__order__440B1D61");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__0809335DBF9CE65A");

                entity.Property(e => e.OrderId)
                    .HasColumnName("orderId")
                    .ValueGeneratedNever();

                entity.Property(e => e.PlacedAt)
                    .HasColumnName("placedAt")
                    .HasColumnType("date");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasColumnName("storeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalCharges)
                    .HasColumnName("totalCharges")
                    .HasColumnType("money");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.StoreNameNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__storeNam__403A8C7D");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__username__412EB0B6");
            });

            modelBuilder.Entity<Pizzas>(entity =>
            {
                entity.HasKey(e => e.PizzaId)
                    .HasName("PK__Pizzas__4D4C90EFAA49721E");

                entity.Property(e => e.PizzaId)
                    .HasColumnName("pizzaId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Crust)
                    .IsRequired()
                    .HasColumnName("crust")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnName("size")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pizzas__username__38996AB5");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreName)
                    .HasName("PK__Store__0E3E451C199CC4C7");

                entity.Property(e => e.StoreName)
                    .HasColumnName("storeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Venue)
                    .IsRequired()
                    .HasColumnName("venue")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK___User__F3DBC5733C3A50F6");

                entity.ToTable("_User");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
