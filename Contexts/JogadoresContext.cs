using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Jogadores.Domains;

namespace Jogadores.Contexts
{
    public partial class JogadoresContext : DbContext
    {
        public JogadoresContext()
        {
        }

        public JogadoresContext(DbContextOptions<JogadoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jogador> Jogador { get; set; }
        public virtual DbSet<Jogo> Jogo { get; set; }
        public virtual DbSet<JogosJogador> JogosJogador { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAB107801\\SQLEXPRESS2; Initial Catalog= bdJogador; User Id=sa; Password=sa132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogador>(entity =>
            {
                entity.Property(e => e.DataNasc).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jogo>(entity =>
            {
                entity.Property(e => e.DataLanc).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JogosJogador>(entity =>
            {
                entity.HasOne(d => d.IdJogadorNavigation)
                    .WithMany(p => p.JogosJogador)
                    .HasForeignKey(d => d.IdJogador)
                    .HasConstraintName("FK__JogosJoga__IdJog__3B75D760");

                entity.HasOne(d => d.IdJogoNavigation)
                    .WithMany(p => p.JogosJogador)
                    .HasForeignKey(d => d.IdJogo)
                    .HasConstraintName("FK__JogosJoga__IdJog__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
