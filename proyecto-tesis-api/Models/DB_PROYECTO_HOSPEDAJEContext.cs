using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace proyecto_tesis_api.Models
{
    public partial class DB_PROYECTO_HOSPEDAJEContext : DbContext
    {
        public DB_PROYECTO_HOSPEDAJEContext()
        {
        }

        public DB_PROYECTO_HOSPEDAJEContext(DbContextOptions<DB_PROYECTO_HOSPEDAJEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DetalleReserva> DetalleReserva { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<ReservaChat> ReservaChat { get; set; }
        public virtual DbSet<ReservaChatText> ReservaChatText { get; set; }
        public virtual DbSet<Temporada> Temporada { get; set; }
        public virtual DbSet<TipoCliente> TipoCliente { get; set; }
        public virtual DbSet<TipoEmpleado> TipoEmpleado { get; set; }
        public virtual DbSet<TipoHabitacion> TipoHabitacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=server;Initial Catalog=bd;User Id=sa;Password=contraseña");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__cliente__677F38F504F033F1");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasColumnName("apellido1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasColumnName("apellido2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasColumnName("documento")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoCliente)
                    .IsRequired()
                    .HasColumnName("id_tipo_cliente")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Nacionalidad)
                    .IsRequired()
                    .HasColumnName("nacionalidad")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasColumnName("tipo_documento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoClienteNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdTipoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cliente__id_tipo__3D5E1FD2");
            });

            modelBuilder.Entity<DetalleReserva>(entity =>
            {
                entity.HasKey(e => e.IdDetalleReserva)
                    .HasName("PK__detalle___93478EF96C5EA6A5");

                entity.ToTable("detalle_reserva");

                entity.Property(e => e.IdDetalleReserva)
                    .HasColumnName("id_detalle_reserva")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.IdHabitacion)
                    .IsRequired()
                    .HasColumnName("id_habitacion")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.IdReserva)
                    .IsRequired()
                    .HasColumnName("id_reserva")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdHabitacionNavigation)
                    .WithMany(p => p.DetalleReserva)
                    .HasForeignKey(d => d.IdHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_r__id_ha__4E88ABD4");

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.DetalleReserva)
                    .HasForeignKey(d => d.IdReserva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_r__id_re__4F7CD00D");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__empleado__88B5139445462634");

                entity.ToTable("empleado");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnName("id_empleado")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoEmpleado)
                    .IsRequired()
                    .HasColumnName("id_tipo_empleado")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoEmpleadoNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdTipoEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__empleado__id_tip__38996AB5");
            });

            modelBuilder.Entity<Habitacion>(entity =>
            {
                entity.HasKey(e => e.IdHabitacion)
                    .HasName("PK__habitaci__773F28F32C255F49");

                entity.ToTable("habitacion");

                entity.Property(e => e.IdHabitacion)
                    .HasColumnName("id_habitacion")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdTipoHabitacion)
                    .IsRequired()
                    .HasColumnName("id_tipo_habitacion")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.NroHabitacion).HasColumnName("nro_habitacion");

                entity.Property(e => e.Piso).HasColumnName("piso");

                entity.HasOne(d => d.IdTipoHabitacionNavigation)
                    .WithMany(p => p.Habitacion)
                    .HasForeignKey(d => d.IdTipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__habitacio__id_ti__4BAC3F29");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__reserva__423CBE5D0ABAD514");

                entity.ToTable("reserva");

                entity.Property(e => e.IdReserva)
                    .HasColumnName("id_reserva")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .HasColumnName("codigo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comprobante)
                    .HasColumnName("comprobante")
                    .HasColumnType("text");

                entity.Property(e => e.Costo)
                    .HasColumnName("costo")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fecha_fin")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fecha_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.Huespedes).HasColumnName("huespedes");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("text");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.IdEmpleado)
                    .HasColumnName("id_empleado")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__reserva__id_clie__44FF419A");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK__reserva__id_empl__45F365D3");
            });

            modelBuilder.Entity<ReservaChat>(entity =>
            {
                entity.HasKey(e => e.IdReservaChat)
                    .HasName("PK__reserva___8D078574B3726375");

                entity.ToTable("reserva_chat");

                entity.Property(e => e.IdReservaChat)
                    .HasColumnName("id_reserva_chat")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.IdReserva)
                    .HasColumnName("id_reserva")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.ReservaChat)
                    .HasForeignKey(d => d.IdReserva)
                    .HasConstraintName("FK__reservachat");
            });

            modelBuilder.Entity<ReservaChatText>(entity =>
            {
                entity.HasKey(e => e.IdReservaChatText)
                    .HasName("PK__reserva___445CB909ED57788A");

                entity.ToTable("reserva_chat_text");

                entity.Property(e => e.IdReservaChatText)
                    .HasColumnName("id_reserva_chat_text")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.IdReservaChat)
                    .IsRequired()
                    .HasColumnName("id_reserva_chat")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Texto)
                    .IsRequired()
                    .HasColumnName("texto")
                    .HasColumnType("text");

                entity.Property(e => e.Formato)
                    .HasColumnName("formato")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdReservaChatNavigation)
                    .WithMany(p => p.ReservaChatText)
                    .HasForeignKey(d => d.IdReservaChat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__reserva_c__id_re__4222D4EF");
            });

            modelBuilder.Entity<Temporada>(entity =>
            {
                entity.HasKey(e => e.IdTemporada)
                    .HasName("PK__temporad__22983743DA29241A");

                entity.ToTable("temporada");

                entity.Property(e => e.IdTemporada)
                    .HasColumnName("id_temporada")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Descuento).HasColumnName("descuento");

                entity.Property(e => e.Fin).HasColumnName("fin");

                entity.Property(e => e.Inicio).HasColumnName("inicio");
            });

            modelBuilder.Entity<TipoCliente>(entity =>
            {
                entity.HasKey(e => e.IdTipoCliente)
                    .HasName("PK__tipo_cli__69D671C5BB3BEC7C");

                entity.ToTable("tipo_cliente");

                entity.Property(e => e.IdTipoCliente)
                    .HasColumnName("id_tipo_cliente")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdTipoEmpleado)
                    .HasName("PK__tipo_emp__F614CD330FBCEF67");

                entity.ToTable("tipo_empleado");

                entity.Property(e => e.IdTipoEmpleado)
                    .HasColumnName("id_tipo_empleado")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoHabitacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabitacion)
                    .HasName("PK__tipo_hab__6A65108CF8B22E62");

                entity.ToTable("tipo_habitacion");

                entity.Property(e => e.IdTipoHabitacion)
                    .HasColumnName("id_tipo_habitacion")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("text");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("text");

                entity.Property(e => e.Limite).HasColumnName("limite");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
