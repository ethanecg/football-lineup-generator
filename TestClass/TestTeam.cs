using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace TestClass
{
    [TestClass]
    public sealed class TestTeam
    {
        string validPlayerName = "Cristiano Ronaldo";
        List<string> validPositions = new List<string>() { "ST", "MC" };

        [TestMethod]
        public void TestCreateValidTeam()
        {
            string validTeamName = $"test_{Guid.NewGuid()}";

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

            if (File.Exists(team.TeamFilePath))
            {
                File.Delete(team.TeamFilePath);
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
            string validTeamName = $"test_{Guid.NewGuid()}";

            Team team = new Team(validTeamName);

            team.Players.Add(new Player(validPlayerName, validPositions));

            Assert.AreEqual(1, team.Players.Count());

            // Delete the file.
            if (File.Exists(team.TeamFilePath))
            {
                File.Delete(team.TeamFilePath);
            }
        }

        [TestMethod]
        public void TestMethodAddPlayerListToFile()
        {
            string validTeamName = $"test_{Guid.NewGuid()}";

            Team team = new Team(validTeamName);

            team.Players.Add(new Player(validPlayerName, validPositions));

            team.SavePlayerToFile();

            using (StreamReader reader = new StreamReader(team.TeamFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Assert.AreEqual($"{team.Players[0].ToCsvFormat()}", line);
                }
            }

            // Delete the file.
            if (File.Exists(team.TeamFilePath))
            {
                File.Delete(team.TeamFilePath);
            }
        }

        [TestMethod]
        public void TestMethodAddFileToPlayerList()
        {
            string validTeamName = $"test_{Guid.NewGuid()}";

            Team team = new Team(validTeamName);

            Player player = new Player(validPlayerName, validPositions);

            using (StreamWriter writer = new StreamWriter(team.TeamFilePath))
            {
                writer.WriteLine($"{player.ToCsvFormat()}");
            }

            team.SavePlayerToFile();

            List<Player> expectedValue = new List<Player>();
            expectedValue.Add(player);

            Assert.AreEqual(expectedValue[0].ToCsvFormat(), team.Players[0].ToCsvFormat());

            // Delete the file.
            if (File.Exists(team.TeamFilePath))
            {
                File.Delete(team.TeamFilePath);
            }
        }

        [TestMethod]
        public void TestMethodClearAllThePlayersInTheFileAndClearPlayerList()
        {
            string validTeamName = $"test_{Guid.NewGuid()}";

            Team team = new Team(validTeamName);

            Player player = new Player(validPlayerName, validPositions);

            team.Players.Add(player);

            team.EmptyFileAndClearPlayers();

            Assert.AreEqual(0, team.Players.Count());

            int count = 0;
            using (StreamReader reader = new StreamReader(team.TeamFilePath))
            {
                while (!reader.EndOfStream)
                {
                    count++;
                }
            }
            Assert.AreEqual(0, count);

            // Delete the file.
            if (File.Exists(team.TeamFilePath))
            {
                File.Delete(team.TeamFilePath);
            }
        }
    }
}
