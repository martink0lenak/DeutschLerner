using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace German_learning
{
    class GeSkMode : Mode
    {
        public GeSkMode()
        {
            usedIndex = new List<int>();
            ReadJson();
            try
            {
                RootWord word = JsonConvert.DeserializeObject<RootWord>(Json);
                foreach (var v in word.words)
                {
                    listWords.Add(v);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                
            }
        }
        public override void GenerateWord()
        {
            rnd = new Random();
            //ensures that it wouldn't generate the same number twice
            Back:
            index = rnd.Next(0,listWords.Count);
            foreach (int i in usedIndex)
            {
                if (index == i)
                {
                    goto Back;
                }
            }
            usedIndex.Add(index);
        }


    }
}
