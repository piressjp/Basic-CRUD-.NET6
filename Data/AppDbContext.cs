using Microsoft.EntityFrameworkCore;
using Todo.DTO;
using Todo.Models;

namespace Todo.Data;
public class AppDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("DataSource=app.db;Cache=Shared");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.ToTable("User");

            entity.HasKey(e => e.ID);

            entity.Property(e => e.ID)
            .ValueGeneratedOnAdd();

            entity.Property(e => e.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

            entity.Property(e => e.CPF)
            .IsRequired()
            .HasColumnName("CPF")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(11);

            entity.Property(e => e.Telefone)
            .IsRequired()
            .HasColumnName("Telefone")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(11);

            entity.Property(e => e.DT_Nascimento)
            .IsRequired()
            .HasColumnName("DT_Nascimento")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60);

            entity.Property(e => e.DT_Criacao)
            .IsRequired()
            .HasColumnName("DT_Criacao")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60);
        }
        );
    }
}
