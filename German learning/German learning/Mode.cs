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
        protected int RightAnswers { get; set; }
        #endregion

        #region number of wrong answers
        protected int WrongAnswers { get; set; }
        #endregion

        #region string storing the asked word
        protected string QuestionWord { get; set; }
        #endregion
        
        #region list of words from the files
        protected List<Word> listWords = new List<Word>();
        #endregion

        #region Random class
        protected Random rnd;
        #endregion

        #region randomly generated indexes
        protected int index { get; set; }
        #endregion

        #region list of last used indexes
        protected List<int> usedIndex;
        #endregion


        //methods
        #region reads the json file and stores it in a string
        protected void ReadJson()
        {
            try
            {

                using (StreamReader r = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\DeutschLerner\" + MainWindow.LectureSelectionFileName))
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
            if (answer == QuestionWord)
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
