using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.IO;
using DTQuestsKamas.Helper;

namespace DTQuestsKamas
{
    class Program
    {
        static void Main(string[] args)
        {
            //lire quests.json
            //pour chaque id
            //if id exist in questkamas.json
            //if Constants.Playerlvl is in max min? 
            //calcul du montant de kamas
            //sauvegarde format lvl:questid:kamasreward 
            //else
            //
            //fin pour chaque id
            //on classe en ordre decroissant

            using (StreamReader file = File.OpenText(@"Quests.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Quest movie2 = (Quest)serializer.Deserialize(file, typeof(Quest));
                Console.WriteLine(movie2.Id);
            }
            

        }
    }
}
