using Microsoft.EntityFrameworkCore;
using Repository.Modelos;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ClienteDTO> ClientesEF { get; set; }
    public DbSet<FacturaDTO> FacturasEF { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de ClienteDTO
        modelBuilder.Entity<ClienteDTO>(entity =>
        {
            entity.ToTable("cliente"); // Especificar el nombre de la tabla
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdBanco).HasColumnName("id_banco");
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(255).IsRequired();
            entity.Property(e => e.Apellido).HasColumnName("apellido").HasMaxLength(255).IsRequired();
            entity.Property(e => e.Documento).HasColumnName("documento").HasMaxLength(255).IsRequired();
            entity.Property(e => e.Direccion).HasColumnName("direccion").HasMaxLength(255);
            entity.Property(e => e.Celular).HasColumnName("celular").HasMaxLength(255).IsRequired();
            entity.Property(e => e.Email).HasColumnName("mail").HasMaxLength(255);
            entity.Property(e => e.Estado).HasColumnName("estado").HasMaxLength(255);
        });

        // Configuración de FacturaDTO (si es necesario)
        modelBuilder.Entity<FacturaDTO>(entity =>
        {
            entity.ToTable("factura"); // Especificar el nombre de la tabla
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente").HasMaxLength(12).IsRequired();
            entity.Property(e => e.NroFactura).HasColumnName("nro_factura").HasMaxLength(12).IsRequired();
            entity.Property(e => e.FechaHora).HasColumnName("fecha_hora").IsRequired();
            entity.Property(e => e.Total).HasColumnName("total").HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(e => e.TotalIvaCinco).HasColumnName("total_iva5").HasColumnType("decimal(18,2)");
            entity.Property(e => e.TotalIvaDiez).HasColumnName("total_iva10").HasColumnType("decimal(18,2)");
            entity.Property(e => e.TotalIva).HasColumnName("total_iva").HasColumnType("decimal(18,2)");
            entity.Property(e => e.TotalLetras).HasColumnName("total_letras").HasMaxLength(255);
            entity.Property(e => e.Sucursal).HasColumnName("sucursal").HasMaxLength(255);
        });
    }
}
