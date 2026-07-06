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
        private string _filePath; // e.x, ..\..\..\..\Teams\arsenal.csv
        private List<Player> _players;

        /// <exception cref="ArgumentNullException">Thrown when the name is empty or null.</exception>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null || value.ToLower().Replace(" ", "") == "")
                {
                    throw new ArgumentNullException(nameof(Name), "The name of the team cannot be empty or null.");
                }
                _name = value.ToLower().Trim();
            }
        }

        /// <summary>Set file location using the name of the team e.x, {name.csv}. If the file don't exist, create it. Also Create the Directory if it don't exist.</summary>
        /// <param name="value">The name of the team.</param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null or empty.</exception>
        public string FilePath
        {
            get { return _filePath; }
            private set
            {
                if (value == null || value.ToLower().Replace(" ", "") == "")
                {
                    throw new ArgumentNullException(nameof(FilePath), " cannot be null or empty.");
                }

                // In case the directroy Teams was remove.
                if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams")))
                {
                    Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams"));
                }

                if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams", $"{value}.csv"))) // Exist even if the name is in capitals.
                {
                    using (File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams", $"{value}.csv"))) { }
                }

                _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams", $"{value}.csv");
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
                    throw new ArgumentNullException(nameof(Players), "The list of player cannot be null.");
                }
                _players = value;
            }
        }

        public Team(string name)
        {
            Name = name;
            FilePath = Name;
            Players = new List<Player>();
            LoadPlayersFromFile();
        }

        /// <summary>Write all players contain in 'Players' in the team file.</summary>
        public void SavePlayersToFile()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
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
            using (StreamReader reader = new StreamReader(FilePath))
            {
                while(!reader.EndOfStream)
                {
                    string playerString = reader.ReadLine();
                    try
                    {
                        Players.Add(new Player(playerString));
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
            using (StreamWriter writer = new StreamWriter(FilePath, append: false)) { }
            Players.Clear();
        }
    }
}
