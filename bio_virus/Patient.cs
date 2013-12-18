using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bio_virus
{
    public class SimplePatient
    {
        public List<SimpleVirus> viruses = new List<SimpleVirus>();
        int maxpop;
        float density;
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
                density = viruses.Count / maxpop;
                try { viruses.Add(viruses[i].reproduce(density)); }
                catch (NoChildException) { }

            }
            Program.numviruses.Add(viruses.Count());
        }
        public SimplePatient(List<SimpleVirus> Viruses, int MaxPopulation)
        {
            viruses = Viruses;
            maxpop = MaxPopulation;
        }
        public SimplePatient() { }
    }
    public class Patient : SimplePatient
    {
        new public List<ResistantVirus> viruses;
        public Dictionary<string, bool> drugs;
        int maxpop;
        float density;
        public Patient(List<ResistantVirus> Viruses, int Maxpop, Dictionary<string, bool> drug)
        {
            viruses = Viruses;
            maxpop = Maxpop;
            drugs = drug;
        }
        public void addperscription(string drug)
        {
            try { drugs[drug] = true; }
            catch (KeyNotFoundException) { }
        }
        public List<string> getdrugs()
        {
            List<string> inuse = new List<string>();
            foreach (KeyValuePair<string, bool> kv in drugs)
                if (kv.Value)
                    inuse.Add(kv.Key);
            return inuse;
        }
        public int getresistpop(List<string> drugsinuse)
        {
            int counter = 0;
            foreach (string s in drugsinuse)
                foreach (ResistantVirus rv in viruses)
                    if (rv.getResistance(s))
                        counter++;
            return counter;
        }
        new public int update()
        {
            for (int i = 0; i < viruses.Count; i++)
            {
                if (viruses[i].clear())
                    viruses.Remove(viruses[i]);
                if (i > getpop())
                    break;
                density = (float)(viruses.Count) / (float)(maxpop);
                try { viruses.Add(viruses[i].reproduce(density, getdrugs())); }
                catch (NoChildException) { }
                Program.numviruses.Add(viruses.Count());

            }
            return viruses.Count;
        }
    }
}