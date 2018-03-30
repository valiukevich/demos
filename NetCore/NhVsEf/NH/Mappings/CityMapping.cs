using Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NH.Mappings
{
    public class CityMapping : ClassMapping<City>
    {
        public CityMapping()
        {
            Id(x => x.Id, mapper => mapper.Generator(new IdentityGeneratorDef()));
            Property(x => x.Name);
            //Property(x => x.Country);
            ManyToOne(x => x.Country, map=>map.Column("CountryId"));
        }
    }
}