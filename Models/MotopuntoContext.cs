using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MotoPuntoBack.Models;

public partial class MotopuntoContext : DbContext
{
    public MotopuntoContext()
    {
    }

    public MotopuntoContext(DbContextOptions<MotopuntoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Consultum> Consulta { get; set; }

    public virtual DbSet<Imagen> Imagens { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Moto> Motos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MOTOPUNTO;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consultum>(entity =>
        {
            entity.HasKey(e => e.Idconsulta).HasName("PK__CONSULTA__5181377250654DD9");

            entity.ToTable("CONSULTA");

            entity.Property(e => e.Idconsulta).HasColumnName("IDCONSULTA");
            entity.Property(e => e.Estado)
                .HasDefaultValue(0)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");

            entity.Property(e => e.FechaContacto)
           .HasColumnType("datetime")
           .HasColumnName("FECHACONTACTO");


            entity.Property(e => e.Idmoto).HasColumnName("IDMOTO");
            entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");



            entity.HasOne(d => d.IdmotoNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.Idmoto)
                .HasConstraintName("FK__CONSULTA__IDMOTO__59063A47");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK__CONSULTA__ESTADO__5812160E");
        });

        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.HasKey(e => e.Idmfoto).HasName("PK__IMAGEN__BA6D5E521D1742D2");

            entity.ToTable("IMAGEN");

            entity.Property(e => e.Idmfoto).HasColumnName("IDMFOTO");
            entity.Property(e => e.Idmoto).HasColumnName("IDMOTO");
            entity.Property(e => e.Principal)
                .HasDefaultValue(0)
                .HasColumnName("PRINCIPAL");
            entity.Property(e => e.Urlimagen)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("URLIMAGEN");

            entity.HasOne(d => d.IdmotoNavigation).WithMany(p => p.Imagens)
                .HasForeignKey(d => d.Idmoto)
                .HasConstraintName("FK__IMAGEN__IDMOTO__5441852A");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Idmarca).HasName("PK__MARCA__C8C2A4AAF3E38477");

            entity.ToTable("MARCA");

            entity.Property(e => e.Idmarca).HasColumnName("IDMARCA");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Moto>(entity =>
        {
            entity.HasKey(e => e.Idmoto).HasName("PK__MOTO__E59FF4ACAAC087A5");

            entity.ToTable("MOTO");

            entity.Property(e => e.Idmoto).HasColumnName("IDMOTO");
            entity.Property(e => e.Aceite)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACEITE");
            entity.Property(e => e.Alimentacion)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("ALIMENTACION");
            entity.Property(e => e.Cajacambio)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("CAJACAMBIO");
            entity.Property(e => e.Cilindrada).HasColumnName("CILINDRADA");
            entity.Property(e => e.Combustible)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COMBUSTIBLE");
            entity.Property(e => e.Encendido)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("ENCENDIDO");
            entity.Property(e => e.Idmarca).HasColumnName("IDMARCA");
            entity.Property(e => e.Iluminacion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ILUMINACION");
            entity.Property(e => e.Motor)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("MOTOR");
            entity.Property(e => e.Neumaticod)
                .HasMaxLength(65)
                .IsUnicode(false)
                .HasColumnName("NEUMATICOD");
            entity.Property(e => e.Neumaticot)
                .HasMaxLength(65)
                .IsUnicode(false)
                .HasColumnName("NEUMATICOT");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Potencia)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("POTENCIA");
            entity.Property(e => e.Precio).HasColumnName("PRECIO");
            entity.Property(e => e.Refrigeracion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("REFRIGERACION");
            entity.Property(e => e.Suspenciond)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("SUSPENCIOND");
            entity.Property(e => e.Suspenciont)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("SUSPENCIONT");
            entity.Property(e => e.Tanquel).HasColumnName("TANQUEL");
            entity.Property(e => e.Tipomoto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPOMOTO");
            entity.Property(e => e.Transmision)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TRANSMISION");

            entity.HasOne(d => d.IdmarcaNavigation).WithMany(p => p.Motos)
                .HasForeignKey(d => d.Idmarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MOTO__IDMARCA__5070F446");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Idrol).HasName("PK__ROL__A686519E6EB2D8D1");

            entity.ToTable("ROL");

            entity.Property(e => e.Idrol).HasColumnName("IDROL");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__USUARIO__98242AA9EEBC75B6");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTRASENA");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Idrol).HasColumnName("IDROL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NUMERO");

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idrol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USUARIO__IDROL__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
