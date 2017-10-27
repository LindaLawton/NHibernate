using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernateDemoApp.Domain;

namespace NHibernateDemoApp.Mappings
{
    public class PersonMapping : ClassMapping<Person>
    {
        public PersonMapping()
        {
            Id(s => s.ID, im => im.Generator(Generators.Identity));  // primary key mapping
            Property(s => s.FirstName, pm => pm.NotNullable(true));
            Property(s => s.LastName, pm => pm.NotNullable(true));
            Property(s => s.Address);
            ManyToOne(s => s.Car, mom => mom.Cascade(Cascade.Persist));
        }
    }
}
