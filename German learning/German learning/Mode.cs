using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using static German_learning.RootWord;

namespace German_learning
{
    class Mode
    {
        //fields
        #region raw JSON string
        public string Json { get; protected set;}
        #endregion

        #region number of right answers
        public int RightAnswers { get;protected set; }
        #endregion

        #region number of wrong answers
        public int WrongAnswers { get;protected set; }
        #endregion

        #region string storing the asked word
        public string GeneratedWord { get;protected set; }
        #endregion


        #region list of words from the files
        public List<Word> listWords { get; protected set; } = new List<Word>();
        #endregion

        #region stores a boolean value showing whether the game is over
        public bool isOver { get; protected set; }
        #endregion

        #region Random class
        protected Random rnd;
        #endregion

        #region randomly generated index
        public int index { get;protected set; }
        #endregion

        #region list of last used indexes
        public List<int> usedIndex { get; protected set; } = new List<int>();
        #endregion


        //methods
        #region reads the json file and stores it in a string
        protected void ReadJson()
        {
            try
            {

                using (StreamReader r = new StreamReader(@"Lekcie\" + MainWindow.LectureSelectionFileName))
                {
                    Json = r.ReadToEnd();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        #endregion

        #region checks whether the answer is correct and adds to right or wrong answer count
        public bool IsRight(string answer)
        {
            if (answer == listWords[index].sk)
            {
                RightAnswers++;
                return true;
            }
            else
            {
                WrongAnswers++;
                return false;
            }
        }
        #endregion

        #region picks a random word from the lecture
        public virtual void GenerateWord()
        {
        }
        #endregion

        

    }
}
