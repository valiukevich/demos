namespace EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class kt_Traject_Activiteiten
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kt_Traject_Activiteiten()
        {
            kt_Traject_Activiteiten_Historie = new HashSet<kt_Traject_Activiteiten_Historie>();
        }

        [Key]
        [StringLength(50)]
        public string ID_KoppelActiviteit { get; set; }

        [StringLength(50)]
        public string ID_Opleidingstraject { get; set; }

        [StringLength(50)]
        public string ID_Module { get; set; }

        [StringLength(1000)]
        public string Opleiding { get; set; }

        [StringLength(200)]
        public string Toetsgebied { get; set; }

        public double? Cijfer { get; set; }

        public double? Weging { get; set; }

        public bool Actief { get; set; }

        public bool Gestart { get; set; }

        public bool Geslaagd { get; set; }

        public int? Sortcode { get; set; }

        public bool Voltooid { get; set; }

        public bool Vrijstelling { get; set; }

        public bool SkipPlanning { get; set; }

        public bool AllowSelfenrolment { get; set; }

        [StringLength(50)]
        public string ID_Toets { get; set; }

        [StringLength(50)]
        public string ID_Koppel { get; set; }

        [StringLength(50)]
        public string ID_Beoordeling { get; set; }

        [StringLength(50)]
        public string ID_Activiteit { get; set; }

        public int? NumberOfDays { get; set; }

        [StringLength(255)]
        public string PlanningBuffer { get; set; }

        public int StudiePunt { get; set; }

        public bool LockSelfEnrollmentToProject { get; set; }

        [StringLength(50)]
        public string ID_Module_New { get; set; }

        public bool IsSli { get; set; }

        [StringLength(150)]
        public string ExternalTeacherName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kt_Traject_Activiteiten_Historie> kt_Traject_Activiteiten_Historie { get; set; }

        public virtual t_Module t_Module { get; set; }
    }
}
