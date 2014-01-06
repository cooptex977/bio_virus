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
        public static int timeAfter;
        public static List<ResistantVirus> viruses = new List<ResistantVirus>();
        public static List<int> numviruses = new List<int>();
        public static Dictionary<string, bool> resist = new Dictionary<string, bool>();
        public static Patient patient;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void problem_4()
        {
            if (!resist.ContainsKey("guttagonol"))
                resist.Add("guttagonol", false);
            if (!resist.ContainsKey("grimpex"))
                resist.Add("grimpex", false);
            for (int i = 0; i < 100; i++)
                viruses.Add(new ResistantVirus(.1f, .05f, resist, .005f));
            patient = new Patient(viruses, 1000, resist);
            for (int i = 0; i < 150; i++)
                numviruses.Add(patient.update());
            patient.addperscription("guttagonol");
            for (int i = 0; i <= timeAfter; i++)
                numviruses.Add(patient.update());
        }
        public static void problem_6()
        {
            if (!resist.ContainsKey("guttagonol"))
                resist.Add("guttagonol", false);
            if (!resist.ContainsKey("grimpex"))
                resist.Add("grimpex", false);
            for (int i = 0; i < 100; i++)
                viruses.Add(new ResistantVirus(.1f, .05f, resist, .005f));
            patient = new Patient(viruses, 1000, resist);
            for (int i = 0; i < 150; i++)
                numviruses.Add(patient.update());
            patient.addperscription("guttagonol");
            for (int i = 0; i <= timeAfter; i++)
                numviruses.Add(patient.update());
            patient.addperscription("gripmex");
            for (int i = 0; i < 150; i++)
                numviruses.Add(patient.update());
        }
    }
}
