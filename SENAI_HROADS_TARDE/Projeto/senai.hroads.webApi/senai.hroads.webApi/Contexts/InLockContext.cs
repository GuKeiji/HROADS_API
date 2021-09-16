using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Domains;

#nullable disable

namespace senai.hroads.webApi_.Contexts
{
    public partial class InLockContext : DbContext
    {
        public InLockContext()
        {
        }

        public InLockContext(DbContextOptions<InLockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<Classehabilidade> Classehabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<Tipohabilidade> Tipohabilidades { get; set; }
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PC-GAMER-GUKEIJ\\SQLEXPRESS; initial catalog=HROADS; user Id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__CLASSE__60FFF8018AE4DA6A");

                entity.ToTable("CLASSE");

                entity.Property(e => e.IdClasse)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idClasse");

                entity.Property(e => e.NomeClasse)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeClasse");
            });

            modelBuilder.Entity<Classehabilidade>(entity =>
            {
                entity.HasKey(e => e.IdClasseHabilidade)
                    .HasName("PK__CLASSEHA__5FC96972B609A79A");

                entity.ToTable("CLASSEHABILIDADE");

                entity.Property(e => e.IdClasseHabilidade).HasColumnName("idClasseHabilidade");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Classehabilidades)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__CLASSEHAB__idCla__403A8C7D");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.Classehabilidades)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__CLASSEHAB__idHab__412EB0B6");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__HABILIDA__655F75281FB556BB");

                entity.ToTable("HABILIDADE");

                entity.Property(e => e.IdHabilidade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idHabilidade");

                entity.Property(e => e.IdTipoHabilidade).HasColumnName("idTipoHabilidade");

                entity.Property(e => e.NomeHabilidade)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nomeHabilidade");

                entity.HasOne(d => d.IdTipoHabilidadeNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoHabilidade)
                    .HasConstraintName("FK__HABILIDAD__idTip__3A81B327");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__PERSONAG__E175C72E946EDFEC");

                entity.ToTable("PERSONAGEM");

                entity.Property(e => e.IdPersonagem).HasColumnName("idPersonagem");

                entity.Property(e => e.CapacidadeMaxMana).HasColumnName("capacidadeMaxMana");

                entity.Property(e => e.CapacidadeMaxVida).HasColumnName("capacidadeMaxVida");

                entity.Property(e => e.DataAtualizacao)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dataAtualizacao");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dataCriacao");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.NomePersonagem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomePersonagem");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__PERSONAGE__idCla__3D5E1FD2");
            });

            modelBuilder.Entity<Tipohabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabilidade)
                    .HasName("PK__TIPOHABI__B197B83237EB6C0C");

                entity.ToTable("TIPOHABILIDADE");

                entity.Property(e => e.IdTipoHabilidade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoHabilidade");

                entity.Property(e => e.NomeTipoHabilidade)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoHabilidade");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPOUSUA__03006BFF57FDBBA6");

                entity.ToTable("TIPOUSUARIO");

                entity.HasIndex(e => e.Titulo, "UQ__TIPOUSUA__38FA640FD571397F")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A6B8318A1D");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Email, "UQ__USUARIO__AB6E616448793962")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIO__idTipoU__52593CB8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
