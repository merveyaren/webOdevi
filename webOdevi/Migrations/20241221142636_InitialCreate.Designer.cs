﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using webOdevi.Models;

#nullable disable

namespace webOdevi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241221142636_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("webOdevi.Models.musteriler", b =>
                {
                    b.Property<int>("musteriid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("musteriid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("musteriid"));

                    b.Property<string>("eposta")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("eposta");

                    b.Property<string>("musteriadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("musteriadi");

                    b.Property<string>("musterisoyadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("musterisoyadi");

                    b.Property<string>("musteritelefon")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("musteritelefon");

                    b.Property<string>("sifre")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sifre");

                    b.HasKey("musteriid");

                    b.ToTable("musteriler", (string)null);
                });

            modelBuilder.Entity("webOdevi.Models.personel", b =>
                {
                    b.Property<int>("personelid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("personelid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("personelid"));

                    b.Property<DateTime>("isebaslamatarihi")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("isebaslamatarihi");

                    b.Property<string>("personeladi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("personeladi");

                    b.Property<string>("personeleposta")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("personeleposta");

                    b.Property<string>("personelsoyadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("personelsoyadi");

                    b.Property<string>("personeltelefon")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("personeltelefon");

                    b.Property<string>("pozisyon")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("pozisyon");

                    b.HasKey("personelid");

                    b.ToTable("personel", (string)null);
                });

            modelBuilder.Entity("webOdevi.Models.randevular", b =>
                {
                    b.Property<int>("randevuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("randevuid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("randevuid"));

                    b.Property<TimeSpan>("baslangicsaati")
                        .HasColumnType("interval")
                        .HasColumnName("baslangicsaati");

                    b.Property<TimeSpan>("bitissaati")
                        .HasColumnType("interval")
                        .HasColumnName("bitissaati");

                    b.Property<string>("durum")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("durum");

                    b.Property<int>("hizmetid")
                        .HasColumnType("integer")
                        .HasColumnName("hizmetid");

                    b.Property<int>("musteriid")
                        .HasColumnType("integer")
                        .HasColumnName("musteriid");

                    b.Property<int>("personelid")
                        .HasColumnType("integer")
                        .HasColumnName("personelid");

                    b.Property<DateTime>("randevutarihi")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("randevutarihi");

                    b.HasKey("randevuid");

                    b.HasIndex("hizmetid");

                    b.HasIndex("musteriid");

                    b.HasIndex("personelid");

                    b.ToTable("randevular", (string)null);
                });

            modelBuilder.Entity("webOdevi.Models.randevuonay", b =>
                {
                    b.Property<int>("onayid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("onayid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("onayid"));

                    b.Property<string>("onaydurum")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("onaydurum");

                    b.Property<int>("onaylayancalisan")
                        .HasColumnType("integer")
                        .HasColumnName("onaylayancalisan");

                    b.Property<DateTime>("onaytarihi")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("onaytarihi");

                    b.Property<int>("randevuid")
                        .HasColumnType("integer")
                        .HasColumnName("randevuid");

                    b.HasKey("onayid");

                    b.HasIndex("onaylayancalisan");

                    b.HasIndex("randevuid");

                    b.ToTable("randevuonay", (string)null);
                });

            modelBuilder.Entity("webOdevi.Models.services", b =>
                {
                    b.Property<int>("hizmetid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("hizmetid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("hizmetid"));

                    b.Property<decimal>("fiyat")
                        .HasColumnType("numeric")
                        .HasColumnName("fiyat");

                    b.Property<string>("hizmetadi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("hizmetadi");

                    b.HasKey("hizmetid");

                    b.ToTable("services", (string)null);
                });

            modelBuilder.Entity("webOdevi.Models.uygunluk", b =>
                {
                    b.Property<int>("uygunlukid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("uygunlukid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("uygunlukid"));

                    b.Property<TimeSpan>("baslangicsaati")
                        .HasColumnType("interval")
                        .HasColumnName("baslangicsaati");

                    b.Property<TimeSpan>("bitissaati")
                        .HasColumnType("interval")
                        .HasColumnName("bitissaati");

                    b.Property<int>("personelid")
                        .HasColumnType("integer")
                        .HasColumnName("personelid");

                    b.Property<DateTime>("tarih")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("tarih");

                    b.HasKey("uygunlukid");

                    b.HasIndex("personelid");

                    b.ToTable("uygunluk", (string)null);
                });

            modelBuilder.Entity("webOdevi.Models.randevular", b =>
                {
                    b.HasOne("webOdevi.Models.services", "Hizmet")
                        .WithMany()
                        .HasForeignKey("hizmetid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webOdevi.Models.musteriler", "Musteri")
                        .WithMany()
                        .HasForeignKey("musteriid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webOdevi.Models.personel", "Personel")
                        .WithMany()
                        .HasForeignKey("personelid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hizmet");

                    b.Navigation("Musteri");

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("webOdevi.Models.randevuonay", b =>
                {
                    b.HasOne("webOdevi.Models.personel", "Personel")
                        .WithMany()
                        .HasForeignKey("onaylayancalisan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webOdevi.Models.randevular", "Randevu")
                        .WithMany()
                        .HasForeignKey("randevuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");

                    b.Navigation("Randevu");
                });

            modelBuilder.Entity("webOdevi.Models.uygunluk", b =>
                {
                    b.HasOne("webOdevi.Models.personel", "Personel")
                        .WithMany()
                        .HasForeignKey("personelid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });
#pragma warning restore 612, 618
        }
    }
}
