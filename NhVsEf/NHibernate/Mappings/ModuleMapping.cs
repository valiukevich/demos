namespace NH.Mappings
{
    using FluentNHibernate.Mapping;

    using Models;

    using NHibernate.Mapping;
    using NHibernate.Mapping.ByCode;

    public class ModuleMapping : ClassMap<Country>
    {
        public ModuleMapping()
        {
        }
    }
}