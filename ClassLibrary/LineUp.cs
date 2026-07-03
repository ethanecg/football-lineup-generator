using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Runtime.InteropServices.Swift;
using System.Text;

namespace ClassLibrary
{
    public class Lineup
    {
        private string _formation; // e.x, 1-4-4-2
        private List<List<Player>> _pitchPlayers; // The grid of players on the pitch (can contain null).
        private List<List<string>> _pitchPositions; // the grid of positions for the lineup (can contain null).
        private Team _team;
        private string _option; // Basically if you have a lineup of 5 rows the special roles (AM & DM) it's to know wich one will have.

        /// <param name="value"> A football lineup written with '-' in between player count and inculding the goaler e.x, 1-4-4-2.</param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null or empty.</exception>
        /// <exception cref="FormatException">Thrown when a number in the value failed to convert into an int.</exception>
        /// <exception cref="FormatException">Thrown when the value have less than 3 rows or more than 5.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the lineup text don't have 11 players.</exception>
        /// <exception cref="FormatException">Thrown when there is more than 1 goaler.</exception>
        /// <exception cref="FormatException">Thrown when there is a value of 0 in the formation.</exception>
        public string Formation
        {
            get { return _formation; }
            private set
            {
                if (value == null || value.Replace(" ", "") == "")
                {
                    throw new ArgumentNullException(nameof(value), " cannot be null nor empty.");
                }
                value = value.Replace(" ", "");
                string[] lineUpStringArray = value.Split('-');
                if (lineUpStringArray.Length > 6 || lineUpStringArray.Length < 4)
                {
                    throw new FormatException($"The formation cannnot have less than 4 lane nor cannot have more than 6.");
                }
                if (int.Parse(lineUpStringArray[0]) != 1)
                {
                    throw new FormatException($"You cannot have more than one goaler in the lineup.");
                }
                List<int> lineUpIntList = new List<int>();
                int totalNumberOfPlayer = 0;
                foreach (string v in lineUpStringArray)
                {
                    if (int.TryParse(v, out int r) == false)
                    {
                        throw new FormatException($"Fail to convert the value {v} into an int.");
                    }
                    else if (r == 0)
                    {
                        throw new FormatException($"You cannot have a value of 0 in your formation.");
                    }
                    else
                    {
                        lineUpIntList.Add(r);
                        totalNumberOfPlayer = totalNumberOfPlayer + r;
                    }
                }
                if (totalNumberOfPlayer != 11)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The string of the lineup must contain a total of 11 players.");
                }
                _formation = value;
            }
        }

