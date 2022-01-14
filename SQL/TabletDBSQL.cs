using Interfaces;
using Poda.Tablets.Core;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace Poda.Tablets.DAO
{
    public class TabletDBSQL
    {
        [Key]
        public string GUID { get; set; }
        public string Model { get; set; }
        public string ProducerGUID { get; set; }
        public DisplayType Display { get; set; }
        public int Price { get; set; }

        public ITablet ToITablet(List<ProducerDBSQL> producers) {
            return new Tablet() { GUID = GUID, Model = Model, Producer = producers.Single(p => p.GUID.Equals(ProducerGUID)).ToIProducer(), Display = Display, Price = Price };
        }
    }

    class Tablet : ITablet
    {
        public string GUID { get; set; }
        public string Model { get; set; }
        public IProducer Producer { get; set; }
        public DisplayType Display { get; set; }
        public int Price { get; set; }
    }
}
