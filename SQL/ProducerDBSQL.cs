using Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Poda.Tablets.DAO
{
    public class ProducerDBSQL
    {
        [Key]
        public string GUID { get; set; }
        public string Name { get; set; }
        public IProducer ToIProducer() {
            return new Producer() { GUID = GUID, Name = Name };
        }
    }

    class Producer : IProducer {
        public string GUID { get; set; }
        public string Name { get; set; }
    }
}
