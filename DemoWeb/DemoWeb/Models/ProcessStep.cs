namespace DemoWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProcessStep")]
    public partial class ProcessStep
    {
        [Key]
        public int StepID { get; set; }

        [Required]
        [StringLength(50)]
        public string StepName { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastUpdate { get; set; }

        public int? LastUpdateBy { get; set; }
    }
}
