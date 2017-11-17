using Microsoft.EntityFrameworkCore;

namespace SharedLibraryDatabase
{
    public class SharedlibraryContext : DbContext
    {
        private readonly string _connectionString;
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<CompositeKeyTest> CompositeKeyTest { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }

        public SharedlibraryContext()
        {
        }

        public SharedlibraryContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;");
                optionsBuilder.ConfigureWarnings(x => x.Ignore(10/*RelationalEventId.AmbientTransactionWarning*/));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountReference)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompositeKeyTest>(entity =>
            {
                entity.HasKey(e => new { e.FirstKey, e.SecondKey });

                entity.Property(e => e.SecondKey).HasMaxLength(50);

                entity.Property(e => e.LastModified).HasColumnType("date");

                entity.Property(e => e.LastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasIndex(e => e.AccountId)
                    .HasName("IX_AccountID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified).HasColumnType("date");

                entity.Property(e => e.LastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Contact_dbo.Account_AccountID");
            });
        }
    }
}
