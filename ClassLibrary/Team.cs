using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClassLibrary
{
    public class Team
    {
        private string _name;
        private string _teamFilePath;
        private List<Player> _playerList;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null || value.ToLower().Replace(" ", "") == "")
                {
                    throw new ArgumentNullException("The name of the team cannot be empty or null.");
                }
                _name = value;
            }
        }

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
            TeamFilePath = name;
        }

        public void AddPlayerListToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(TeamFilePath))
            {
                foreach (Player p in PlayerList)
                {
                    string playerFirstName = p.FirstName;
                    string playerLastName = p.LastName;
                    writer.Write($"{playerFirstName} {playerLastName};");

                    int count = 0;

                    foreach (string fp in p.FieldPositions)
                    {
                        count++;
                        if (count == fp.Count())
                        {
                            writer.Write($"{fp}\n");
                        }
                        else
                        {
                            writer.Write($"{fp},");
                        }
                    }
                }
            }
        }
      
        public void AddFileToPlayerList(string filePath)
        {
            using (StreamReader reader = new StreamReader(TeamFilePath))
            {
                while(!reader.EndOfStream)
                {
                    string playerString = reader.ReadLine();

                    string[] playerArray = playerString.Split(';');
                    // playerArray exemple : [Ousmane Dembélé] , [ST,RW]
                    string playerFullName = playerArray[0];
                    string[] playerFieldPositionArray = playerArray[1].Split(",");

                    PlayerList.Add(new Player(playerFullName, playerFieldPositionArray.ToList()));
                }
            }
        }
    }
}
