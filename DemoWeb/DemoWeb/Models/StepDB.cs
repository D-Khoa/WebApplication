namespace DemoWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StepDB : DbContext
    {
        public StepDB()
            : base("name=StepDB")
        {
        }

        public virtual DbSet<ProcessStep> ProcessSteps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