        /// <exception cref="FormatException">Thrown when the number of players is not 11.</exception>
        public List<List<Player>> PitchPlayers
        {
            get { return _pitchPlayers; }
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
                if (count != 11)
                {
                    throw new FormatException("The number of players must be 11.");
                }

                _pitchPlayers = value;
            }
        }

        /// <exception cref="FormatException">Thrown when the number of positions is not 11.</exception>
        public List<List<string>> PitchPositions
        {
            get { return _pitchPositions; }
            set
            {
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
                    throw new FormatException("The number of positions on the pitch should be be 11.");
                }

                _pitchPositions = value;
            }
        }

        /// <exception cref="ArgumentNullException">Thrown when the team is null.</exception>
        public Team Team
        {
            get { return _team; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), " cannot be null.");
                }
                else if (value.Players.Count < 11)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), " The number of players in the team must be at least 11.");
                }
                _team = value;
            }
        }

        /// <summary>Check if the option is correct, between the 2 options : "AM" and "DM". If it's not needed it set it to "". This will be useful for FillPitchPositions().</summary>
        /// <exception cref="ArgumentNullException">Thrown when formation is null.</exception>
        /// <exception cref="FormatException">Thrown when the value is not "AM" or "DM".</exception>
        public string Option
        {
            get { return _option; }
            private set
            {
                if (PitchPlayers.Count != 5)
                {
                    _option = ""; // You don't need an option.
                }
                else // You need an option
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException(nameof(value), " cannot be null.");
                    }
                    value = value.Replace(" ", "");
                    if (value == "DM" || value == "AM")
                    {
                        _option = value;
                    }
                    else
                    {
                        throw new FormatException("The value must be 'AM' or 'DM' please select a correct format.");
                    }
                }
            }
        }

        /// <summary>Initialize the object and fill LineupSlots with null.</summary>
        /// <param name="formation">e.x, 4-4-2 (goaler must not be inculded.)</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="formation"/> is null or empty.</exception>
        /// <exception cref="FormatException">Thrown when <paramref name="formation"/> failed to convert into an int.</exception>
        /// <exception cref="FormatException">Thrown when the <paramref name="formation"/> have less than 4 rows or more than 6.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="formation"/> don't have 11 players.</exception>
        /// <exception cref="FormatException">Thrown when <paramref name="formation"/> have more than 1 goaler.</exception>
        /// <exception cref="FormatException">Thrown when there is a value of 0 in the <paramref name="formation"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="team"/> is null.</exception>
        public Lineup(string formation, Team team)
        {
            Formation = formation;

            List<List<Player>> initialPitchPlayers = new List<List<Player>>();
            List<List<string>> initialPitchPositions = new List<List<string>>();
            for (int r = 0; r < Formation.Split('-').Count(); r++)
            {
                List<Player> Players = new List<Player>();
                List<string> Positions = new List<string>();
                for (int c = 0; c < int.Parse(Formation.Split("-")[r]); c++)
                {
                    Players.Add(null);
                    Positions.Add(null);
                }
                initialPitchPlayers.Add(Players);
                initialPitchPositions.Add(Positions);
            }
            PitchPlayers = initialPitchPlayers;
            PitchPositions = initialPitchPositions;
            Option = "";
            Team = team;
        }

        /// <summary>Initialize the object and fill LineupSlots with null.</summary>
        /// <param name="formation">e.x, 4-4-2 (goaler must not be inculded.)</param>
        /// <param name="option">Only use if formation have 4 rows. Choose between "AM" or "DC"</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="formation"/> is null or empty.</exception>
        /// <exception cref="FormatException">Thrown when <paramref name="formation"/> failed to convert into an int.</exception>
        /// <exception cref="FormatException">Thrown when the <paramref name="formation"/> have less than 4 rows or more than 6.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="formation"/> don't have 11 players.</exception>
        /// <exception cref="FormatException">Thrown when <paramref name="formation"/> have more than 1 goaler.</exception>
        /// <exception cref="FormatException">Thrown when there is a value of 0 in the <paramref name="formation"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="team"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="option"/> is null.</exception>
        /// <exception cref="FormatException">Thrown when <paramref name="option"/> is not "AM" or "DM".</exception>
        public Lineup(string formation, Team team, string option)
        {
            Formation = formation;

            List<List<Player>> initialPitchPlayers = new List<List<Player>>();
            List<List<string>> initialPitchPositions = new List<List<string>>();
            for (int r = 0; r < Formation.Split('-').Count(); r++)
            {
                List<Player> Players = new List<Player>();
                List<string> Positions = new List<string>();
                for (int c = 0; c < int.Parse(Formation.Split("-")[r]); c++)
                {
                    Players.Add(null);
                    Positions.Add(null);
                }
                initialPitchPlayers.Add(Players);
                initialPitchPositions.Add(Positions);
            }
            PitchPlayers = initialPitchPlayers;
            PitchPositions = initialPitchPositions;
            Option = option;
            Team = team;
        }

        /// <summary>Fill the positions based on set of rules.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when PitchPositions don't have 11 players.</exception>
        public void FillPitchPositions()
        {
            int count = 0;
            for (int r = 0; r < PitchPositions.Count; r++)
            {
                for (int c = 0; c < PitchPositions[r].Count; c++)
                {
                    count++;
                }
            }
            if (count != 11)
            {
                throw new ArgumentOutOfRangeException(nameof(count), " did not get 11.");
            }

            int currentRow = 0;

            // Goaler
            PitchPositions[currentRow][0] = "G";
            currentRow++; //

            // Defender
            if (PitchPositions[currentRow].Count <= 3)
            {
                for (int c = 0; c < PitchPositions[1].Count; c++)
                {
                    PitchPositions[currentRow][c] = "DC";
                }
            }
            else
            {
                for (int c = 0; c < PitchPositions[currentRow].Count; c++)
                {
                    if (c == 0)
                    {
                        PitchPositions[currentRow][c] = "DL";
                    }
                    else if (c == PitchPositions[1].Count - 1)
                    {
                        PitchPositions[currentRow][c] = "DR";
                    }
                    else
                    {
                        PitchPositions[currentRow][c] = "DC";
                    }
                }
            }
            currentRow++; //

            // Defensive midfielders (optional)
            if (Option == "DM" || PitchPositions.Count == 5)
            {
                for (int c = 0; c < PitchPositions[1].Count; c++)
                {
                    PitchPositions[currentRow][c] = "DM";
                }
                currentRow++; //
            }

            // Midfielders
            if (PitchPositions[currentRow].Count <= 3)
            {
                for (int c = 0; c < PitchPositions[currentRow].Count; c++)
                {
                    PitchPositions[currentRow][c] = "MC";
                }
            }
            else
            {
                for (int c = 0; c < PitchPositions[currentRow].Count; c++)
                {
                    if (c == 0)
                    {
                        PitchPositions[currentRow][c] = "ML";

                    }
                    else if (c == PitchPositions[currentRow].Count - 1)
                    {
                        PitchPositions[currentRow][c] = "MR";
                    }
                    else
                    {
                        PitchPositions[currentRow][c] = "MC";
                    }
                }
            }
            currentRow++; // 

            // Attacking midfielders (optional)
            if (Option == "AM" || PitchPositions.Count == 5)
            {
                for (int c = 0; c < PitchPositions[currentRow].Count; c++)
                {
                    PitchPositions[currentRow][c] = "AM";
                }
                currentRow++; //
            }

            // Forwards
            if (PitchPositions[currentRow].Count <= 2)
            {
                for (int c = 0; c < PitchPositions[currentRow].Count; c++)
                {
                    PitchPositions[currentRow][c] = "ST";
                }
            }
            else
            {
                for (int c = 0; c < PitchPositions[currentRow].Count; c++)
                {
                    if (c == 0)
                    {
                        PitchPositions[currentRow][c] = "LW";
                    }
                    else if (c == PitchPositions[currentRow].Count - 1)
                    {
                        PitchPositions[currentRow][c] = "RW";
                    }
                    else
                    {
                        PitchPositions[currentRow][c] = "ST";
                    }
                }
            }
        }

        /// <summary>Fill players based on priority system (Exact position -> similar positions -> any positions).</summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when PitchPlayers don't have the same count as PitchPositions.</exception>
        /// <exception cref="ArgumentException">Thrown when PitchPlayers don't have the same number of columns as PitchPositions.</exception>
        public void FillPitchPlayersWithRandomPlayers()
        {
            if (PitchPlayers.Count != PitchPositions.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(PitchPlayers), " don't have the same number of rows.");
            }
            for (int r = 0; r < PitchPlayers.Count; r++)
            {
                int countPlayers = 0;
                int countPositions = 0;
                for (int c = 0; c < PitchPlayers[r].Count; c++)
                {
                    countPlayers++;
                }
                for (int c = 0; c < PitchPositions[r].Count; c++)
                {
                    countPositions++;
                }
                if (countPlayers != countPositions)
                {
                    throw new ArgumentOutOfRangeException(nameof(PitchPlayers), " don't have the same number of columns");
                }
            }
            
            if (!HasEnoughPlayers())
            {
                throw new ArgumentException(nameof(Team), " don't have enough player, must have atleast 11.");
            }

            // LineupSlotsPlayers and LineupSlotsPositions are 100% the same format.
            for (int r = 0; r < PitchPlayers.Count; r++)
            {
                for (int c = 0; c < PitchPlayers.Count; c++)
                {
                    PitchPlayers[r][c] = RandomPlayer(PlayersBasedOnPosition(PitchPositions[r][c]));
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

        /// <summary>(used with the list provided by PlayersBasedOnPosition) Return a random player in a list of player.</summary>
        /// <param name="playerList">A list of player based on their position. Use with the method ReturnListOfPlayerBasedOnPosition.</param>
        public Player RandomPlayer(List<Player> playerList)
        {
            Random random = new Random();
            int randomindex = random.Next(0, playerList.Count());
            return playerList[randomindex];
        }

        /// <summary>(used with PlayerBasedOnPosition) Return true if the player is already in the lineUp and else return false.</summary>
        public bool IsPlayerAlreadyInPitchPlayers(Player player)
        {
            for (int r = 0; r < PitchPlayers.Count(); r++)
            {
                for (int c = 0; c < PitchPlayers[r].Count; c++)
                {
                    if (player == PitchPlayers[r][c])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>Search for same position and return Players. If none are found, find with similar position then find with anyone.</summary>
        public List<Player> PlayersBasedOnPosition(string position)
        {
            bool isValid = false;
            foreach (string allowedP in AllowedFieldPositions.ALLOWED_FIELD_POSITIONS)
            {
                if (allowedP.Contains(position))
                {
                    isValid = true;
                }
            }
            if (isValid == false)
            {
                throw new FormatException("The positon is not valid.");
            }

            List<Player> positionPlayers = new List<Player>();

            // Fill with players of the same position.
            foreach (Player player in Team.Players)
            {
                if (player.FieldPositions.Contains(position) && !IsPlayerAlreadyInPitchPlayers(player))
                {
                    positionPlayers.Add(player);
                }
            }

            // Fill with players of similar position
            if (positionPlayers.Count == 0)
            {
                List<string> defendersPriority = new List<string>() { "DM", "DL", "DC", "DR" };
                List<string> midfieldersPriority = new List<string>() { "AM", "ML", "MC", "MR", "DM" };
                List<string> forwardsPriority = new List<string>() { "ST", "LW", "RW", "AM" };

                if (defendersPriority.Contains(position))
                {
                    foreach (string po in defendersPriority)
                    {
                        foreach (Player player in Team.Players)
                        {
                            if (player.FieldPositions.Contains(po) && !IsPlayerAlreadyInPitchPlayers(player))
                            {
                                positionPlayers.Add(player);
                            }
                        }
                    }
                }
                else if (forwardsPriority.Contains(position))
                {
                    foreach (string po in forwardsPriority)
                    {
                        foreach (Player player in Team.Players)
                        {
                            if (player.FieldPositions.Contains(po) && !IsPlayerAlreadyInPitchPlayers(player))
                            {
                                positionPlayers.Add(player);
                            }
                        }
                    }
                }
                else if (midfieldersPriority.Contains(position))
                {
                    foreach (string po in midfieldersPriority)
                    {
                        foreach (Player player in Team.Players)
                        {
                            if (player.FieldPositions.Contains(po) && !IsPlayerAlreadyInPitchPlayers(player))
                            {
                                positionPlayers.Add(player);
                            }
                        }
                    }
                }
            }

            // Fill with any players.
            if (positionPlayers.Count == 0)
            {
                foreach (Player player in Team.Players)
                {
                    if (!IsPlayerAlreadyInPitchPlayers(player))
                    {
                        positionPlayers.Add(player);
                    }
                }
            }

            return positionPlayers;
        }

        /// <summary>Make every players null</summary>
        public void EmptyTheLineupSlotsPlayers()
        {
            for (int r = 0; r < PitchPlayers.Count(); r++)
            {
                for (int c = 0; c < PitchPlayers.Count(); c++)
                {
                    PitchPlayers[r][c] = null;
                }
            }
        }
    }
}
