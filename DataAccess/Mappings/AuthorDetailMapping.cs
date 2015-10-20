using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BusinessLogic;
namespace DataAccess.Mappings
{
  public class AuthorDetailMapping : EntityTypeConfiguration<AuthorDetail>
  {
    public AuthorDetailMapping()
    {
      this.ToTable("AuthorDetails");
      this.HasKey(x => x.Id);
      this.Property(x =>
        x.Id).HasColumnName("AuthorDetailId")
          .HasDatabaseGeneratedOption
             (DatabaseGeneratedOption.Identity);
      this.Property(x => x.Bio).HasColumnType("Text").IsMaxLength();
      this.Property(x => x.Email).HasMaxLength(100).IsRequired();
      this.Property(x => x.Name).HasMaxLength(100).IsRequired();
    }
  }
}