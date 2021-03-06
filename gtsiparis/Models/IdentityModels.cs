﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;

namespace gtsiparis
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        [EmailAddress]
        [Display(Name = "Referans Email Adresi")]
        public string RefEmail { get; set; }

        [Display(Name = "Adı")]
        public string Adi { get; set; }

        [Display(Name = "Soyadi")]
        public string Soyadi { get; set; }

        [Display(Name = "Kullanici Adi")]
        public string UserNick { get; set; }

        [Display(Name = "Adı Soyadı")]
        public string AdSoyad
        {
            get { return Adi + " " + Soyadi; }
        } [Display(Name = "WebAdmin")]
        public bool? WebAdmin { get; set; }

        [Display(Name = "Türetici")]
        public bool? Turetici { get; set; }

        [Display(Name = "Grup Admin")]
        public bool? GrupAdmin { get; set; }

        [Display(Name = "Üretici")]
        public bool? Uretici { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kategori> Kategori { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrupIndeksi> Indeks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparis> Siparis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparis> Siparis1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urun> Urun { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urun> Urun1 { get; set; }


    }
}