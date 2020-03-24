using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace project0.data.Entities
{
    public partial class project0Context : DbContext
    {
        public project0Context()
        {
        }

        public project0Context(DbContextOptions<project0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customerdb> Customerdb { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<FoodOrder> FoodOrder { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<OrderItem1> OrderItem1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Secretconfig.path);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customerdb>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__customer__72E12F1A1CFBBD6E");

                entity.ToTable("customer", "rest");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Storenum).HasColumnName("storenum");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("food", "rest");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__food__72E12F1B1A83AE2E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Foodtype)
                    .HasColumnName("foodtype")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("smallmoney");
            });

            modelBuilder.Entity<FoodOrder>(entity =>
            {
                entity.HasKey(e => e.Ordernum)
                    .HasName("PK__foodOrde__725C7E1214C3338F");

                entity.ToTable("foodOrder", "rest");

                entity.Property(e => e.Ordernum).HasColumnName("ordernum");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.HasOne(d => d.NameNavigation)
                    .WithMany(p => p.FoodOrder)
                    .HasForeignKey(d => d.Name)
                    .HasConstraintName("FK__foodOrder__name__4F7CD00D");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new { e.Ordernum, e.Id })
                    .HasName("PK__orderIte__917D4091E3247DFB");

                entity.ToTable("orderItem");

                entity.Property(e => e.Ordernum).HasColumnName("ordernum");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderItem__id__534D60F1");

                entity.HasOne(d => d.OrdernumNavigation)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.Ordernum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderItem__order__52593CB8");
            });

            modelBuilder.Entity<OrderItem1>(entity =>
            {
                entity.HasKey(e => new { e.Ordernum, e.Id })
                    .HasName("PK__orderIte__917D409148FE72C8");

                entity.ToTable("orderItem", "rest");

                entity.Property(e => e.Ordernum).HasColumnName("ordernum");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.OrderItem1)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderItem__id__571DF1D5");

                entity.HasOne(d => d.OrdernumNavigation)
                    .WithMany(p => p.OrderItem1)
                    .HasForeignKey(d => d.Ordernum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderItem__order__5629CD9C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
