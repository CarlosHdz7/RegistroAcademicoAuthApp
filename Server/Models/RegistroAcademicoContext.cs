using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegistroAcademicoApp.Server.Models
{
    public partial class RegistroAcademicoContext : DbContext
    {
        public RegistroAcademicoContext()
        {
        }

        public RegistroAcademicoContext(DbContextOptions<RegistroAcademicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<DireccionEstudiantes> DireccionEstudiantes { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Facultad> Facultad { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }
        public virtual DbSet<Maestros> Maestros { get; set; }
        public virtual DbSet<Seccion> Seccion { get; set; }
        public virtual DbSet<EncRegistroAcademico> EncRegistroAcademcico { get; set; }
        public virtual DbSet<DetRegistroAcademico> DetRegistroAcademico { get; set; }
        public virtual DbSet<CuposCursos> CuposCurso { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Perfil> Perfiles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("server=DESKTOP-5UM1U18\\SQLEXPRESS;database=RegistroAcademico3;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.CursoId);

                entity.HasIndex(e => e.OnLineMaestrosId);

                entity.HasIndex(e => e.PresencialMaestrosId);

                entity.Property(e => e.OnLineMaestrosId).HasColumnName("onLineMaestrosId");

                entity.Property(e => e.PresencialMaestrosId).HasColumnName("presencialMaestrosID");

                entity.HasOne(d => d.OnLineMaestros)
                    .WithMany(p => p.CursosOnLineMaestros)
                    .HasForeignKey(d => d.OnLineMaestrosId);

                entity.HasOne(d => d.PresencialMaestros)
                    .WithMany(p => p.CursosPresencialMaestros)
                    .HasForeignKey(d => d.PresencialMaestrosId);
            });

            modelBuilder.Entity<DireccionEstudiantes>(entity =>
            {
                entity.HasKey(e => e.IdDireccionEstudiante);

                entity.HasIndex(e => e.EstudianteIdEstudiante);

                entity.HasOne(d => d.EstudianteIdEstudianteNavigation)
                    .WithMany(p => p.DireccionEstudiantes)
                    .HasForeignKey(d => d.EstudianteIdEstudiante);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante);

                entity.HasIndex(e => e.CursosCursoId);

                entity.HasIndex(e => e.FacultadRefId);

                entity.HasIndex(e => e.GradoId);

                entity.Property(e => e.Altura).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CursosCurso)
                    .WithMany(p => p.Estudiante)
                    .HasForeignKey(d => d.CursosCursoId);

                entity.HasOne(d => d.FacultadRef)
                    .WithMany(p => p.Estudiante)
                    .HasForeignKey(d => d.FacultadRefId);

                entity.HasOne(d => d.Grado)
                    .WithMany(p => p.Estudiante)
                    .HasForeignKey(d => d.GradoId);
            });

            modelBuilder.Entity<Maestros>(entity =>
            {
                entity.HasKey(e => e.MaestroId);
            });

            modelBuilder.Entity<Seccion>(entity =>
            {
                entity.HasKey(e => e.IdSeccion);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
