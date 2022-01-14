using System;

namespace Poda.Tablets.DAO
{
    [Serializable]
    public class ProducerDBMock : Interfaces.IProducer
    {
        public string GUID { get; set; }
        public string Name { get; set; }
    }
   
}
