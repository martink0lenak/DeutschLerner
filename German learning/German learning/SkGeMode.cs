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
    class SkGeMode : Mode
    {
        public SkGeMode()
        {

            ReadJson();
            rnd = new Random();
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
        public void GenerateWor()
        {
            if (usedIndex.Count == listWords.Count)
            {
                isOver = true;
            }
            else
            {

                index = rnd.Next(0, listWords.Count);

                //ensures that it wouldn't generate the same number twice


                foreach (int i in usedIndex)
                {
                    while (i == index)
                    {
                        index = rnd.Next(0, listWords.Count);
                    }
                }
                usedIndex.Add(index);
                GeneratedWord = listWords[index].sk;
            }
        }
    }
}
