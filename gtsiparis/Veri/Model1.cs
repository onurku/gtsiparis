namespace gtsiparis
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using gtsiparis.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;
    public partial class Model1 : IdentityDbContext
    {
        public Model1()
            : base("name=dbContext")
        {
        }

        public static Model1 Create()
        {
            return new Model1();
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Birim> Birim { get; set; }
        public virtual DbSet<Grup> Grup { get; set; }
        public virtual DbSet<GrupIndeksi> GrupIndeksi { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<IL> IL { get; set; }
        public virtual DbSet<Ilce> Ilce { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Lokasyon> Lokasyon { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Siparis> Siparis { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<Stok> Stok { get; set; }
        public virtual DbSet<IdentityUserLogin> UserLogins { get; set; }
        public virtual DbSet<IdentityUserClaim> UserClaims { get; set; }
        public virtual DbSet<IdentityUserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("gtadmin");
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            modelBuilder.Entity<Urun>()
                .Property(p => p.RowVersion).IsConcurrencyToken();

            modelBuilder.Entity<Birim>()
                .HasMany(e => e.Urun)
                .WithOptional(e => e.Birim)
                .HasForeignKey(e => e.Birim_Id);

            modelBuilder.Entity<Grup>()
                .HasMany(e => e.Kategori)
                .WithOptional(e => e.Grup)
                .HasForeignKey(e => e.Grup_Id);

            modelBuilder.Entity<Grup>()
                .HasMany(e => e.Indeks)
                .WithOptional(e => e.Grup)
                .HasForeignKey(e => e.GrupId);

            modelBuilder.Entity<Grup>()
                .HasMany(e => e.Urun)
                .WithOptional(e => e.Grup)
                .HasForeignKey(e => e.Grup_Id);

            modelBuilder.Entity<IL>()
                .HasMany(e => e.Ilce)
                .WithOptional(e => e.IL)
                .HasForeignKey(e => e.IL_Id);

            modelBuilder.Entity<IL>()
                .HasMany(e => e.Lokasyon)
                .WithOptional(e => e.IL)
                .HasForeignKey(e => e.IL_Id);

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Urun)
                .WithOptional(e => e.Kategori)
                .HasForeignKey(e => e.Kategori_Id);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Siparis)
                .WithOptional(e => e.Kullanici)
                .HasForeignKey(e => e.Kullanici_Id);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Siparis1)
                .WithOptional(e => e.Onaylayan)
                .HasForeignKey(e => e.OnayKullaniciId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Urun)
                .WithOptional(e => e.Sorumlu)
                .HasForeignKey(e => e.Sorumlu_Id);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Urun1)
                .WithOptional(e => e.Uretici)
                .HasForeignKey(e => e.Uretici_Id);

            modelBuilder.Entity<Lokasyon>()
                .HasMany(e => e.Grup)
                .WithOptional(e => e.Lokasyon)
                .HasForeignKey(e => e.Lokasyon_Id);

            modelBuilder.Entity<Lokasyon>()
                .HasMany(e => e.Kategori)
                .WithOptional(e => e.Lokasyon)
                .HasForeignKey(e => e.Lokasyon_Id);

            modelBuilder.Entity<Urun>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.Siparisler)
                .WithOptional(e => e.Urun)
                .HasForeignKey(e => e.Urun_Id)
                .WillCascadeOnDelete(true); ;

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.Stoklar)
                .WithOptional(e => e.Urun)
                .HasForeignKey(e => e.UrunId)
                .WillCascadeOnDelete(true); ;
            // User tables
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());

            // - - - - - 

        }
    }
}
