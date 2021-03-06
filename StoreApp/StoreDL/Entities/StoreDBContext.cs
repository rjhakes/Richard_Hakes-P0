﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreDL.Entities
{
    public partial class StoreDBContext : DbContext
    {
        public StoreDBContext()
        {
        }

        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerCart> CustomerCarts { get; set; }
        public virtual DbSet<CustomerOrderHistory> CustomerOrderHistories { get; set; }
        public virtual DbSet<CustomerOrderLineItem> CustomerOrderLineItems { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryLineItem> InventoryLineItems { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<ManagersCart> ManagersCarts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreOrderHistory> StoreOrderHistories { get; set; }
        public virtual DbSet<StoreOrderLineItem> StoreOrderLineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("category");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.CustomerEmail, "UQ__customer__FFE82D722A92D1DF")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("customerAddress");

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("customerEmail");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("customerName");

                entity.Property(e => e.CustomerPasswordHash)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("customerPasswordHash");

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customerPhone");
            });

            modelBuilder.Entity<CustomerCart>(entity =>
            {
                entity.ToTable("customerCarts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CurrentItemsId).HasColumnName("currentItemsID");

                entity.Property(e => e.CustId).HasColumnName("custID");

                entity.Property(e => e.LocId).HasColumnName("locID");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.CustomerCarts)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK__customerC__custI__0A888742");

                entity.HasOne(d => d.Loc)
                    .WithMany(p => p.CustomerCarts)
                    .HasForeignKey(d => d.LocId)
                    .HasConstraintName("FK__customerC__locID__0B7CAB7B");
            });

            modelBuilder.Entity<CustomerOrderHistory>(entity =>
            {
                entity.ToTable("customerOrderHistory");

                entity.HasIndex(e => e.OrderId, "UQ__customer__0809337C3124B925")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustId).HasColumnName("custID");

                entity.Property(e => e.LocId).HasColumnName("locID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("orderDate");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.CustomerOrderHistories)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK__customerO__custI__07AC1A97");

                entity.HasOne(d => d.Loc)
                    .WithMany(p => p.CustomerOrderHistories)
                    .HasForeignKey(d => d.LocId)
                    .HasConstraintName("FK__customerO__locID__06B7F65E");
            });

            modelBuilder.Entity<CustomerOrderLineItem>(entity =>
            {
                entity.ToTable("customerOrderLineItems");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.ProdId).HasColumnName("prodID");

                entity.Property(e => e.ProdPrice).HasColumnName("prodPrice");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.CustomerOrderLineItems)
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__customerO__prodI__74994623");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.HasIndex(e => e.LocId, "UQ__inventor__793196EAD6F574E2")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LocId).HasColumnName("locID");

                entity.HasOne(d => d.Loc)
                    .WithOne(p => p.Inventory)
                    .HasForeignKey<Inventory>(d => d.LocId)
                    .HasConstraintName("FK__inventory__locID__7B4643B2");
            });

            modelBuilder.Entity<InventoryLineItem>(entity =>
            {
                entity.ToTable("inventoryLineItems");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InventoryId).HasColumnName("inventoryID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.InventoryLineItems)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__inventory__inven__7E22B05D");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InventoryLineItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__inventory__produ__7F16D496");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("locations");

                entity.HasIndex(e => e.LocPhone, "UQ__location__1EB9029E2004F726")
                    .IsUnique();

                entity.HasIndex(e => e.LocName, "UQ__location__2B95D144522CFBE9")
                    .IsUnique();

                entity.HasIndex(e => e.LocAddress, "UQ__location__C08AF830EC5D95FC")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LocAddress)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("locAddress");

                entity.Property(e => e.LocName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("locName");

                entity.Property(e => e.LocPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("locPhone");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("managers");

                entity.HasIndex(e => e.ManagerEmail, "UQ__managers__CFFCD9161CB47E42")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ManagerEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("managerEmail");

                entity.Property(e => e.ManagerLocId).HasColumnName("managerLocID");

                entity.Property(e => e.ManagerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("managerName");

                entity.Property(e => e.ManagerPasswordHash)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("managerPasswordHash");

                entity.Property(e => e.ManagerPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("managerPhone");

                entity.HasOne(d => d.ManagerLoc)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.ManagerLocId)
                    .HasConstraintName("FK__managers__manage__02E7657A");
            });

            modelBuilder.Entity<ManagersCart>(entity =>
            {
                entity.ToTable("managersCarts");

                entity.HasIndex(e => e.ManagerId, "UQ__managers__47E0147EB90E70EB")
                    .IsUnique();

                entity.HasIndex(e => e.LocId, "UQ__managers__793196EA4B9D6C0A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LocId).HasColumnName("locID");

                entity.Property(e => e.ManagerId).HasColumnName("managerID");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.HasOne(d => d.Loc)
                    .WithOne(p => p.ManagersCart)
                    .HasForeignKey<ManagersCart>(d => d.LocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__managersC__locID__113584D1");

                entity.HasOne(d => d.Manager)
                    .WithOne(p => p.ManagersCart)
                    .HasForeignKey<ManagersCart>(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__managersC__manag__10416098");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProdBrandName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("prodBrandName");

                entity.Property(e => e.ProdCategory).HasColumnName("prodCategory");

                entity.Property(e => e.ProdName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("prodName");

                entity.Property(e => e.ProdPrice).HasColumnName("prodPrice");

                entity.HasOne(d => d.ProdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProdCategory)
                    .HasConstraintName("FK__products__prodCa__2C1E8537");
            });

            modelBuilder.Entity<StoreOrderHistory>(entity =>
            {
                entity.ToTable("storeOrderHistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LocId).HasColumnName("locID");

                entity.Property(e => e.ManagerId).HasColumnName("managerID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("orderDate");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Loc)
                    .WithMany(p => p.StoreOrderHistories)
                    .HasForeignKey(d => d.LocId)
                    .HasConstraintName("FK__storeOrde__locID__1411F17C");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.StoreOrderHistories)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__storeOrde__manag__150615B5");
            });

            modelBuilder.Entity<StoreOrderLineItem>(entity =>
            {
                entity.ToTable("storeOrderLineItems");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.ProdId).HasColumnName("prodID");

                entity.Property(e => e.ProdPrice).HasColumnName("prodPrice");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.StoreOrderLineItems)
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__storeOrde__prodI__7775B2CE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
