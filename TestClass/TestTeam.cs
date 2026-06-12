using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace TestClass
{
    [TestClass]
    public sealed class TestTeam
    {
        string validTeamName = "test";
        string validPlayerName = "Cristiano Ronaldo";
        List<string> validPositions = new List<string>() { "ST", "MC" };

        [TestMethod]
        public void TestCreateValidTeam()
        {
            Team team = new Team(validTeamName);
            List<string> listofFailures = new List<string>();

            if (team.Name != validTeamName)
            {
                listofFailures.Add($"The expected name {validPlayerName} does not equal the returned name {team.Name}");
            }
            if (!File.Exists(team.TeamFilePath))
            {
                listofFailures.Add($"The expected name {validPlayerName} does not equal the returned name {team.Name}");
            }

            if (listofFailures.Count != 0)
            {
                Assert.Fail("TestCreateValidPlayer failed with the following errors:\n" + string.Join("\n", listofFailures));
            }
        }

        [TestMethod]
        public void TestCreateTeamWithNullName()
        {
            Assert.Throws<ArgumentNullException>(() => new Team(null));
        }

        [TestMethod]
        public void TestCreateTeamWithEmptyName()
        {
            Assert.Throws<ArgumentNullException>(() => new Team(""));
        }

        [TestMethod]
        public void TestAddPlayerToPlayerList()
        {
            Team team = new Team(validTeamName);

            team.ClearAllThePlayersInTheFileAndResetPlayers();

            team.PlayerList.Add(new Player(validPlayerName, validPositions));

            Assert.AreEqual(1, team.PlayerList.Count());
        }

        [TestMethod]
        public void TestMethodAddPlayerListToFile()
        {
            Team team = new Team(validTeamName);

            team.PlayerList.Add(new Player(validPlayerName, validPositions));

            team.AddPlayerListToFile();

            using (StreamReader reader = new StreamReader(team.TeamFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Assert.AreEqual($"{team.PlayerList[0].PlayerInCsvFormat}", line);
                }
            }
        }
    }
}
