namespace EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Module
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Module()
        {
            kt_Traject_Activiteiten = new HashSet<kt_Traject_Activiteiten>();
            kt_Traject_Activiteiten_Historie = new HashSet<kt_Traject_Activiteiten_Historie>();
        }

        [Key]
        [StringLength(50)]
        public string ID_Module { get; set; }

        [StringLength(50)]
        public string ID_Opleiding { get; set; }

        [StringLength(50)]
        public string ID_Evaluatie { get; set; }

        [StringLength(150)]
        public string Toetsgebied { get; set; }

        public int? Weging { get; set; }

        [StringLength(40)]
        public string Code { get; set; }

        public int? SortCode { get; set; }

        public double? SBU { get; set; }

        public double? SBUKlassikaal { get; set; }

        [StringLength(50)]
        public string Blok { get; set; }

        public bool CoachBeoordeling { get; set; }

        public bool CursistQuestions { get; set; }

        public bool AllowSelfEnrolment { get; set; }

        public DateTime? dateCreated { get; set; }

        public DateTime? dateModified { get; set; }

        public int NumberOfDays { get; set; }

        public bool Updated { get; set; }

        [StringLength(150)]
        public string Link { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int StudiePunt { get; set; }

        public bool AllowFeedback { get; set; }

        public bool AllowAanvraag { get; set; }

        [StringLength(250)]
        public string Hashtag { get; set; }

        public bool? IncludeMainHashtag { get; set; }

        [StringLength(750)]
        public string LinkedInUrl { get; set; }

        public double? Norm { get; set; }

        public bool AutoClose { get; set; }

        public bool AddPortfolio { get; set; }

        [StringLength(50)]
        public string ID_DossierElement { get; set; }

        [StringLength(750)]
        public string YammerUrl { get; set; }

        public bool ApproveTrainingRequestsByManager { get; set; }

        [StringLength(50)]
        public string TwitterType { get; set; }

        [StringLength(250)]
        public string TwitterWidgetDescription { get; set; }

        [StringLength(250)]
        public string TwitterWidgetID { get; set; }

       // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<kt_Traject_Activiteiten> kt_Traject_Activiteiten { get; set; }

       // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<kt_Traject_Activiteiten_Historie> kt_Traject_Activiteiten_Historie { get; set; }
    }
}
