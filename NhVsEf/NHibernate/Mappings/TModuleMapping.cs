//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="TModuleMapping.cs" company="Noordhoff Uitgevers BV">
//      © Noordhoff Uitgevers BV, the Netherlands
//  </copyright>
//   <author>Valiukevich, Evgeny</author>
//  --------------------------------------------------------------------------------------------------------------------
namespace NH.Mappings
{
    using Models;

    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;

    using Cascade = FluentNHibernate.Conventions.Inspections.Cascade;

    public class TModuleMap : ClassMapping<TModule>
    {

        public TModuleMap()
        {
            Table("t_Module");
            Schema("dbo");
            Lazy(true);
            Id(x => x.IdModule, map => { map.Column("ID_Module"); map.Generator(Generators.Assigned); });

            ///Id(x => x.IdModule, map => { map.Column("ID_Module"); });
            Property(x => x.Toetsgebied);
            Property(x => x.Weging);
            Property(x => x.Code);
            Property(x => x.Sortcode);
            Property(x => x.Sbu);
            Property(x => x.Sbuklassikaal);
            Property(x => x.Blok);
            Property(x => x.Coachbeoordeling, map => map.NotNullable(true));
            Property(x => x.Cursistquestions, map => map.NotNullable(true));
            Property(x => x.Allowselfenrolment, map => map.NotNullable(true));
            Property(x => x.Datecreated);
            Property(x => x.Datemodified);
            Property(x => x.Numberofdays, map => map.NotNullable(true));
            Property(x => x.Updated, map => map.NotNullable(true));
            Property(x => x.Link);
            Property(x => x.Height, map => map.NotNullable(true));
            Property(x => x.Width, map => map.NotNullable(true));
            Property(x => x.Studiepunt, map => map.NotNullable(true));
            Property(x => x.Allowfeedback, map => map.NotNullable(true));
            Property(x => x.Allowaanvraag, map => map.NotNullable(true));
            Property(x => x.Hashtag);
            Property(x => x.Includemainhashtag);
            Property(x => x.Linkedinurl);
            Property(x => x.Norm);
            Property(x => x.Autoclose, map => map.NotNullable(true));
            Property(x => x.Addportfolio, map => map.NotNullable(true));
            Property(x => x.IdDossierelement, map => map.Column("ID_DossierElement"));
            Property(x => x.Yammerurl);
            Property(x => x.Approvetrainingrequestsbymanager, map => map.NotNullable(true));
            Property(x => x.Twittertype);
            Property(x => x.Twitterwidgetdescription);
            Property(x => x.Twitterwidgetid);
            //ManyToOne(x => x.TOpleiding, map =>
            //{
            //    map.Column("ID_Opleiding");
            //    map.NotNullable(true);
            //    map.Cascade(Cascade.None);
            //});

            //ManyToOne(x => x.TEvaluatie, map =>
            //{
            //    map.Column("ID_Evaluatie");
            //    map.NotNullable(true);
            //    map.Cascade(Cascade.None);
            //});

            //Bag(x => x.Activityunplannableprojectstatus, colmap => { colmap.Key(x => x.Column("ModuleId")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.Activityunplannabletrajectstatus, colmap => { colmap.Key(x => x.Column("ModuleId")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.KtCompetentieModule, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.KtModuleIntern, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.KtOplprojectActiviteiten, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.KtTrajectActiviteiten, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.KtTrajectActiviteitenHistorie, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.PeModule, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.Skill, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.TAanvragen, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.TBeoordeling, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.TForumvraag, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.TLesstof, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.TModulekader, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.TModuleportfolio, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.TMovies, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.TResultaatevaluatie, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.TToets, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            //Bag(x => x.TVragen, colmap => { colmap.Key(x => x.Column("ID_Module")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}