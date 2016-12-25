using _20161119.Migrations;
using _20161119.Models;

namespace _20161119
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MassDefectDatabaseContext : DbContext
    {
        public MassDefectDatabaseContext()
            : base("name=MassDefectDatabase")
        {
            Database.SetInitializer(
               new MigrateDatabaseToLatestVersion<MassDefectDatabaseContext,Configuration>());
        }
        public virtual DbSet<SolarSystem> SolarSystems { get; set; }

        public virtual DbSet<Star> Stars { get; set; }

        public virtual DbSet<Planet> Planets { get; set; }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Anomaly> Anomalies { get; set; }
    }
}
