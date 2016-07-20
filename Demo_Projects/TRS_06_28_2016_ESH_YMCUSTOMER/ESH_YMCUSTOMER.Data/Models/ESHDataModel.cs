namespace ESH_YMCUSTOMER.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ESHDataModel : DbContext
    {
        public ESHDataModel()
            : base("name=ESHDataModel")
        {
        }

        public virtual DbSet<price_units> price_units { get; set; }
        public virtual DbSet<ym_customers> ym_customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<price_units>()
                .Property(e => e.price_unit_name)
                .IsUnicode(false);

            modelBuilder.Entity<price_units>()
                .Property(e => e.normalized_value)
                .HasPrecision(20, 5);

            modelBuilder.Entity<ym_customers>()
                .Property(e => e.customer_name)
                .IsUnicode(false);

            modelBuilder.Entity<ym_customers>()
                .Property(e => e.customer_notes)
                .IsUnicode(false);

            modelBuilder.Entity<ym_customers>()
                .Property(e => e.mileage)
                .HasPrecision(10, 4);

            modelBuilder.Entity<ym_customers>()
                .Property(e => e.freight_per_car)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ym_customers>()
                .Property(e => e.freight_per_unit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ym_customers>()
                .Property(e => e.product_type)
                .IsUnicode(false);
        }
    }
}
