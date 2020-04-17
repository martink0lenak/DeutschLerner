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
    class Mode
    {
        public static string json { get; protected set;}
        public static int RightAnswers { get; protected set; }
        public static int WrongAnswers { get; protected set; }
        public static string QuestionWord { get; protected set; }
        public static bool IsRight { get; protected set; }

        public void ReadJson()
        {
            try
            {
                
                using (StreamReader r = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\DeutschLerner\" + MainWindow.LectureSelectionFileName))
                {
                    json = r.ReadToEnd();
                   
                }
            }
            catch
            {
                MessageBox.Show(@"Súbor nebol nájdený, uistite sa, že sa súbor nachádza v zložke C:\Program Files (x86)\DeutschLerner\");
            }

        }

        public virtual void Check(string answer)
        {

        }




    }
}
