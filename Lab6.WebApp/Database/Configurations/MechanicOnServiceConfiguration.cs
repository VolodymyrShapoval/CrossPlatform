using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab6.WebApp.Database.Configurations
{
    public class MechanicOnServiceConfiguration : IEntityTypeConfiguration<MechanicOnService>
    {
        public void Configure(EntityTypeBuilder<MechanicOnService> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
