using System.Collections.Generic;

namespace Interfaces
{
    public interface IDAO
    {
        IEnumerable<ITablet> GetAllTablets();
        IEnumerable<IProducer> GetAllProducers();
        ITablet AddTablet(ITablet tablet);
        IProducer AddProducer(IProducer producer);

        void ModifyTablet(ITablet tablet);
        void ModifyTablet(IProducer producer);
        void RemoveTablet(string guid);
        void RemoveProducer(string guid);
    }
}
