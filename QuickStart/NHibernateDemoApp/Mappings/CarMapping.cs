using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernateDemoApp.Domain;

namespace NHibernateDemoApp.Mappings
{
    public class CarMapping : ClassMapping<Car>
    {
        public CarMapping()
        {
            Id(s => s.ID, im => im.Generator(Generators.Identity));
            Property(s => s.Make, pm => pm.NotNullable(true));
            Property(s => s.Model, pm => pm.NotNullable(true));
            Property(s => s.Year, pm => pm.NotNullable(true));
        }
    }
}