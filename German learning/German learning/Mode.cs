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
        public string Json { get; protected set; }
        #endregion

        #region number of right answers
        public int RightAnswers { get; protected set; }
        #endregion

        #region number of wrong answers
        public int WrongAnswers { get; protected set; }
        #endregion

        #region string storing the asked word
        public string GeneratedWord { get; protected set; }
        #endregion

        #region string storing the gender
        public string GeneratedWordGender { get; protected set; } = "";
        #endregion

        #region string storing the correct answer
        public string AnswerWord { get; protected set; }
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
        public int index { get; protected set; }
        #endregion

        #region list of last used words
        public List<string> guessedWord { get; protected set; } = new List<string>();
        #endregion


        //methods
        #region class constructor
        public Mode()
        {

            ReadJson();
            rnd = new Random();
            try
            {
                RootWord word = JsonConvert.DeserializeObject<RootWord>(Json);
                if (ModeSelection.SelectMode == "gesk" || ModeSelection.SelectMode == "skge")
                {
                    foreach (var v in word.words)
                    {
                        listWords.Add(v);
                    }
                }
                else if (ModeSelection.SelectMode == "perfektum")
                {
                    foreach (var v in word.words)
                    {
                        if (v.type == "v")
                        {
                            listWords.Add(v);
                        }
                    }
                }
                else if (ModeSelection.SelectMode == "gender")
                {
                    foreach (var v in word.words)
                    {
                        if (v.type == "n")
                        {
                            listWords.Add(v);
                        }
                    }
                }
                else if (ModeSelection.SelectMode == "plural")
                {
                    foreach (var v in word.words)
                    {
                        if (v.type == "n" && v.plural != "-")
                        {
                            listWords.Add(v);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            int count = listWords.Count;
        }
        #endregion

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
            if (answer == AnswerWord)
            {
                RightAnswers++;
                guessedWord.Add(GeneratedWord);
                GeneratedWordGender = "";
                return true;
            }
            else if (answer == null)
            {
                return true;
            }
            else
            {
                WrongAnswers++;
                GeneratedWordGender = "";
                return false;
            }
        }
        #endregion

        #region picks a random word from the lecture
        public void GenerateWord()
        {
            if (guessedWord.Count == listWords.Count)
            {
                isOver = true;
                GeneratedWord = "Koniec";
            }
            else
            {
                //ensures that it wouldn't generate the same number twice        
                index = rnd.Next(0, listWords.Count);

            Back:;
                if (guessedWord.Count != 0)
                {
                    foreach (string s in guessedWord)
                    {
                        if (ModeSelection.SelectMode == "skge")
                        {
                            if (listWords[index].sk == s)
                            {
                                index = rnd.Next(0, listWords.Count);
                                goto Back;
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                            if (listWords[index].ge == s)
                            {
                                index = rnd.Next(0, listWords.Count);
                                goto Back;
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }


            switch (ModeSelection.SelectMode)
            {
                case "gesk":
                    if (listWords[index].gender == "m")
                    {
                        GeneratedWordGender = "der";
                    }
                    else if (listWords[index].gender == "f")
                    {
                        GeneratedWordGender = "die";
                    }
                    else if (listWords[index].gender == "n")
                    {
                        GeneratedWordGender = "das";
                    }
                    GeneratedWord = listWords[index].ge;
                    AnswerWord = listWords[index].sk;
                    break;
                case "skge":
                    GeneratedWord = listWords[index].sk;
                    AnswerWord = listWords[index].ge;
                    break;
                case "perfektum":
                    GeneratedWord = listWords[index].ge;
                    AnswerWord = listWords[index].perfektum;
                    break;
                case "plural":
                    GeneratedWord = listWords[index].ge;
                    AnswerWord = listWords[index].plural;
                    break;
                case "gender":
                    GeneratedWord = listWords[index].ge;
                    if (listWords[index].gender == "m")
                    {
                        AnswerWord = "der";
                    }
                    else if (listWords[index].gender == "f")
                    {
                        AnswerWord = "die";
                    }
                    else if (listWords[index].gender == "n")
                    {
                        AnswerWord = "das";
                    }
                    break;
            }
        }
        #endregion
    }

}



