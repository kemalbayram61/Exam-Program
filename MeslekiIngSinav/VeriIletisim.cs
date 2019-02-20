using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace MeslekiIngSinav
{
    class VeriIletisim
    {
        public OleDbConnection Baglanti()
        {
            string blntCumlesi= @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ""C:\Users\Kemal\Desktop\Üniversite 2-2.Donem\İngilizce\MeslekiIngSinav\CumleVT.mdb""";
            OleDbConnection baglanti = new OleDbConnection(blntCumlesi);
            try
            {
                baglanti.Open();
            }catch(Exception hata) { MessageBox.Show(hata.ToString()); }
            return baglanti;
        }
        public DataTable Tablo()
        {
            OleDbConnection baglan = Baglanti();
            string sorgu = "select * from tblCumle";
            OleDbDataAdapter da = new OleDbDataAdapter(sorgu, baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            baglan.Close();
            return dt;
        }
        public void KayitYap(string Cumle)
        {
            OleDbConnection baglan = Baglanti();
            string sorgu = "insert into tblCumle(CUMLE) values(@CUMLE)";
            OleDbCommand komut = new OleDbCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@CUMLE", Cumle);
            komut.ExecuteNonQuery();
            baglan.Close();
        }
        public int KayitSayisi()
        {
            OleDbConnection baglan = Baglanti();
            string sorgu = "select * from tblCumle";
            OleDbCommand komut = new OleDbCommand(sorgu, baglan);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            int sayac = 0;
            while (okuyucu.Read()) { sayac++; }
            return sayac;
        }
        public string CumleVer()
        {
            Random rnd = new Random();
            OleDbConnection baglan = Baglanti();
            string sorgu = "select * from tblCumle";
            OleDbCommand komut = new OleDbCommand(sorgu, baglan);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            int rndCumle = rnd.Next(KayitSayisi()), sayac = 0;
            string cumle = "";
            while (okuyucu.Read())
            {
                if (sayac == rndCumle)cumle = okuyucu["CUMLE"].ToString();
                sayac++;
            }
            baglan.Close();
            return cumle;
        }
        public string rndKelime()
        {
            Random rnd = new Random();
            OleDbConnection baglan = Baglanti();
            string sorgu = "select * from tblCumle";
            OleDbCommand komut = new OleDbCommand(sorgu, baglan);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            int rndCumle = rnd.Next(KayitSayisi()), sayac = 0;
            string cumle = "";
            while (okuyucu.Read())
            {
                if (sayac == rndCumle) cumle = okuyucu["CUMLE"].ToString();
                sayac++;
            }
            baglan.Close();
            string[] parcali = cumle.Split(' ');
            int indis = rnd.Next(parcali.Length);
            return parcali[indis];
        }
    }
}
