using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bio_virus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static Random rand = new Random();
        public static List<SimpleVirus> viruses = new List<SimpleVirus>();
        public static List<int> numviruses = new List<int>();
        public static SimplePatient patient = new SimplePatient(viruses, 1000);
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void problem_2()
        {
            for (int i = 0; i < 100; i++)
            {
                viruses.Add(new SimpleVirus(0.6f, 0.5f));
            }
            for (int i = 0; i < 10; i++)
            {
                patient.update();
                viruses = patient.viruses;
            }
        }
        public static IEnumerable<TKey> RandomKey<TKey, TValue>(IDictionary<TKey, TValue> dict)
        {
            Random rand = new Random();
            List<TKey> keys = Enumerable.ToList(dict.Keys);
            int size = dict.Count;
            while (true)
            {
                yield return keys[rand.Next(size)];
            }
        }
    }
}
