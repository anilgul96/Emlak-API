using Emlak_Asp_Net_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Emlak_Asp_Net_Api.Data
{
    public class ApplicationDbContextApp : DbContext
    {
        public virtual DbSet<tbl_ilanlar> tbl_ilanlar { get; set; }
        public virtual DbSet<tbl_kategoriler> tbl_kategoriler { get; set; }
        public virtual DbSet<tbl_kategori_ara> tbl_kategori_ara { get; set; }
        public virtual DbSet<tbl_kullanicilar> tbl_kullanicilar { get; set; }
        public virtual DbSet<tbl_turler> tbl_turler { get; set; }

        public ApplicationDbContextApp(DbContextOptions<ApplicationDbContextApp> options) : base(options) { }
    }
}
