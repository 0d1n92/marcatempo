using Microsoft.EntityFrameworkCore;

namespace api.Interface
{
    public interface ISeeder
    {
        public void DevelopSeeding(ModelBuilder modelBuilder);
        public void Seeding(ModelBuilder modelBuilder);
        public void ProductionSeeding(ModelBuilder modelBuilder);

    }
}
