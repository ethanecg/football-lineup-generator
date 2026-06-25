using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.Design;

namespace ClassLibrary
{
    public class Team
    {
        private string _name;
        private string _teamFilePath; // e.x, ..\..\..\..\Teams\arsenal.csv
        private List<Player> _players;

        /// <exception cref="ArgumentNullException">Thrown when the name is empty or null.</exception>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null || value.ToLower().Replace(" ", "") == "")
                {
                    throw new ArgumentNullException(nameof(value), "The name of the team cannot be empty or null.");
                }
                _name = value.ToLower();
            }
        }

        /// <summary>Set file location using the name of the team e.x, {name.csv}. If the file don't exist, create it. Also Create the Directory if it don't exist.</summary>
        /// <param name="value">The name of the team.</param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null or empty.</exception>
        public string TeamFilePath
        {
            get { return _teamFilePath; }
            private set
            {
                if (value == null || value.ToLower().Replace(" ", "") == "")
                {
                    throw new ArgumentNullException(nameof(value), "The file of the player cannot be empty or null.");
                }

                value = value.Trim(); // Avoid having name written with multiple spaces at the start and at the end.

                if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams")))
                {
                    Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams"));
                }

                if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams", $"{value}.csv")))
                {
                    using (File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams", $"{value}.csv"))) { }
                }

                _teamFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams", $"{value}.csv");
            }
        }

        /// <exception cref="ArgumentNullException">Thrown if the list is null.</exception>
        public List<Player> Players
        {
            get { return _players; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The list of player cannot be null.");
                }
                _players = value;
            }
        }

        public Team(string name)
        {
            Name = name;
            TeamFilePath = Name;
            Players = new List<Player>();
            LoadPlayersFromFile();
        }

        /// <summary>Write all players contain in 'Players' in the team file.</summary>
        public void SavePlayersToFile()
        {
            using (StreamWriter writer = new StreamWriter(TeamFilePath))
            {
                foreach (Player p in Players)
                {
                    writer.WriteLine(p.ToCsvFormat());
                }
            }
        }
      
        /// <summary>Read the file and add players wich are in it.</summary>
        /// <exception cref="FormatException">Thrown if the a line in the file is in a incorrect format.</exception>
        /// <exception cref="Exception">Thrown if the player is in an incorrect format.</exception>
        public void LoadPlayersFromFile()
        {
            using (StreamReader reader = new StreamReader(TeamFilePath))
            {
                while(!reader.EndOfStream)
                {
                    string playerString = reader.ReadLine();

                    string[] playerArray = playerString.Split(';'); //  e.x, [Ousmane Dembélé] , [ST,RW]

                    if (playerArray.Count() != 2)
                    {
                        throw new FormatException("A player in the file is in an inccorect format. Make sure there is only one ';'.");
                    }
                        
                    string playerFullName = playerArray[0];
                    string[] playerFieldPositionArray = playerArray[1].Split(",");

                    try
                    {
                        Players.Add(new Player(playerFullName, playerFieldPositionArray.ToList()));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        /// <summary>Clear the file and Clear the list 'PlayerList'.</summary>
        public void EmptyFileAndClearPlayers()
        {
            using (StreamWriter writer = new StreamWriter(TeamFilePath, append: false)) { }
            Players.Clear();
        }
    }
}
