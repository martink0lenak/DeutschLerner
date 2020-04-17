using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace German_learning
{
    class RootWord
    {
        public List<Word> words;
    }
    class Word
    {
        public string ge;
        public string sk;
        public string type;
        public string gender;
        public string perfektum;
        public string praeteritum;
        public string plural;
    }
}
