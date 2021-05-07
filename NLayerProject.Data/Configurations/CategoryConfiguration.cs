using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;

namespace NLayerProject.Data.Configurations
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(x => x.Id);                          //id key olarak al
            builder.Property(x => x.Id).UseIdentityColumn();    //otomatik artan sayı olarak al

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50); //zorunlu 50 karakter

            builder.ToTable("Categories");
        }
    }
}