using System;
using Interfaces;
using Poda.Tablets.Core;

namespace Poda.Tablets.DAO
{
    [Serializable]
    public class TabletDBFile : ITablet
    {
        public string GUID { get; set; }
        public string Model { get; set; }
        public IProducer Producer { get; set; }
        public DisplayType Display { get; set; }
        public int Price { get; set; }
    }

}
