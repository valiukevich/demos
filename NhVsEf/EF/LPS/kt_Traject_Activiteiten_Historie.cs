namespace EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class kt_Traject_Activiteiten_Historie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ID_KoppelActiviteit { get; set; }

        [Required]
        [StringLength(50)]
        public string ID_Module { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? TrainingStateDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CertificateStateDate { get; set; }

        public virtual kt_Traject_Activiteiten kt_Traject_Activiteiten { get; set; }

        public virtual t_Module t_Module { get; set; }
    }
}
