using Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Poda.Tablets.DAO
{
    public class DAOSQL : DbContext, IDAO
    {
        public DbSet<TabletDBSQL> TabletsRelation { get; set; }
        public DbSet<ProducerDBSQL> ProducersRelation { get; set; }

        public string DbPath { get; }

        public DAOSQL()
        {
            //    var folder = Environment.SpecialFolder.LocalApplicationData;
            //    _ = Environment.GetFolderPath(folder);
            //    //var path = Environment.GetFolderPath(folder);
            //    //DbPath = System.IO.Path.Join(path, "tablets.db");
            //    DbPath = System.IO.Path.Join("C:\\Users\\Daria\\Desktop\\js\\PW\\db\\", "tablets.db");
            //}

            //protected override void OnConfiguring(DbContextOptionsBuilder options)
            //    => options.UseSqlite($"Data Source={DbPath}");
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "tablets.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public ITablet AddTablet(ITablet tablet)
        {
            tablet.GUID = Guid.NewGuid().ToString();

            Add(new TabletDBSQL()
            {
                GUID = tablet.GUID,
                Model = tablet.Model,
                Price = tablet.Price,
                Display = tablet.Display,
                ProducerGUID = tablet.Producer.GUID
            });

            SaveChanges();

            return tablet;
        }

        public IProducer AddProducer(IProducer producer)
        {
            producer.GUID = Guid.NewGuid().ToString();

            Add(new ProducerDBSQL()
            {
                GUID = producer.GUID,
                Name = producer.Name
            });

            SaveChanges();

            return producer;
        }

        public IEnumerable<ITablet> GetAllTablets()
        {
            return from a in TabletsRelation select a.ToITablet(ProducersRelation.ToList());
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return from f in ProducersRelation select f.ToIProducer();
        }

        public void RemoveTablet(string guid)
        {
            var tablet = (from a in TabletsRelation where a.GUID == guid select a).First();
            Remove(tablet);
            SaveChanges();
        }

        public void RemoveProducer(string guid)
        {
            var producer = (from f in ProducersRelation where f.GUID == guid select f).First();
            Remove(producer);
            SaveChanges();
        }

        public void ModifyTablet(ITablet tablet)
        {
            var newTablet = (from a in TabletsRelation where a.GUID == tablet.GUID select a).First();
            newTablet.Model = tablet.Model;
            newTablet.Display = tablet.Display;
            newTablet.ProducerGUID = tablet.Producer.GUID;
            newTablet.Price = tablet.Price;

            Entry(newTablet).CurrentValues.SetValues(newTablet);
        }

        public void ModifyProducer(IProducer producer)
        {
            var newProducer = (from f in ProducersRelation where f.GUID == producer.GUID select f).First();
            newProducer.Name = producer.Name;

            Entry(newProducer).CurrentValues.SetValues(producer);
        }
    }
}
