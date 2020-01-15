using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRO1.Models
{
    public partial class s17090Context : DbContext
    {
        public s17090Context()
        {
        }

        public s17090Context(DbContextOptions<s17090Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Dodatki> Dodatki { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<SkladnikiPizza> SkladnikiPizza { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17090;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Dodatki>(entity =>
            {
                entity.HasKey(e => e.IdDodatki)
                    .HasName("Dodatki_pk");

                entity.Property(e => e.IdDodatki)
                    .HasColumnName("Id_Dodatki")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("Id_Pizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownika)
                    .HasName("Pracownik_pk");

                entity.Property(e => e.IdPracownika)
                    .HasColumnName("Id_Pracownika")
                    .ValueGeneratedNever();

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasColumnName("haslo")
                    .HasMaxLength(20);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.HasKey(e => e.IdPromocji)
                    .HasName("Promocja_pk");

                entity.Property(e => e.IdPromocji)
                    .HasColumnName("Id_Promocji")
                    .ValueGeneratedNever();

                entity.Property(e => e.DodatkiIdDodatki).HasColumnName("Dodatki_Id_Dodatki");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_Id_Pizza");

                entity.HasOne(d => d.DodatkiIdDodatkiNavigation)
                    .WithMany(p => p.Promocja)
                    .HasForeignKey(d => d.DodatkiIdDodatki)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promocja_Dodatki");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.Promocja)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promocja_Pizza");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("ID_Skladnik");

                entity.Property(e => e.IdSkladnik)
                    .HasColumnName("Id_Skladnik")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("smallmoney");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<SkladnikiPizza>(entity =>
            {
                entity.HasKey(e => new { e.SkladnikIdSkladnik, e.PizzaIdPizza })
                    .HasName("SkladnikiPizza_pk");

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_Id_Skladnik");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_Id_Pizza");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.SkladnikiPizza)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_4_Pizza");

                entity.HasOne(d => d.SkladnikIdSkladnikNavigation)
                    .WithMany(p => p.SkladnikiPizza)
                    .HasForeignKey(d => d.SkladnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_4_Skladnik");
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienia)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienia)
                    .HasColumnName("Id_Zamowienia")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DodatkiIdDodatki).HasColumnName("Dodatki_Id_Dodatki");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_Id_Pizza");

                entity.Property(e => e.PromocjaIdPromocji).HasColumnName("Promocja_Id_Promocji");

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_Id_Skladnik");

                entity.Property(e => e.SposobPlatnosci)
                    .IsRequired()
                    .HasColumnName("Sposob_platnosci")
                    .HasMaxLength(20);

                entity.HasOne(d => d.DodatkiIdDodatkiNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.DodatkiIdDodatki)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Dodatki");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pizza");

                entity.HasOne(d => d.PromocjaIdPromocjiNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.PromocjaIdPromocji)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Promocja");

                entity.HasOne(d => d.SkladnikIdSkladnikNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.SkladnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Skladnik");
            });
        }
    }
}
