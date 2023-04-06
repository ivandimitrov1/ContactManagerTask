using ContactManager.Domain.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManager.Infrastructure.Data.ContactReads
{
    public class ContactReadEntityConfiguration : IEntityTypeConfiguration<ContactRead>
    {
        public void Configure(EntityTypeBuilder<ContactRead> builder)
        {
            builder.ToTable("tContactRead");

            builder.Property(c => c.Id).HasColumnName("Id").UseIdentityColumn().IsRequired();
            builder.HasKey(c => c.Id).HasName("PK_ContactRead_Id");

            builder.Property(c => c.ContactId);
            builder.Property(c => c.FirstName).HasMaxLength(50);
            builder.Property(c => c.Surname).HasMaxLength(50);
            builder.Property(c => c.BirthDate);
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
            builder.Property(c => c.IBAN).HasMaxLength(50);
            builder.Property(c => c.City).HasMaxLength(100);
            builder.Property(c => c.Country).HasMaxLength(50);
            builder.Property(c => c.Postcode).HasMaxLength(10);
            builder.Property(c => c.Deleted);
        }
    }
}
