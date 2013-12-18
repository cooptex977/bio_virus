using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bio_virus
{
    public class SimpleVirus
    {
        public float maxBirthProb;
        public float clearProb;
        public bool clear()
        {
            if ((float)(Program.rand.NextDouble()) <= clearProb)
                return true;
            else
                return false;
        }
        public SimpleVirus reproduce(float density)
        {           
            float randomf = (float)Program.rand.NextDouble();
            if (randomf >= maxBirthProb * (1 - density))
            {
                return new SimpleVirus(maxBirthProb, clearProb);
            }
            else
                throw new NoChildException();
        }
        public SimpleVirus(float birthprob, float clearprob)
        {
            maxBirthProb = birthprob;
            clearProb = clearprob;
        }
        public SimpleVirus() { }
    }
    public class ResistantVirus : SimpleVirus
    {
        public Dictionary<string, bool> resistances;
        public float mutProb;
        public bool getResistance(string drug)
        {
            if (!resistances.ContainsKey(drug))
                return false;
            else
                return true;
        }
        public ResistantVirus reproduce(float density, List<string> activeDrugs)
        { 
            foreach(string drug in activeDrugs)
                if (!resistances[drug])
                    throw new NoChildException();

            float randomf = (float)Program.rand.NextDouble();

            if (randomf >= maxBirthProb * (1 - density))
            {
                randomf = (float)Program.rand.NextDouble();
                Dictionary<string, bool> addremove = new Dictionary<string, bool>();
                foreach (KeyValuePair<string, bool> keyvals in resistances)
                {
                    if (randomf >= 1 - mutProb)
                    {
                        try { addremove[activeDrugs[Program.rand.Next(0, activeDrugs.Count)]] = true; }
                        catch(ArgumentOutOfRangeException) { }
                    }
                }
                foreach (KeyValuePair<string, bool> kv in addremove)
                {
                    try { resistances.Add(kv.Key, kv.Value); }
                    catch(Exception)
                    {
                        resistances[kv.Key] = kv.Value;
                    }
                }
                return new ResistantVirus(maxBirthProb, clearProb, resistances, mutProb);
            }
            else
                throw new NoChildException();
        }
        public ResistantVirus(float birthprob, float clearprob, Dictionary<string, bool> resist, float mutationProb)
        {
            maxBirthProb = birthprob;
            clearProb = clearprob;
            resistances = resist.Keys.ToList().ToDictionary(t => t, t => false);
            mutProb = mutationProb;
        }
    }
    public class NoChildException : Exception { }
}
