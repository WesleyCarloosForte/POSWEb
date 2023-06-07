﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230606021606_createKardex2")]
    partial class createKardex2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SharedProject.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("SharedProject.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DatosGeneralesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DatosGeneralesId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SharedProject.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool?>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NumeroComprobante")
                        .HasColumnType("longtext");

                    b.Property<int?>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalCompra")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("SharedProject.Models.DatosGenerales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("DocumentoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentoId");

                    b.ToTable("DatosGenerales");
                });

            modelBuilder.Entity("SharedProject.Models.DetalleCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("CodigoBarras")
                        .HasColumnType("longtext");

                    b.Property<int>("CompraId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<decimal>("PrecioCompraUnitario")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCompra")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetalleCompras");
                });

            modelBuilder.Entity("SharedProject.Models.DetalleVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("CodigoBarras")
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PrecioCompra")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PrecioVenta")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCompra")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TotalVenta")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("VentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaId");

                    b.ToTable("DetalleVentas");
                });

            modelBuilder.Entity("SharedProject.Models.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<short>("CantidadDigitos")
                        .HasColumnType("smallint");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<bool?>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("SharedProject.Models.KardexProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadMovimiento")
                        .HasColumnType("int");

                    b.Property<string>("Descripcioin")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("GananciaEsperada")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("NumeroComprobante")
                        .HasColumnType("longtext");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("longtext");

                    b.Property<string>("TipoComprobante")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("ValorCompra")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("stockActual")
                        .HasColumnType("int");

                    b.Property<int>("stockAnterior")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.ToTable("KardexProductos");
                });

            modelBuilder.Entity("SharedProject.Models.NumeracionComprobante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Establecimiento")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<bool?>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("FinVigencia")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("InicioVigencia")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("NumeroActual")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroFinal")
                        .HasColumnType("int");

                    b.Property<string>("PuntoExpedicion")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Timbrado")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("ValorFiscal")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("NumeracionComprobantes");
                });

            modelBuilder.Entity("SharedProject.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoBarras")
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<decimal>("PrecioCompra")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PrecioVenta")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("StockActual")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal?>("StockMinimo")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("SharedProject.Models.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DatosGeneralesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DatosGeneralesId");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("SharedProject.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SharedProject.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DatosGeneralesId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DatosGeneralesId");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SharedProject.Models.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("ComprobanteId")
                        .HasColumnType("int");

                    b.Property<string>("Establecimiento")
                        .HasColumnType("longtext");

                    b.Property<bool?>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NumeroComprobante")
                        .HasColumnType("longtext");

                    b.Property<string>("PuntoExpedicion")
                        .HasColumnType("longtext");

                    b.Property<string>("Timbrado")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("TotalCompra")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ComprobanteId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("SharedProject.Models.Cliente", b =>
                {
                    b.HasOne("SharedProject.Models.DatosGenerales", "DatosGenerales")
                        .WithMany()
                        .HasForeignKey("DatosGeneralesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DatosGenerales");
                });

            modelBuilder.Entity("SharedProject.Models.Compra", b =>
                {
                    b.HasOne("SharedProject.Models.Proveedor", "Proveedor")
                        .WithMany("Compras")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("SharedProject.Models.DatosGenerales", b =>
                {
                    b.HasOne("SharedProject.Models.Documento", "Documento")
                        .WithMany()
                        .HasForeignKey("DocumentoId");

                    b.Navigation("Documento");
                });

            modelBuilder.Entity("SharedProject.Models.DetalleCompra", b =>
                {
                    b.HasOne("SharedProject.Models.Compra", "Compra")
                        .WithMany("DetallesCompra")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SharedProject.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("SharedProject.Models.DetalleVenta", b =>
                {
                    b.HasOne("SharedProject.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SharedProject.Models.Venta", "Venta")
                        .WithMany("DetallesVenta")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("SharedProject.Models.KardexProducto", b =>
                {
                    b.HasOne("SharedProject.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("SharedProject.Models.Producto", b =>
                {
                    b.HasOne("SharedProject.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("SharedProject.Models.Proveedor", b =>
                {
                    b.HasOne("SharedProject.Models.DatosGenerales", "DatosGenerales")
                        .WithMany()
                        .HasForeignKey("DatosGeneralesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DatosGenerales");
                });

            modelBuilder.Entity("SharedProject.Models.Usuario", b =>
                {
                    b.HasOne("SharedProject.Models.DatosGenerales", "DatosGenerales")
                        .WithMany()
                        .HasForeignKey("DatosGeneralesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedProject.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId");

                    b.Navigation("DatosGenerales");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("SharedProject.Models.Venta", b =>
                {
                    b.HasOne("SharedProject.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SharedProject.Models.NumeracionComprobante", "Comprobante")
                        .WithMany()
                        .HasForeignKey("ComprobanteId");

                    b.Navigation("Cliente");

                    b.Navigation("Comprobante");
                });

            modelBuilder.Entity("SharedProject.Models.Compra", b =>
                {
                    b.Navigation("DetallesCompra");
                });

            modelBuilder.Entity("SharedProject.Models.Proveedor", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("SharedProject.Models.Venta", b =>
                {
                    b.Navigation("DetallesVenta");
                });
#pragma warning restore 612, 618
        }
    }
}
