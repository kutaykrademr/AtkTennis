using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class ankarateniskulubudbContext : DbContext
    {
        public ankarateniskulubudbContext()
        {
        }

        public ankarateniskulubudbContext(DbContextOptions<ankarateniskulubudbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AjandaDetay> AjandaDetays { get; set; }
        public virtual DbSet<AjandaDosya> AjandaDosyas { get; set; }
        public virtual DbSet<AjandaIslemGrubu> AjandaIslemGrubus { get; set; }
        public virtual DbSet<AjandaKullanici> AjandaKullanicis { get; set; }
        public virtual DbSet<AjandaNot> AjandaNots { get; set; }
        public virtual DbSet<Ajandum> Ajanda { get; set; }
        public virtual DbSet<CizelgeSkalasi> CizelgeSkalasis { get; set; }
        public virtual DbSet<Dolap> Dolaps { get; set; }
        public virtual DbSet<EmailSablon> EmailSablons { get; set; }
        public virtual DbSet<Ilce> Ilces { get; set; }
        public virtual DbSet<Kort> Korts { get; set; }
        public virtual DbSet<KortRezervasyon> KortRezervasyons { get; set; }
        public virtual DbSet<KortRezervasyonFiyatlandirma> KortRezervasyonFiyatlandirmas { get; set; }
        public virtual DbSet<KortRezervasyonIptal> KortRezervasyonIptals { get; set; }
        public virtual DbSet<KortRezervasyonOdeme> KortRezervasyonOdemes { get; set; }
        public virtual DbSet<KortRezervasyonTarihce> KortRezervasyonTarihces { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<KullaniciYetki> KullaniciYetkis { get; set; }
        public virtual DbSet<N2Log> N2Logs { get; set; }
        public virtual DbSet<OkulTuru> OkulTurus { get; set; }
        public virtual DbSet<OnRezervasyon> OnRezervasyons { get; set; }
        public virtual DbSet<RezervasyonAyar> RezervasyonAyars { get; set; }
        public virtual DbSet<RezervasyonFiyatlandirma> RezervasyonFiyatlandirmas { get; set; }
        public virtual DbSet<Sehir> Sehirs { get; set; }
        public virtual DbSet<SendEmail> SendEmails { get; set; }
        public virtual DbSet<SendEmailAliciKullanici> SendEmailAliciKullanicis { get; set; }
        public virtual DbSet<SendEmailAliciUye> SendEmailAliciUyes { get; set; }
        public virtual DbSet<Smsbaslik> Smsbasliks { get; set; }
        public virtual DbSet<Smshesap> Smshesaps { get; set; }
        public virtual DbSet<Smsmesaj> Smsmesajs { get; set; }
        public virtual DbSet<SmsmesajAliciKullanici> SmsmesajAliciKullanicis { get; set; }
        public virtual DbSet<SmsmesajAliciUye> SmsmesajAliciUyes { get; set; }
        public virtual DbSet<SmssablonMesaj> SmssablonMesajs { get; set; }
        public virtual DbSet<Uye> Uyes { get; set; }
        public virtual DbSet<UyeAidat> UyeAidats { get; set; }
        public virtual DbSet<UyeAidatOdeme> UyeAidatOdemes { get; set; }
        public virtual DbSet<UyeAidatTarihce> UyeAidatTarihces { get; set; }
        public virtual DbSet<UyeAile> UyeAiles { get; set; }
        public virtual DbSet<UyeBakiye> UyeBakiyes { get; set; }
        public virtual DbSet<UyeBakiyeHarcama> UyeBakiyeHarcamas { get; set; }
        public virtual DbSet<UyeDolap> UyeDolaps { get; set; }
        public virtual DbSet<UyeDolapOdeme> UyeDolapOdemes { get; set; }
        public virtual DbSet<UyeFiyatlandirma> UyeFiyatlandirmas { get; set; }
        public virtual DbSet<UyeRehber> UyeRehbers { get; set; }
        public virtual DbSet<UyeRehberGrup> UyeRehberGrups { get; set; }
        public virtual DbSet<UyeRehberKategori> UyeRehberKategoris { get; set; }
        public virtual DbSet<Yetki> Yetkis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=94.73.151.2;Database=ankarateniskulubudb;Trusted_Connection=False; User Id=ankarateniskulub;Password=_Rez2017ncL;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<AjandaDetay>(entity =>
            {
                entity.ToTable("AjandaDetay");

                entity.Property(e => e.AjandaId).HasColumnName("Ajanda_Id");

                entity.Property(e => e.KullaniciId).HasColumnName("Kullanici_Id");

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.HasOne(d => d.Ajanda)
                    .WithMany(p => p.AjandaDetays)
                    .HasForeignKey(d => d.AjandaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AjandaDetay_Ajanda");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.AjandaDetays)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AjandaDetay_Kullanici");
            });

            modelBuilder.Entity<AjandaDosya>(entity =>
            {
                entity.ToTable("AjandaDosya");

                entity.Property(e => e.Aciklama).HasMaxLength(350);

                entity.Property(e => e.AjandaId).HasColumnName("Ajanda_Id");

                entity.Property(e => e.DosyaYolu)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KullaniciId).HasColumnName("Kullanici_Id");

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.HasOne(d => d.Ajanda)
                    .WithMany(p => p.AjandaDosyas)
                    .HasForeignKey(d => d.AjandaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AjandaDosya_Ajanda");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.AjandaDosyas)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AjandaDosya_Kullanici");
            });

            modelBuilder.Entity<AjandaIslemGrubu>(entity =>
            {
                entity.ToTable("AjandaIslemGrubu");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.RenkKodu)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<AjandaKullanici>(entity =>
            {
                entity.ToTable("AjandaKullanici");

                entity.Property(e => e.AjandaId).HasColumnName("Ajanda_Id");

                entity.Property(e => e.KullaniciId).HasColumnName("Kullanici_Id");

                entity.Property(e => e.OkunmaTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Ajanda)
                    .WithMany(p => p.AjandaKullanicis)
                    .HasForeignKey(d => d.AjandaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AjandaKullanici_Ajanda");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.AjandaKullanicis)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AjandaKullanici_Kullanici");
            });

            modelBuilder.Entity<AjandaNot>(entity =>
            {
                entity.ToTable("AjandaNot");

                entity.Property(e => e.AjandaId).HasColumnName("Ajanda_Id");

                entity.Property(e => e.KullaniciId).HasColumnName("Kullanici_Id");

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.HasOne(d => d.Ajanda)
                    .WithMany(p => p.AjandaNots)
                    .HasForeignKey(d => d.AjandaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AjandaNot_Ajanda");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.AjandaNots)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AjandaNot_Kullanici");
            });

            modelBuilder.Entity<Ajandum>(entity =>
            {
                entity.Property(e => e.AjandaIslemGrubuId).HasColumnName("AjandaIslemGrubu_Id");

                entity.Property(e => e.BaslamaTarihi).HasColumnType("datetime");

                entity.Property(e => e.Baslik)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.BitisTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklenmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenKullaniciId).HasColumnName("EkleyenKullanici_Id");

                entity.Property(e => e.Icerik)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.KullaniciId).HasColumnName("Kullanici_Id");

                entity.HasOne(d => d.AjandaIslemGrubu)
                    .WithMany(p => p.Ajanda)
                    .HasForeignKey(d => d.AjandaIslemGrubuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ajanda_AjandaIslemGrubu");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.Ajanda)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ajanda_Kullanici");
            });

            modelBuilder.Entity<CizelgeSkalasi>(entity =>
            {
                entity.ToTable("CizelgeSkalasi");

                entity.Property(e => e.Adi).HasMaxLength(50);

                entity.Property(e => e.ClassName).HasMaxLength(250);

                entity.Property(e => e.KisaKod)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Style).HasMaxLength(250);
            });

            modelBuilder.Entity<Dolap>(entity =>
            {
                entity.ToTable("Dolap");

                entity.Property(e => e.Kodu)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<EmailSablon>(entity =>
            {
                entity.ToTable("EMailSablon");

                entity.Property(e => e.Baslik)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Icerik)
                    .IsRequired()
                    .HasMaxLength(1080);
            });

            modelBuilder.Entity<Ilce>(entity =>
            {
                entity.ToTable("Ilce");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SehirId).HasColumnName("Sehir_Id");

                entity.HasOne(d => d.Sehir)
                    .WithMany(p => p.Ilces)
                    .HasForeignKey(d => d.SehirId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SehirEntity2");
            });

            modelBuilder.Entity<Kort>(entity =>
            {
                entity.ToTable("Kort");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.Kodu)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Pt0)
                    .HasMaxLength(250)
                    .HasColumnName("PT0");

                entity.Property(e => e.Pt1)
                    .HasMaxLength(250)
                    .HasColumnName("PT1");

                entity.Property(e => e.Pt2)
                    .HasMaxLength(250)
                    .HasColumnName("PT2");

                entity.Property(e => e.Pt3)
                    .HasMaxLength(250)
                    .HasColumnName("PT3");

                entity.Property(e => e.Pt4)
                    .HasMaxLength(250)
                    .HasColumnName("PT4");

                entity.Property(e => e.Pt5)
                    .HasMaxLength(250)
                    .HasColumnName("PT5");

                entity.Property(e => e.Pt6)
                    .HasMaxLength(250)
                    .HasColumnName("PT6");
            });

            modelBuilder.Entity<KortRezervasyon>(entity =>
            {
                entity.ToTable("KortRezervasyon");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.KortId).HasColumnName("Kort_Id");

                entity.Property(e => e.Saat)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Tarih).HasColumnType("date");

                entity.Property(e => e.UyeId).HasColumnName("Uye_Id");

                entity.HasOne(d => d.IslemTuruNavigation)
                    .WithMany(p => p.KortRezervasyons)
                    .HasForeignKey(d => d.IslemTuru)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KortRezervasyon_CizelgeSkalasi");

                entity.HasOne(d => d.Kort)
                    .WithMany(p => p.KortRezervasyons)
                    .HasForeignKey(d => d.KortId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KortRezervasyon_Kort");

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.KortRezervasyons)
                    .HasForeignKey(d => d.UyeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KortRezervasyon_Uye");
            });

            modelBuilder.Entity<KortRezervasyonFiyatlandirma>(entity =>
            {
                entity.ToTable("KortRezervasyonFiyatlandirma");

                entity.Property(e => e.KortRezervasyonId).HasColumnName("KortRezervasyon_Id");

                entity.Property(e => e.RezervasyonFiyatlandirmaId).HasColumnName("RezervasyonFiyatlandirma_Id");

                entity.HasOne(d => d.KortRezervasyon)
                    .WithMany(p => p.KortRezervasyonFiyatlandirmas)
                    .HasForeignKey(d => d.KortRezervasyonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KortRezervasyonFiyatlandirma_KortRezervasyon");

                entity.HasOne(d => d.RezervasyonFiyatlandirma)
                    .WithMany(p => p.KortRezervasyonFiyatlandirmas)
                    .HasForeignKey(d => d.RezervasyonFiyatlandirmaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KortRezervasyonFiyatlandirma_RezervasyonFiyatlandirma");
            });

            modelBuilder.Entity<KortRezervasyonIptal>(entity =>
            {
                entity.ToTable("KortRezervasyonIptal");

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.IslemYapanKullaniciId).HasColumnName("IslemYapanKullanici_Id");

                entity.Property(e => e.KortRezervasyonId).HasColumnName("KortRezervasyon_Id");

                entity.Property(e => e.SaatSecimi)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.HasOne(d => d.KortRezervasyon)
                    .WithMany(p => p.KortRezervasyonIptals)
                    .HasForeignKey(d => d.KortRezervasyonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KortRezervasyonIptal_KortRezervasyon");
            });

            modelBuilder.Entity<KortRezervasyonOdeme>(entity =>
            {
                entity.ToTable("KortRezervasyonOdeme");

                entity.Property(e => e.KortRezervasyonId).HasColumnName("KortRezervasyon_Id");

                entity.Property(e => e.MakbuzNumarasi).HasMaxLength(20);

                entity.Property(e => e.MakbuzTarihi).HasColumnType("date");

                entity.Property(e => e.OdemeTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.KortRezervasyon)
                    .WithMany(p => p.KortRezervasyonOdemes)
                    .HasForeignKey(d => d.KortRezervasyonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KortRezervasyonOdeme_KortRezervasyon");
            });

            modelBuilder.Entity<KortRezervasyonTarihce>(entity =>
            {
                entity.ToTable("KortRezervasyonTarihce");

                entity.Property(e => e.Aciklama).HasMaxLength(150);

                entity.Property(e => e.Baslik)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.KortRezervasyonId).HasColumnName("KortRezervasyon_Id");

                entity.Property(e => e.KullaniciId).HasColumnName("Kullanici_Id");

                entity.HasOne(d => d.KortRezervasyon)
                    .WithMany(p => p.KortRezervasyonTarihces)
                    .HasForeignKey(d => d.KortRezervasyonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KortRezervasyonTarihce_KortRezervasyon");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.KortRezervasyonTarihces)
                    .HasForeignKey(d => d.KullaniciId)
                    .HasConstraintName("FK_KortRezervasyonTarihce_Kullanici");
            });

            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.ToTable("Kullanici");

                entity.Property(e => e.AdiSoyadi)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Avatar).HasMaxLength(50);

                entity.Property(e => e.CepTelefon).HasMaxLength(50);

                entity.Property(e => e.DogumTarihi).HasColumnType("date");

                entity.Property(e => e.EvAdresi).HasMaxLength(250);

                entity.Property(e => e.EvTelefon).HasMaxLength(20);

                entity.Property(e => e.Ipadresi)
                    .HasMaxLength(20)
                    .HasColumnName("IPAdresi");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.Sifre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Smslogin).HasColumnName("SMSLogin");

                entity.Property(e => e.Tckimlik)
                    .HasMaxLength(11)
                    .HasColumnName("TCKimlik");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<KullaniciYetki>(entity =>
            {
                entity.HasKey(e => new { e.KullaniciId, e.YetkiId })
                    .IsClustered(false);

                entity.ToTable("KullaniciYetki");

                entity.Property(e => e.KullaniciId).HasColumnName("Kullanici_Id");

                entity.Property(e => e.YetkiId).HasColumnName("Yetki_Id");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.KullaniciYetkis)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciYetki_Kullanici");

                entity.HasOne(d => d.Yetki)
                    .WithMany(p => p.KullaniciYetkis)
                    .HasForeignKey(d => d.YetkiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciYetki_Yetki");
            });

            modelBuilder.Entity<N2Log>(entity =>
            {
                entity.ToTable("n2Log");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.KortRezervasyonId).HasColumnName("KortRezervasyon_Id");

                entity.Property(e => e.KullaniciId).HasColumnName("Kullanici_Id");

                entity.Property(e => e.Url).HasMaxLength(500);

                entity.Property(e => e.UyeId).HasColumnName("Uye_Id");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.N2Logs)
                    .HasForeignKey(d => d.KullaniciId)
                    .HasConstraintName("FK_n2Log_Kullanici");

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.N2Logs)
                    .HasForeignKey(d => d.UyeId)
                    .HasConstraintName("FK_n2Log_Uye");
            });

            modelBuilder.Entity<OkulTuru>(entity =>
            {
                entity.ToTable("OkulTuru");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CizelgeSkalasiId).HasColumnName("CizelgeSkalasi_Id");

                entity.HasOne(d => d.CizelgeSkalasi)
                    .WithMany(p => p.OkulTurus)
                    .HasForeignKey(d => d.CizelgeSkalasiId)
                    .HasConstraintName("FK_OkulTuru_CizelgeSkalasi");
            });

            modelBuilder.Entity<OnRezervasyon>(entity =>
            {
                entity.ToTable("OnRezervasyon");

                entity.Property(e => e.BaslamaTarihi).HasColumnType("date");

                entity.Property(e => e.GunSecimi)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.IslemYapanKullaniciId).HasColumnName("IslemYapanKullanici_Id");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.KortId).HasColumnName("Kort_Id");

                entity.Property(e => e.SaatSecimi)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UyeId).HasColumnName("Uye_Id");

                entity.HasOne(d => d.IslemYapanKullanici)
                    .WithMany(p => p.OnRezervasyons)
                    .HasForeignKey(d => d.IslemYapanKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnRezervasyon_Kullanici");

                entity.HasOne(d => d.Kort)
                    .WithMany(p => p.OnRezervasyons)
                    .HasForeignKey(d => d.KortId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnRezervasyon_Kort");

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.OnRezervasyons)
                    .HasForeignKey(d => d.UyeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnRezervasyon_Uye");
            });

            modelBuilder.Entity<RezervasyonAyar>(entity =>
            {
                entity.ToTable("RezervasyonAyar");

                entity.Property(e => e.Baslik)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Deger)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RezervasyonFiyatlandirma>(entity =>
            {
                entity.ToTable("RezervasyonFiyatlandirma");

                entity.Property(e => e.Aciklama).HasMaxLength(150);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AyBilgisi).HasMaxLength(50);

                entity.Property(e => e.GunBilgisi).HasMaxLength(20);

                entity.Property(e => e.SaatBilgisi).HasMaxLength(250);
            });

            modelBuilder.Entity<Sehir>(entity =>
            {
                entity.ToTable("Sehir");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SendEmail>(entity =>
            {
                entity.ToTable("SendEmail");

                entity.Property(e => e.Baslik)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.GonderenKullaniciId).HasColumnName("GonderenKullanici_Id");

                entity.Property(e => e.GondermeTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.GonderenKullanici)
                    .WithMany(p => p.SendEmails)
                    .HasForeignKey(d => d.GonderenKullaniciId)
                    .HasConstraintName("FK_SendEmail_Kullanici");
            });

            modelBuilder.Entity<SendEmailAliciKullanici>(entity =>
            {
                entity.ToTable("SendEmailAliciKullanici");

                entity.Property(e => e.KullaniciId).HasColumnName("Kullanici_Id");

                entity.Property(e => e.SendEmailId).HasColumnName("SendEmail_Id");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.SendEmailAliciKullanicis)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SendEmailAliciKullanici_Kullanici");
            });

            modelBuilder.Entity<SendEmailAliciUye>(entity =>
            {
                entity.ToTable("SendEmailAliciUye");

                entity.Property(e => e.SendEmailId).HasColumnName("SendEmail_Id");

                entity.Property(e => e.UyeRehberId).HasColumnName("UyeRehber_Id");

                entity.HasOne(d => d.UyeRehber)
                    .WithMany(p => p.SendEmailAliciUyes)
                    .HasForeignKey(d => d.UyeRehberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SendEmailAliciUye_UyeRehber");
            });

            modelBuilder.Entity<Smsbaslik>(entity =>
            {
                entity.ToTable("SMSBaslik");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.SmshesapId).HasColumnName("SMSHesap_Id");

                entity.HasOne(d => d.Smshesap)
                    .WithMany(p => p.Smsbasliks)
                    .HasForeignKey(d => d.SmshesapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SMSBaslik_SMSHesap");
            });

            modelBuilder.Entity<Smshesap>(entity =>
            {
                entity.ToTable("SMSHesap");

                entity.Property(e => e.AlphanumericPrice).HasColumnName("Alphanumeric_price");

                entity.Property(e => e.InternationalPrice).HasColumnName("International_price");

                entity.Property(e => e.NumericPrice).HasColumnName("Numeric_price");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Smskredi).HasColumnName("SMSKredi");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Smsmesaj>(entity =>
            {
                entity.ToTable("SMSMesaj");

                entity.Property(e => e.DonenMesajId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("DonenMesaj_Id");

                entity.Property(e => e.GonderenKullaniciId).HasColumnName("GonderenKullanici_Id");

                entity.Property(e => e.GondermeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Icerik)
                    .IsRequired()
                    .HasMaxLength(1080);

                entity.Property(e => e.SmsbaslikId).HasColumnName("SMSBaslik_Id");

                entity.Property(e => e.Smssayisi).HasColumnName("SMSSayisi");

                entity.HasOne(d => d.GonderenKullanici)
                    .WithMany(p => p.Smsmesajs)
                    .HasForeignKey(d => d.GonderenKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SMSMesaj_Kullanici");

                entity.HasOne(d => d.Smsbaslik)
                    .WithMany(p => p.Smsmesajs)
                    .HasForeignKey(d => d.SmsbaslikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SMSMesaj_SMSBaslik");
            });

            modelBuilder.Entity<SmsmesajAliciKullanici>(entity =>
            {
                entity.ToTable("SMSMesajAliciKullanici");

                entity.Property(e => e.Gsmno)
                    .HasMaxLength(50)
                    .HasColumnName("GSMNo");

                entity.Property(e => e.KullaniciId).HasColumnName("Kullanici_Id");

                entity.Property(e => e.ReceiverId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Receiver_Id");

                entity.Property(e => e.SmsmesajId).HasColumnName("SMSMesaj_Id");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.SmsmesajAliciKullanicis)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SMSMesajAliciKullanici_Kullanici");

                entity.HasOne(d => d.Smsmesaj)
                    .WithMany(p => p.SmsmesajAliciKullanicis)
                    .HasForeignKey(d => d.SmsmesajId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SMSMesajAliciKullanici_SMSMesaj");
            });

            modelBuilder.Entity<SmsmesajAliciUye>(entity =>
            {
                entity.ToTable("SMSMesajAliciUye");

                entity.Property(e => e.ReceiverId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Receiver_Id");

                entity.Property(e => e.SmsmesajId).HasColumnName("SMSMesaj_Id");

                entity.Property(e => e.UyeRehberId).HasColumnName("UyeRehber_Id");

                entity.HasOne(d => d.Smsmesaj)
                    .WithMany(p => p.SmsmesajAliciUyes)
                    .HasForeignKey(d => d.SmsmesajId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SMSMesajAliciUye_SMSMesaj");

                entity.HasOne(d => d.UyeRehber)
                    .WithMany(p => p.SmsmesajAliciUyes)
                    .HasForeignKey(d => d.UyeRehberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SMSMesajAliciUye_UyeRehber");
            });

            modelBuilder.Entity<SmssablonMesaj>(entity =>
            {
                entity.ToTable("SMSSablonMesaj");

                entity.Property(e => e.Baslik)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Icerik)
                    .IsRequired()
                    .HasMaxLength(1080);
            });

            modelBuilder.Entity<Uye>(entity =>
            {
                entity.ToTable("Uye");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.AnneAdi).HasMaxLength(50);

                entity.Property(e => e.BabaAdi).HasMaxLength(50);

                entity.Property(e => e.DogumTarihi).HasColumnType("date");

                entity.Property(e => e.DogumYeri).HasMaxLength(80);

                entity.Property(e => e.DolapId).HasColumnName("Dolap_Id");

                entity.Property(e => e.Gorsel).HasMaxLength(150);

                entity.Property(e => e.IlceId).HasColumnName("Ilce_Id");

                entity.Property(e => e.Ipadresi)
                    .HasMaxLength(20)
                    .HasColumnName("IPAdresi");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.Meslek).HasMaxLength(80);

                entity.Property(e => e.ReferansUye1Id).HasColumnName("ReferansUye1_Id");

                entity.Property(e => e.ReferansUye2Id).HasColumnName("ReferansUye2_Id");

                entity.Property(e => e.RenkKodu).HasMaxLength(10);

                entity.Property(e => e.RenkKoduFn).HasMaxLength(10);

                entity.Property(e => e.Rumuz)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SehirId).HasColumnName("Sehir_Id");

                entity.Property(e => e.Sifre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SonGirisTarihi).HasColumnType("datetime");

                entity.Property(e => e.Soyadi).HasMaxLength(80);

                entity.Property(e => e.Tckimlik)
                    .HasMaxLength(11)
                    .HasColumnName("TCKimlik");

                entity.Property(e => e.UyelikBaslamaTarihi).HasColumnType("datetime");

                entity.Property(e => e.UyelikBitisTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Dolap)
                    .WithMany(p => p.Uyes)
                    .HasForeignKey(d => d.DolapId)
                    .HasConstraintName("FK_Uye_Dolap");

                entity.HasOne(d => d.Ilce)
                    .WithMany(p => p.Uyes)
                    .HasForeignKey(d => d.IlceId)
                    .HasConstraintName("FK_Uye_Ilce");

                entity.HasOne(d => d.Sehir)
                    .WithMany(p => p.Uyes)
                    .HasForeignKey(d => d.SehirId)
                    .HasConstraintName("FK_Uye_Sehir");
            });

            modelBuilder.Entity<UyeAidat>(entity =>
            {
                entity.ToTable("UyeAidat");

                entity.Property(e => e.Aciklama).HasMaxLength(150);

                entity.Property(e => e.IslemYapanKullaniciId).HasColumnName("IslemYapanKullanici_Id");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.UyeFiyatlandirmaId).HasColumnName("UyeFiyatlandirma_Id");

                entity.Property(e => e.UyeId).HasColumnName("Uye_Id");

                entity.HasOne(d => d.UyeFiyatlandirma)
                    .WithMany(p => p.UyeAidats)
                    .HasForeignKey(d => d.UyeFiyatlandirmaId)
                    .HasConstraintName("FK_UyeAidat_UyeFiyatlandirma");

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.UyeAidats)
                    .HasForeignKey(d => d.UyeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeAidat_Uye");
            });

            modelBuilder.Entity<UyeAidatOdeme>(entity =>
            {
                entity.ToTable("UyeAidatOdeme");

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.IslemYapanKullaniciId).HasColumnName("IslemYapanKullanici_Id");

                entity.Property(e => e.MakbuzNumarasi).HasMaxLength(50);

                entity.Property(e => e.MakbuzTarihi).HasColumnType("date");

                entity.Property(e => e.OdemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.UyeAidatId).HasColumnName("UyeAidat_Id");

                entity.HasOne(d => d.IslemYapanKullanici)
                    .WithMany(p => p.UyeAidatOdemes)
                    .HasForeignKey(d => d.IslemYapanKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeAidatOdeme_Kullanici");

                entity.HasOne(d => d.UyeAidat)
                    .WithMany(p => p.UyeAidatOdemes)
                    .HasForeignKey(d => d.UyeAidatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeAidatOdeme_UyeAidat");
            });

            modelBuilder.Entity<UyeAidatTarihce>(entity =>
            {
                entity.ToTable("UyeAidatTarihce");

                entity.Property(e => e.Aciklama).HasMaxLength(150);

                entity.Property(e => e.Baslik)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.KullaniciId).HasColumnName("Kullanici_Id");

                entity.Property(e => e.UyeAidatId).HasColumnName("UyeAidat_Id");

                entity.Property(e => e.UyeId).HasColumnName("Uye_Id");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.UyeAidatTarihces)
                    .HasForeignKey(d => d.KullaniciId)
                    .HasConstraintName("FK_UyeAidatTarihce_Kullanici");

                entity.HasOne(d => d.UyeAidat)
                    .WithMany(p => p.UyeAidatTarihces)
                    .HasForeignKey(d => d.UyeAidatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeAidatTarihce_UyeAidat");

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.UyeAidatTarihces)
                    .HasForeignKey(d => d.UyeId)
                    .HasConstraintName("FK_UyeAidatTarihce_Uye");
            });

            modelBuilder.Entity<UyeAile>(entity =>
            {
                entity.ToTable("UyeAile");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.CepTel).HasMaxLength(20);

                entity.Property(e => e.DogumTarihi).HasColumnType("datetime");

                entity.Property(e => e.DolapId).HasColumnName("Dolap_Id");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.Meslegi).HasMaxLength(80);

                entity.Property(e => e.Rumuz).HasMaxLength(15);

                entity.Property(e => e.Soyadi)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Tckimlik)
                    .HasMaxLength(50)
                    .HasColumnName("TCKimlik");

                entity.Property(e => e.UyeId).HasColumnName("Uye_Id");

                entity.HasOne(d => d.Dolap)
                    .WithMany(p => p.UyeAiles)
                    .HasForeignKey(d => d.DolapId)
                    .HasConstraintName("FK_UyeAile_Dolap");

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.UyeAiles)
                    .HasForeignKey(d => d.UyeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeAile_Uye");
            });

            modelBuilder.Entity<UyeBakiye>(entity =>
            {
                entity.ToTable("UyeBakiye");

                entity.Property(e => e.Aciklama).HasMaxLength(150);

                entity.Property(e => e.EkleyenKullaniciId).HasColumnName("EkleyenKullanici_Id");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.MakbuzNumarasi).HasMaxLength(20);

                entity.Property(e => e.MakbuzTarihi).HasColumnType("date");

                entity.Property(e => e.UyeId).HasColumnName("Uye_Id");

                entity.HasOne(d => d.EkleyenKullanici)
                    .WithMany(p => p.UyeBakiyes)
                    .HasForeignKey(d => d.EkleyenKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeBakiye_Kullanici");

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.UyeBakiyes)
                    .HasForeignKey(d => d.UyeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeBakiye_Uye");
            });

            modelBuilder.Entity<UyeBakiyeHarcama>(entity =>
            {
                entity.ToTable("UyeBakiyeHarcama");

                entity.Property(e => e.Aciklama).HasMaxLength(150);

                entity.Property(e => e.IlgiliId).HasColumnName("Ilgili_Id");

                entity.Property(e => e.IslemYapanKullaniciId).HasColumnName("IslemYapanKullanici_Id");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.UyeBakiyeId).HasColumnName("UyeBakiye_Id");

                entity.HasOne(d => d.IslemYapanKullanici)
                    .WithMany(p => p.UyeBakiyeHarcamas)
                    .HasForeignKey(d => d.IslemYapanKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeBakiyeHarcama_Kullanici");

                entity.HasOne(d => d.UyeBakiye)
                    .WithMany(p => p.UyeBakiyeHarcamas)
                    .HasForeignKey(d => d.UyeBakiyeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeBakiyeHarcama_UyeBakiye");
            });

            modelBuilder.Entity<UyeDolap>(entity =>
            {
                entity.ToTable("UyeDolap");

                entity.Property(e => e.Aciklama).HasMaxLength(150);

                entity.Property(e => e.DolapId).HasColumnName("Dolap_Id");

                entity.Property(e => e.IslemYapanKullaniciId).HasColumnName("IslemYapanKullanici_Id");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.UyeId).HasColumnName("Uye_Id");

                entity.HasOne(d => d.Dolap)
                    .WithMany(p => p.UyeDolaps)
                    .HasForeignKey(d => d.DolapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeDolap_Dolap");

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.UyeDolaps)
                    .HasForeignKey(d => d.UyeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeDolap_Uye");
            });

            modelBuilder.Entity<UyeDolapOdeme>(entity =>
            {
                entity.ToTable("UyeDolapOdeme");

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.IslemYapanKullaniciId).HasColumnName("IslemYapanKullanici_Id");

                entity.Property(e => e.MakbuzNumarasi).HasMaxLength(50);

                entity.Property(e => e.MakbuzTarihi).HasColumnType("date");

                entity.Property(e => e.OdemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.UyeDolapId).HasColumnName("UyeDolap_Id");

                entity.HasOne(d => d.IslemYapanKullanici)
                    .WithMany(p => p.UyeDolapOdemes)
                    .HasForeignKey(d => d.IslemYapanKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeDolapOdeme_Kullanici");

                entity.HasOne(d => d.UyeDolap)
                    .WithMany(p => p.UyeDolapOdemes)
                    .HasForeignKey(d => d.UyeDolapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeDolapOdeme_UyeDolap");
            });

            modelBuilder.Entity<UyeFiyatlandirma>(entity =>
            {
                entity.ToTable("UyeFiyatlandirma");

                entity.Property(e => e.Aciklama).HasMaxLength(250);

                entity.Property(e => e.IslemYapanKullaniciId).HasColumnName("IslemYapanKullanici_Id");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<UyeRehber>(entity =>
            {
                entity.ToTable("UyeRehber");

                entity.Property(e => e.Bilgi)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.BilgiAciklama).HasMaxLength(500);

                entity.Property(e => e.IlceId).HasColumnName("Ilce_Id");

                entity.Property(e => e.SehirId).HasColumnName("Sehir_Id");

                entity.Property(e => e.Smsgonderme).HasColumnName("SMSGonderme");

                entity.Property(e => e.UyeId).HasColumnName("Uye_Id");

                entity.HasOne(d => d.Ilce)
                    .WithMany(p => p.UyeRehbers)
                    .HasForeignKey(d => d.IlceId)
                    .HasConstraintName("FK_UyeRehber_Ilce");

                entity.HasOne(d => d.Sehir)
                    .WithMany(p => p.UyeRehbers)
                    .HasForeignKey(d => d.SehirId)
                    .HasConstraintName("FK_UyeRehber_Sehir");

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.UyeRehbers)
                    .HasForeignKey(d => d.UyeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeRehber_Uye");
            });

            modelBuilder.Entity<UyeRehberGrup>(entity =>
            {
                entity.ToTable("UyeRehberGrup");

                entity.Property(e => e.UyeId).HasColumnName("Uye_Id");

                entity.Property(e => e.UyeRehberKategoriId).HasColumnName("UyeRehberKategori_Id");

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.UyeRehberGrups)
                    .HasForeignKey(d => d.UyeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeRehberGrup_Uye");

                entity.HasOne(d => d.UyeRehberKategori)
                    .WithMany(p => p.UyeRehberGrups)
                    .HasForeignKey(d => d.UyeRehberKategoriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UyeRehberGrup_UyeRehberKategori");
            });

            modelBuilder.Entity<UyeRehberKategori>(entity =>
            {
                entity.ToTable("UyeRehberKategori");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UstUyeRehberKategoriId).HasColumnName("UstUyeRehberKategori_Id");
            });

            modelBuilder.Entity<Yetki>(entity =>
            {
                entity.ToTable("Yetki");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UstYetkiId).HasColumnName("UstYetki_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
