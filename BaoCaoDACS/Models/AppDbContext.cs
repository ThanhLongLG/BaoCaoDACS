using BaoCaoDACS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Thêm cấu hình khóa chính cho IdentityUserLogin
        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        });
        // Giữ nguyên cascade delete từ Tournament → Results
        modelBuilder.Entity<Tournament>()
            .HasMany(t => t.Results)
            .WithOne(r => r.Tournament)
            .HasForeignKey(r => r.TournamentID)
            .OnDelete(DeleteBehavior.Cascade); // Cho phép xóa Tournament → xóa Results

        // Đổi thành DeleteBehavior.ClientNoAction hoặc DeleteBehavior.NoAction từ Participant → Results
        modelBuilder.Entity<Participant>()
            .HasMany(p => p.Results)
            .WithOne(r => r.Participant)
            .HasForeignKey(r => r.ParticipantID)
            .OnDelete(DeleteBehavior.NoAction); // Không tự động xóa Results khi xóa Participant
    }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Result> Results { get; set; }
}
