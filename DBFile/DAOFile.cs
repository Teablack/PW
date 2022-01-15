using Poda.Tablets.Interfaces;
using System;
using System.Collections.Generic;

namespace Poda.Tablets.DAO
{
    class DAOFile : IDAO
    {
        private readonly List<ITablet> tablets;
        private readonly List<IProducer> producers;

        private const string FILE_TABLETS = "tablets.bin";
        private const string FILE_PRODUCERS = "producers.bin";

        public DAOFile() {
            try
            {
                tablets = Serializer.Deserialize<ITablet>(FILE_TABLETS);
                producers = Serializer.Deserialize<IProducer>(FILE_PRODUCERS);
            }
            catch (Exception)
            {
                producers = new List<IProducer>();
                tablets = new List<ITablet>();
                
                AddProducer(new ProducerDBFile() { Name = "Samsung" });
                AddProducer(new ProducerDBFile() { Name = "Huawei" });
                AddProducer(new ProducerDBFile() { Name = "Apple" });
                
                AddTablet(new TabletDBFile() { Model = "galaxy s3", Producer = producers[0], Display = Core.DisplayType.Retina, Price = 54546 });
                AddTablet(new TabletDBFile() { Model = "galaxy s4", Producer = producers[0], Display = Core.DisplayType.AMOLED, Price = 4466 });
                AddTablet(new TabletDBFile() { Model = "kek", Producer = producers[1], Display = Core.DisplayType.AMOLED, Price = 34664 });
                AddTablet(new TabletDBFile() { Model = "kek", Producer = producers[2], Display = Core.DisplayType.Retina, Price = 44646 });
                
                Save();
            }
        }

        private void Save() {
            Serializer.Serialize(FILE_TABLETS, tablets);
            Serializer.Serialize(FILE_PRODUCERS, producers);
        }

        public ITablet AddTablet(ITablet tablet)
        {
            tablet.GUID = Guid.NewGuid().ToString();
            tablets.Add(tablet);
            Save();
            return tablet;
        }

        public IProducer AddProducer(IProducer producer)
        {
            producer.GUID = Guid.NewGuid().ToString();
            producers.Add(producer);
            Save();
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
                    Save();
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
                    Save();
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
            Save();
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
            Save();
        }
    }
}
