using System;

namespace Scores
{
    public class HIscore
    {
        private string _name;
        private int _score;

        //public HIscore(string Name, int Score)
        //{
        //    _name = Name;
        //    _score = Score;
        //}

        //public HIscore()
        //{
        //}

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Score
        {
            get => _score;
            set => _score = value;
        }
    }
}
