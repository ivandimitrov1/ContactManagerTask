using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManager.Infrastructure.Data.Contacts
{
    public class ContactEntityConfiguration : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            builder.ToTable("tContact");

            builder.Property(c => c.Id).HasColumnName("Id").UseIdentityColumn().IsRequired();
            builder.HasKey(c => c.Id).HasName("PK_Contact_Id");

            builder.Property(c => c.FirstName).HasMaxLength(50);
            builder.Property(c => c.Surname).HasMaxLength(50);
            builder.Property(c => c.BirthDate);
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
            builder.Property(c => c.IBAN).HasMaxLength(50);
            builder.Property(c => c.City).HasMaxLength(100);
            builder.Property(c => c.Country).HasMaxLength(50);
            builder.Property(c => c.Postcode).HasMaxLength(10);
        }
    }
}
