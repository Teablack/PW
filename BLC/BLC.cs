using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Configuration;
namespace Poda.Tablets.BL
{
    public class BLC
    {
        private Interfaces.IDAO dao;

        public void LoadLibrary(string dllPath)
        {
            Type typeToCreate = null;
            

            Type IDAOType = typeof(Interfaces.IDAO);
            foreach (var t in Assembly.UnsafeLoadFrom(dllPath).GetTypes())
            {
                if (t.IsAssignableTo(IDAOType))
                {
                    typeToCreate = t;
                    break;
                }
            }

            if (typeToCreate != null)
            {
                dao = (Interfaces.IDAO)Activator.CreateInstance(typeToCreate);
            }
            else
            {
                throw new Exception("incompatible dao");
            }
        }

        public IEnumerable<Interfaces.ITablet> GetAllTablets()
        {
            return dao.GetAllTablets();
        }
        public IEnumerable<Interfaces.IProducer> GetAllProducers()
        {
            return dao.GetAllProducers();
        }

        public IEnumerable<Interfaces.ITablet> GetTablet(string guid)
        {
            return from a in dao.GetAllTablets() where a.GUID.Equals(guid) select a;
        }
        public IEnumerable<Interfaces.IProducer> GetProducer(string guid)
        {
            return from f in dao.GetAllProducers() where f.GUID.Equals(guid) select f;
        }

        public IEnumerable<Interfaces.ITablet> GetTablets(int price)
        {
            return from a in dao.GetAllTablets() where a.Price <= price select a;
        }
        public IEnumerable<Interfaces.IProducer> GetProducers(string name)
        {
            return from f in dao.GetAllProducers() where f.Name.StartsWith(name) select f;
        }

        public void RemoveTablet(string guid)
        {
            dao.RemoveTablet(guid);
        }
        public void RemoveProducer(string guid)
        {
            dao.RemoveProducer(guid);
        }

        public void CreateOrReplaceTablet(Interfaces.ITablet tablet)
        {
            if (tablet.GUID == null)
            {
                tablet.GUID = Guid.NewGuid().ToString();
                dao.AddTablet(tablet);
            }
            else
            {
                dao.ModifyTablet(tablet);
            }
        }
        public void CreateOrModifyProducer(Interfaces.IProducer producer)
        {
            if (producer.GUID == null)
            {
                producer.GUID = Guid.NewGuid().ToString();
                dao.AddProducer(producer);
            }
            else
            {
                dao.ModifyTablet(producer);
            }
        }

        public IEnumerable<string> GetAllProducerNames()
        {
            return from f in dao.GetAllProducers() select f.Name;
        }
    }
}
