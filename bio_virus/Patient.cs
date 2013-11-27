using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bio_virus
{
    public class SimplePatient
    {
        public List<SimpleVirus> viruses;
        int maxpop;
        public int getpop()
        {
            return viruses.Count;
        }
        public void update()
        {
            for (int i = 0; i < getpop() - 1; i++)
            {
                if (viruses[i].clear())
                    viruses.Remove(viruses[i]);
                if (i > getpop())
                    break;
                try { viruses.Add(viruses[i].reproduce(.5f)); }
                catch (NoChildException) { }

            }
            Program.numviruses.Add(viruses.Count());
        }
        public SimplePatient(List<SimpleVirus> Viruses, int MaxPopulation)
        {
            viruses = Viruses;
            maxpop = MaxPopulation;
        }
    }
}