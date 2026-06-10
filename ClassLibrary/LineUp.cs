using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class LineUp
    {
        private string _lineUpText;
        private string[] _lineUpArray;

        /// <summary>
        /// Take a formation in this format e.x, : 4-4-2, and add a goal keeper {4-4-2} -> {1-4-4-2} throw exception if it fail.
        /// </summary>
        /// <param name="value"> A fromation in this format : 4-4-2, representing a team line up of 10 players (the goaler is not counted).
        public string LineUpText
        {
            get {  return _lineUpText; }
            private set
            {
               string[] lineUpStringArray = value.Split('-');
               List<int> lineUpIntList = new List<int>();
               int totalNumberOfPlayer = 0;
               foreach (string v in lineUpStringArray)
               {
                    if (int.TryParse(v, out int r) == false)
                    {
                        throw new FormatException($"Fail to convert the value {v} into an int.");
                    }
                    else
                    {
                        lineUpIntList.Add(r);
                        totalNumberOfPlayer = totalNumberOfPlayer + r;
                    }
               }
               if (totalNumberOfPlayer != 10)
               {
                    throw new ArgumentOutOfRangeException("The string of the lineup must contain a total of 10 players (the goalkeeper is not included in the lineup).");
               }
                value = $"1-{_lineUpText}"; // Add the goal keeper.

            }
        }

        public string[] LineUpArray
        {
            get { return _lineUpArray; }
            set
            {
                // Here the LineUpText is 100% valid so no error should occur.
                if (value.Count() != 11)
                {
                    throw new FormatException("The receive value must contain 11 ?index.");
                }
                _lineUpArray = value;
            }
        }

        public LineUp(string lineUpText)
        {
            LineUpText = lineUpText;

            string[] _ = new string[11];
            LineUpArray = _;
        }

        public void AddPlayersArrayToLineUpList(string[] playerArray)
        {
            if (playerArray.Count() != 11)
            {
                throw new FormatException("The playerArray must have 11 index.");
            }
            for (int i = 0; i < LineUpArray.Count(); i++)
            {
                LineUpArray[i] = playerArray[i];
            }
        }

        public void EmptyTheLineUpList()
        {
            for (int i = 0; i < LineUpArray.Count(); i++)
            {
                LineUpArray[i] = "";
            }
        }
    }
}
