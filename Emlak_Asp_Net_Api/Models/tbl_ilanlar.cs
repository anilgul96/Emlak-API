namespace Emlak_Asp_Net_Api.Models
{
    public class tbl_ilanlar
    {
        public int Id { get; set; }

        public string ilan_baslik { get; set; }
        public string ilan_detay { get; set; }
        public string ilan_fiyat { get; set; }
        public int ilan_goruntuleme { get; set; }
        public int ilan_turu_Id { get; set; }
        public string ilan_resim { get; set; }
        public int  ilan_kategori_Id { get; set; }
        public DateTime tarih { get; set; }
        public int ekleyen_kullanici_Id { get; set; }
    }

}
