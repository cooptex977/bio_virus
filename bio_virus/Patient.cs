using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bio_virus
{
    public class SimplePatient
    {
        List<SimpleVirus> viruses;
        int maxpop;
        public int getpop()
        {
            return viruses.Count;
        }
        public void update()
        {
            List<SimpleVirus> removelist = new List<SimpleVirus>();
            foreach (SimpleVirus sv in viruses)
            {
                if (sv.clear())
                    removelist.Add(sv);
            }
        }
        public SimplePatient(List<SimpleVirus> Viruses, int MaxPopulation)
        {
            viruses = Viruses;
            maxpop = MaxPopulation;
        }
    }
}
