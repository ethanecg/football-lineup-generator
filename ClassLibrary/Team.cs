using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClassLibrary
{
    /// <summary>
    /// This class is used to read, write and create in a {team}.csv file to manage a list of players in the team.
    /// </summary>
    public class Team
    {
        private string _name;
        private string _teamFilePath; // e.x, ..\..\..\..\Teams\arsenal.csv
        private List<Player> _playerList;

        /// <summary>
        /// The name of the team, make the name in lower case. It will be used to name the .csv file.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when the name is empty or null.</exception>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null || value.ToLower().Replace(" ", "") == "")
                {
                    throw new ArgumentNullException("The name of the team cannot be empty or null.");
                }
                _name = value.ToLower();
            }
        }

        /// <summary>
        /// Create a new file using the name of the team e.x, {name.csv}. If the file already exist, do nothing.
        /// </summary>
        /// <param name="value">the name of the team</param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null or empty.</exception>
        public string TeamFilePath
        {
            get { return _teamFilePath; }
            private set
            {
                if (value == null || value.ToLower().Replace(" ", "") == "")
                {
                    throw new ArgumentNullException("The file of the player cannot be empty or null.");
                }
                else if (!File.Exists($"..\\..\\..\\..\\Teams\\{value}.csv"))
                {
                    using (File.Create($"..\\..\\..\\..\\Teams\\{value}.csv"))
                    {

                    }
                }
                _teamFilePath = $"..\\..\\..\\..\\Teams\\{value}.csv";
            }
        }

        /// <summary>
        /// A list of players.
        /// </summary>
        /// <param name="value">A list of players that are in the TeamFilePath.</param>
        public List<Player> PlayerList
        {
            get { return _playerList; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException("The list of player cannot be empty or null.");
                }
                _playerList = value;
            }
        }

        public Team(string name)
        {
            Name = name;
            TeamFilePath = Name;
            AddFileToPlayerList(TeamFilePath);
        }

        /// <summary>
        /// Add new players to the team file using the function Player.playerInCsvFormat().
        /// </summary>
        /// <param name="filePath"> The team file path.</param>>
        public void AddPlayerListToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(TeamFilePath))
            {
                foreach (Player p in PlayerList)
                {
                    writer.WriteLine(p.playerInCsvFormat());
                }
            }
        }
      
        /// <summary>
        /// Add the players in the file to the PlayerList.
        /// </summary>
        /// <param name="filePath"></param>
        public void AddFileToPlayerList(string filePath)
        {
            using (StreamReader reader = new StreamReader(TeamFilePath))
            {
                while(!reader.EndOfStream)
                {
                    string playerString = reader.ReadLine();

                    string[] playerArray = playerString.Split(';'); //  e.x, [Ousmane Dembélé] , [ST,RW]

                    string playerFullName = playerArray[0];
                    string[] playerFieldPositionArray = playerArray[1].Split(",");

                    PlayerList.Add(new Player(playerFullName, playerFieldPositionArray.ToList()));
                }
            }
        }
    }
}
