using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Lineup
    {
        private string _lineUpText; // e.x, 4-4-2
        private List<List<Player>> _lineupSlots; // The actual grid of players on the pitch (can contain null).
        private Team _team;

        /// <summary>Add a goaler to you're line up. e.x, 4-4-2 -> 1-4-4-2.</summary>
        /// <param name="value"> A football lineup written with '-' in between player count and excluding the goaler e.x, 4-4-2.</param>
        /// <exception cref="ArgumentNullException">Thrown if the value is null or empty.</exception>
        /// <exception cref="FormatException">Thrown if a number in the value failed to convert into an int. Also thrown if the value have less than 3 row or more than 5.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the lineup text don't have 10 players.</exception>
        public string LineupText
        {
            get {  return _lineUpText; }
            private set
            {
                if (value == null || value.Replace(" ", "") == "")
                {
                    throw new ArgumentNullException(nameof(value), " cannot be null nor empty.");
                }

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
                    throw new ArgumentOutOfRangeException(nameof(value), "The string of the lineup must contain a total of 10 players.");
                }
                _lineUpText = $"1-{value}"; // Add the goaler.
            }
        }

        /// <exception cref="FormatException">Thrown if the total number of players is not 11.</exception>
        public List<List<Player>> LineupSlots
        {
            get { return _lineupSlots; }
            private set
            {
                int count = 0;
                for (int r = 0; r < value.Count; r++)
                {
                    for (int c = 0; c < value[r].Count; c++)
                    {
                        count++;
                    }
                }
                if (count != 11) // SHOULD NEVER HAPPEN but just in case ;)
                {
                    throw new FormatException("The number of players must be 11.");
                }

                _lineupSlots = value;
            }
        }

        /// <exception cref="ArgumentNullException">Thrown if the the team is null.</exception>
        public Team Team
        {
            get { return _team; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The team cannot be null.");
                }
                else if (value.Players.Count < 11)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The number of players in the team must be at least 11.");
                }
                _team = value;
            }
        }

        /// <summary>Initialise the object and fill LineupSlots with null.</summary>
        /// <param name="lineUpText">e.x, 4-4-2 (goaler must not be inculded.)</param>
        public Lineup(string lineUpText, Team team)
        {
            LineupText = lineUpText;

            List<List<Player>> initialLineupSlots = new List<List<Player>>();
            for (int r = 0; r < LineupText.Split('-').Count(); r++)
            {
                List<Player> listOfPlayers = new List<Player>();
                for (int c = 0; c < int.Parse(LineupText.Split("-")[r]); c++)
                {
                    listOfPlayers.Add(null);
                }
                initialLineupSlots.Add(listOfPlayers);
            }

            LineupSlots = initialLineupSlots;
            Team = team;
        }

        /// <summary>Add a random goaler to LineUpList[0]. If no goalers are found, take a random player to take the position.</summary>
        public void AddRandomGoalerToLineupSlots()
        {
            List<Player> goalerList = PlayerBasedOnPosition(new List<string> { "G" }, Team.Players);

            // If there's no goaler.
            if (goalerList.Count() < 1)
            {
                PlayerBasedOnPosition(AllowedFieldPositions.ALLOWED_FIELD_POSITIONS.ToList<string>(), goalerList);
            }

            // Add the goaler to the LineUpArray
            LineupSlots[0].Add(RandomPlayer(goalerList));
        }

        public void AddRandomDefendersToLineupSlots()
        {
            // The defenders are always on the index 1.
            List<Player> defenderList = PlayerBasedOnPosition(new List<string> { "DL", "DC", "DR" }, Team.Players);
            
            if (defenderList.Count < LineupSlots[1].Count)
            {
                // Add any player in the list
                PlayerBasedOnPosition(AllowedFieldPositions.ALLOWED_FIELD_POSITIONS.ToList<string>(), defenderList);
            }

            for (int c = 0; c < LineupSlots[1].Count;c++)
            {
                // If there is a center.
                if (LineupSlots[1].Count % 2 != 0)
                {
                    // If the player is left position.
                    if ((c / 2) < (LineupSlots[1].Count / 2) + 1)
                    {
                        // Add the goaler to the LineUpArray
                        LineupSlots[1].Add(RandomPlayer(PlayerBasedOnPosition(new List<string> { "DL" }, defenderList)));
                    }
                    // If the player is center position.
                    if ((c / 2) == (LineupSlots[1].Count / 2) + 1)
                    {
                        LineupSlots[1].Add(RandomPlayer(PlayerBasedOnPosition(new List<string> { "DC" }, defenderList)));
                    }
                    // If the center is right position.
                    if ((c / 2) > (LineupSlots[1].Count / 2) + 1)
                    {
                        LineupSlots[1].Add(RandomPlayer(PlayerBasedOnPosition(new List<string> { "DR" }, defenderList)));
                    }
                }
                // If there is no center.
                else
                {
                    // If the player is left position.
                    if ((c / 2) <= (LineupSlots[1].Count / 2))
                    {
                        LineupSlots[1].Add(RandomPlayer(PlayerBasedOnPosition(new List<string> { "DL" }, defenderList)));
                    }
                    // If the player is right position.
                    if ((c / 2) > (LineupSlots[1].Count / 2))
                    {
                        LineupSlots[1].Add(RandomPlayer(PlayerBasedOnPosition(new List<string> { "DR" }, defenderList)));
                    }
                }
            }
        }

        /// <summary>Check in the TeamFile to see if there's atleast 11 players.</summary>
        public bool HasEnoughPlayers()
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
            return true;
        }

        /// <summary>Return true if the player is already in the lineUp and else return false.
        /// <param name="player"></param>
        /// <returns></returns>
        public bool IsPlayerAlreadyInLineupSlots(Player player)
        {
            for (int r = 0; r < LineupSlots.Count(); r++)
            {
                for (int c = 0; c < LineupSlots[r].Count; c++)
                {
                    if (player == LineupSlots[r][c])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>Make every players null</summary>
        public void EmptyTheLineupSlots()
        {
            for (int r = 0; r < LineupSlots.Count(); r++)
            {
                for (int c = 0; c < LineupSlots.Count(); c++)
                {
                    LineupSlots[r][c] = null;
                }
            }
        }

        /// <summary>Check if the players have same positions and check if they are already in the LineupSlots.</summary>
        /// <exception cref="ArgumentNullException">Thrown if the list of player is null or empty.</exception>
        /// <param name="players">All the wanted positions.</param>
        public List<Player> PlayerBasedOnPosition(List<string> positions, List<Player> players)
        {
            if (players == null || players.Count == 0)
            {
                throw new ArgumentNullException("" + "The player list is null or empty");
            }

            List<Player> positionPlayerList = new List<Player>();

            foreach (string position in positions)
            {
                foreach (Player player in players)
                {
                    if (player.FieldPositions.Contains(position) && !IsPlayerAlreadyInLineupSlots(player))
                    {
                        positionPlayerList.Add(player);
                    }
                }
            }

            return positionPlayerList;
        }

        /// <summary>Return a random player in a list of player.</summary>
        /// <param name="playerList">A list of player based on their position. Use with the method ReturnListOfPlayerBasedOnPosition.</param>
        public Player RandomPlayer(List<Player> playerList)
        {
            Random random = new Random();
            int randomindex = random.Next(0, playerList.Count());
            return playerList[randomindex];
        }
    }
}
