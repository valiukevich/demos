using Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NH.Mappings
{
    public class CountryMapping : ClassMapping<Country>
    {
        public CountryMapping()
        {
            Table("Countries");
            Id(x => x.Id, mapper => mapper.Generator(new IdentityGeneratorDef()));
            Property(x => x.Name);
            Bag(
            x => x.Cities, 
            m =>
            {
                m.Fetch(CollectionFetchMode.Join);
                m.Inverse(true);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Key(km => km.Column("CountryId"));
            }, 
            map=> map.OneToMany(a => a.Class(typeof(City)))
            );
        }
    }
}