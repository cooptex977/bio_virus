using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bio_virus
{
    public class SimpleVirus
    {
        float maxBirthProb;
        float clearProb;
        public bool clear()
        {
            if ((float)(Program.rand.NextDouble()) == clearProb)
                return true;
            else
                return false;
        }
        public SimpleVirus reproduce(float density)
        {
            if ((float)(Program.rand.NextDouble()) <= maxBirthProb * (1 - density))
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
    }
    public class NoChildException : Exception
    {

    }
}
