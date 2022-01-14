using System;

namespace Poda.Tablets.DAO
{
    [Serializable]
    class ProducerDBFile : Interfaces.IProducer
    {
        public string GUID { get; set; }
        public string Name { get; set; }
    }
}
