using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class LineUp
    {
        public static readonly List<string> VALID_FIELD_POSITIONS = new List<string>() // This list cannot be modified
        {
            "ST","LW","RW",
            "AM",
            "MC","MR","ML","MD",
            "DM",
            "DL","DC","DR",
            "G"
        };

        private string _lineUpText;
        private List<List<Player>> _lineUpList; // Multiple list in a list, can contain null.
        private Team _team;

        /// <summary>
        /// Take a formation in this format e.x, : 4-4-2, and the proprety will a goal keeper {4-4-2} -> {1-4-4-2}. The formation cannnot (not counting gk) have less than 3 lane and
        /// cannot have more than 5.
        /// </summary>
        /// <param name="value"> A fromation in this format : 4-4-2, representing a team line up of 10 players (the goaler is not counted).
        /// <exception cref="FormatException">Thrown if a value failed to convert into an int.</exception>
        public string LineUpText
        {
            get {  return _lineUpText; }
            private set
            {
               string[] lineUpStringArray = value.Split('-');
                if (lineUpStringArray.Length > 5 || lineUpStringArray.Length < 3)
                {
                    throw new FormatException($"The formation cannnot (not counting gk) have less than 3 lane and cannot have more than 5.");
                }
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
                _lineUpText = $"1-{value}"; // Add the goal keeper.

            }
        }

        /// <summary>
        /// Create a LineUpArray of exacly the size of 11. The object in the array can be null.
        /// </summary>
        /// <exception cref="FormatException">Thrown if the size is not 11.</exception>
        public List<List<Player>> LineUpList
        {
            get { return _lineUpList; }
            private set
            {
                // Here the LineUpText is 100% valid so no error should occur.
                int count = 0;
                for (int r = 0; r < value.Count; r++)
                {
                    for (int c = 0; c < value[r].Count; c++)
                    {
                        count++;
                    }
                }
                if (count != 11)
                {
                    throw new FormatException("The size is not 11.");
                }

                _lineUpList = value;
            }
        }

        public Team Team
        {
            get { return _team; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("" + "The team cannot be null");
                }
                _team = value;
            }
        }

        public LineUp(string lineUpText, Team team)
        {
            LineUpText = lineUpText;

            List<List<Player>> tempLineUpList = new List<List<Player>>();
            for (int r = 1; r < LineUpText.Split('-').Count(); r++)
            {
                List<Player> listOfPlayers = new List<Player>();
                for (int c = 1; c < LineUpText.Split("-")[r].Count(); c++)
                {
                    listOfPlayers.Add(null);
                }
                tempLineUpList.Add(listOfPlayers);
            }
            LineUpList = tempLineUpList;

            Team = team;
        }

        /// <summary>
        /// Add a random goaler to LineUpList[0]. If no goalers are found, take a random player to take the position.
        /// </summary>
        public void AddGoalerToLineUpArrayRandomly()
        {
            List<Player> goalerList = new List<Player>();
            foreach (Player p in Team.PlayerList)
            {
                if (p.FieldPositions.Contains("G") && !CheckIfPlayerAlreadyInLineUp(p))
                {
                    goalerList.Add(p);
                }
            }
            // If there's no goaler just take the whole player list.
            if (goalerList.Count() < 1)
            {
                foreach (Player p in Team.PlayerList)
                {
                    if (!CheckIfPlayerAlreadyInLineUp(p))
                    {
                        goalerList.Add(p);
                    }
                }
            }

            // Randomly choose a goaler.
            Random random = new Random();
            int randomindex = random.Next(0, goalerList.Count());

            // Add the goaler to the LineUpArray
            LineUpList[0].Add(goalerList[randomindex]);
        }

        public void AddDefenderToLineUpArrayRandomly()
        {
            // The defenders are always on the index 1.
            List<Player> defenderList = ReturnListOfPlayerBasedOnPosition(new List<string> { "DL", "DC", "DR" }, Team.PlayerList);
            
            if (defenderList.Count < LineUpList[1].Count)
            {
                // Add any player in the list
                ReturnListOfPlayerBasedOnPosition(VALID_FIELD_POSITIONS, defenderList);
            }

            for (int c = 0; c < LineUpList[1].Count;c++)
            {
                // If there is a center.
                if (LineUpList[1].Count % 2 != 0)
                {
                    // If the player is left position.
                    if ((c / 2) < (LineUpList[1].Count / 2) + 1)
                    {
                        ReturnRandomPlayer(ReturnListOfPlayerBasedOnPosition(new List<string> {"DL"}, defenderList));
                    }
                    // If the player is center position.
                    if ((c / 2) == (LineUpList[1].Count / 2) + 1)
                    {
                        ReturnRandomPlayer(ReturnListOfPlayerBasedOnPosition(new List<string> { "DC" }, defenderList));
                    }
                    // If the center is right position.
                    if ((c / 2) > (LineUpList[1].Count / 2) + 1)
                    {
                        ReturnRandomPlayer(ReturnListOfPlayerBasedOnPosition(new List<string> { "DR" }, defenderList));
                    }
                }
                // If there is no center.
                else
                {
                    // If the player is left position.
                    if ((c / 2) <= (LineUpList[1].Count / 2))
                    {
                        ReturnRandomPlayer(ReturnListOfPlayerBasedOnPosition(new List<string> { "DL" }, defenderList));
                    }
                    // If the player is right position.
                    if ((c / 2) > (LineUpList[1].Count / 2))
                    {
                        ReturnRandomPlayer(ReturnListOfPlayerBasedOnPosition(new List<string> { "DR" }, defenderList));
                    }
                }
            }
        }

        public bool VerifyIfTheTeamHaveAtLeast11Players()
        {
            int count = 0;
            using (StreamReader reader = new StreamReader(Team.TeamFilePath))
            {
                while (!reader.EndOfStream)
                {
                    count++;
                }
                if (count < 11)
                {
                    return false;
                }
            }
            // For a bugtest to check if it the team can desync from its file to his list.
            if (Team.PlayerList.Count != count)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Return true if the player is already in the lineUp and else return false.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool CheckIfPlayerAlreadyInLineUp(Player player)
        {
            for (int r = 0; r < LineUpList.Count(); r++)
            {
                for (int c = 0; c < LineUpList[r].Count; c++)
                {
                    if (player == LineUpList[r][c])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// This method make every player in listLineUp null.
        /// </summary>
        public void EmptyTheLineUpList()
        {
            for (int r = 0; r < LineUpList.Count(); r++)
            {
                for (int c = 0; c < LineUpList.Count(); c++)
                {
                    LineUpList[r][c] = null;
                }
            }
        }

        /// <summary>
        /// Search through a list of player and return a list of player with the same position. Also check if the player is already contained in the LineUpList.
        /// </summary>
        /// <param name="position">The position of the player.</param>
        /// <param name="playerList">A list of player.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if the list of player is null or empty.</exception>
        public List<Player> ReturnListOfPlayerBasedOnPosition(List<string> positionList, List<Player> playerList)
        {
            if (playerList == null || playerList.Count == 0)
            {
                throw new ArgumentNullException("" + "The player list is null or empty");
            }

            List<Player> positionPlayerList = new List<Player>();

            foreach (string position in positionList)
            {
                foreach (Player player in playerList)
                {
                    if (player.FieldPositions.Contains(position) && !CheckIfPlayerAlreadyInLineUp(player))
                    {
                        positionPlayerList.Add(player);
                    }
                }
            }

            return positionPlayerList;
        }

        /// <summary>
        /// Return a random player in a list of player.
        /// </summary>
        /// <param name="playerList">A list of player based on their position. Use with the method ReturnListOfPlayerBasedOnPosition.</param>
        /// <returns></returns>
        public Player ReturnRandomPlayer(List<Player> playerList)
        {
            Random random = new Random();
            int randomindex = random.Next(0, playerList.Count());

            return playerList[randomindex];
        }
    }
}
