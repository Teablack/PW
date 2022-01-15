using System.Collections.Generic;

namespace Poda.Tablets.Interfaces
{
    public interface IDAO
    {
        IEnumerable<ITablet> GetAllTablets();
        IEnumerable<IProducer> GetAllProducers();
        ITablet AddTablet(ITablet tablet);
        IProducer AddProducer(IProducer producer);
        void ModifyTablet(ITablet tablet);
        void ModifyProducer(IProducer producer);
        void RemoveTablet(string guid);
        void RemoveProducer(string guid);
    }
}
