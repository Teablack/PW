using System;
using System.Collections.Generic;
using Poda.Tablets.Interfaces;

namespace Poda.Tablets.DAO
{
    public class DAOMock : IDAO
    {
        private List<IProducer> producers;
        private List<ITablet> tablets;

        public DAOMock()
        {
            producers = new List<IProducer>();
            AddProducer(new ProducerDBMock() { GUID = Guid.NewGuid().ToString(), Name = "Samsung" });
            AddProducer(new ProducerDBMock() { GUID = Guid.NewGuid().ToString(), Name = "Apple" });
            AddProducer(new ProducerDBMock() { GUID = Guid.NewGuid().ToString(), Name = "Amazon" });
            AddProducer(new ProducerDBMock() { GUID = Guid.NewGuid().ToString(), Name = "Microsoft" });

            tablets = new List<ITablet>();
            AddTablet(new TabletDBMock() { GUID = Guid.NewGuid().ToString(), Model = "IPad Pro 11", Producer = producers[1], Display = Core.DisplayType.Retina, Price = 749 });
            AddTablet(new TabletDBMock() { GUID = Guid.NewGuid().ToString(), Model = "iPad Air", Producer = producers[1], Display = Core.DisplayType.Retina, Price = 599 });
            AddTablet(new TabletDBMock() { GUID = Guid.NewGuid().ToString(), Model = "Galaxy Tab S7", Producer = producers[0], Display = Core.DisplayType.AMOLED, Price = 150 });
            AddTablet(new TabletDBMock() { GUID = Guid.NewGuid().ToString(), Model = "Fire HD 10", Producer = producers[2], Display = Core.DisplayType.IPS, Price = 49 });
            AddTablet(new TabletDBMock() { GUID = Guid.NewGuid().ToString(), Model = "Surface Go 3", Producer = producers[3], Display = Core.DisplayType.PixelSense, Price = 399 });
        }

        public ITablet AddTablet(ITablet tablet)
        {
            tablets.Add(tablet);
            return tablet;
        }

        public IProducer AddProducer(IProducer producer)
        {
            producers.Add(producer);
            return producer;
        }

        public IEnumerable<ITablet> GetAllTablets()
        {
            return tablets;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return producers;
        }

        public void RemoveTablet(string guid)
        {
            foreach (ITablet tablet in tablets)
            {
                if (tablet.GUID.Equals(guid))
                {
                    tablets.Remove(tablet);
                    return;
                }
            }
        }

        public void RemoveProducer(string guid)
        {
            foreach (IProducer producer in producers)
            {
                if (producer.GUID.Equals(guid))
                {
                    producers.Remove(producer);
                    return;
                }
            }
        }

        public void ModifyTablet(ITablet tablet)
        {
            for (int i = 0; i < tablets.Count; i++)
            {
                if (tablets[i].GUID.Equals(tablet.GUID))
                {
                    tablets[i] = tablet;
                    break;
                }
            }
        }

        public void ModifyProducer(IProducer producer)
        {
            for (int i = 0; i < producers.Count; i++)
            {
                if (producers[i].GUID.Equals(producer.GUID))
                {
                    producers[i].Name = producer.Name;
                    break;
                }
            }
        }
    }
}
