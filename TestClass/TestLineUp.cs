using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestClass
{
    [TestClass]
    public class TestLineup
    {
        public List<Player> validPlayers = new List<Player>()
        {
            // Goalkeepers (G)
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "G" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "G" }),

            // Central Defenders (DC)
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "DC" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "DC" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "DC" }),

            // Fullbacks / Wingbacks (DL, DR)
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "DL" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "DR" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "DL", "DR" }),

            // Defensive Midfielders (DM)
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "DM" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "DM", "DC" }),

            // Central & Side Midfielders (MC, ML, MR, DM)
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "MC" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "MC" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "ML", "MR" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "DM" }),       

            // Attacking Midfielders (AM)
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "AM" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "AM", "MC" }),

            // Wingers (LW, RW)
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "LW" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "RW" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "LW", "RW", "ST" }),

            // Strikers (ST)
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "ST" })
        };

        #region TestLineupText
        [TestMethod]
        public void TestCreateEmptyLineup()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayerToFile();

            Assert.Throws<ArgumentNullException>(() => new Lineup("", validTeam));

            if (File.Exists(validTeam.TeamFilePath))
            {
                File.Delete(validTeam.TeamFilePath);
            }
        }

        [TestMethod]
        public void TestCreateNullLineup()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayerToFile();

            Assert.Throws<ArgumentNullException>(() => new Lineup(null, validTeam));

            if (File.Exists(validTeam.TeamFilePath))
            {
                File.Delete(validTeam.TeamFilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfThreeRowsLineup()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayerToFile();

            Assert.Throws<FormatException>(() => new Lineup("1-5-5", validTeam));

            if (File.Exists(validTeam.TeamFilePath))
            {
                File.Delete(validTeam.TeamFilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfSevenRowsLineup()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayerToFile();

            Assert.Throws<FormatException>(() => new Lineup("1-2-2-2-2-1-1", validTeam));

            if (File.Exists(validTeam.TeamFilePath))
            {
                File.Delete(validTeam.TeamFilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfWithInvalidChar()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayerToFile();

            Assert.Throws<FormatException>(() => new Lineup("1-4-A-2", validTeam));

            if (File.Exists(validTeam.TeamFilePath))
            {
                File.Delete(validTeam.TeamFilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfWithLessThanElevenPlayers()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayerToFile();

            Assert.Throws<ArgumentOutOfRangeException>(() => new Lineup("1-4-4-1", validTeam));

            if (File.Exists(validTeam.TeamFilePath))
            {
                File.Delete(validTeam.TeamFilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfWithMoreThanElevenPlayers()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayerToFile();

            Assert.Throws<ArgumentOutOfRangeException>(() => new Lineup("1-4-4-3", validTeam));

            if (File.Exists(validTeam.TeamFilePath))
            {
                File.Delete(validTeam.TeamFilePath);
            }
        }
        #endregion

        [TestMethod]
        public void TestCreateLineupOfWithANullTeam()
        {
            Assert.Throws<ArgumentNullException>(() => new Lineup("1-4-4-2", null));
        }

        [TestMethod]
        public void TestCreateLineupOfWithATeamPlayersOfLessThanEleven()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = new List<Player>() { new Player("test test", new List<string>() { "G" }) };
            validTeam.SavePlayerToFile();

            Assert.Throws<ArgumentOutOfRangeException>(() => new Lineup("1-4-4-2", validTeam));
        }
    }
}
