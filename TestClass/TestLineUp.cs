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
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "DL", "DR" }), // Versatile Fullback

            // Defensive Midfielders (DM)
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "DM" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "DM", "DC" }), // Defensive Midfielder / Center Back

            // Central & Side Midfielders (MC, ML, MR, DM)
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "MC" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "MC" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "ML", "MR" }), // Wide Midfielder
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "DM" }),       

            // Attacking Midfielders (AM)
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "AM" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "AM", "MC" }), // Playmaker

            // Wingers (LW, RW)
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "LW" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "RW" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "LW", "RW", "ST" }), // Versatile Attacker

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
        public void TestCreateLineupOfTwoRowsLineup()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayerToFile();

            Assert.Throws<FormatException>(() => new Lineup("5-5", validTeam));

            if (File.Exists(validTeam.TeamFilePath))
            {
                File.Delete(validTeam.TeamFilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfSixRowsLineup()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayerToFile();

            Assert.Throws<FormatException>(() => new Lineup("2-2-2-2-1-1", validTeam));

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

            Assert.Throws<FormatException>(() => new Lineup("4-A-2", validTeam));

            if (File.Exists(validTeam.TeamFilePath))
            {
                File.Delete(validTeam.TeamFilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfWithLessThanTenPlayers()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayerToFile();

            Assert.Throws<ArgumentOutOfRangeException>(() => new Lineup("4-4-1", validTeam));

            if (File.Exists(validTeam.TeamFilePath))
            {
                File.Delete(validTeam.TeamFilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfWithMoreThanTenPlayers()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayerToFile();

            Assert.Throws<ArgumentOutOfRangeException>(() => new Lineup("4-4-3", validTeam));

            if (File.Exists(validTeam.TeamFilePath))
            {
                File.Delete(validTeam.TeamFilePath);
            }
        }
        #endregion

        [TestMethod]
        public void TestCreateLineupOfWithANullTeam()
        {
            Assert.Throws<ArgumentNullException>(() => new Lineup("4-4-2", null));
        }

        [TestMethod]
        public void TestCreateLineupOfWithATeamPlayersOfLessThanEleven()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = new List<Player>() { new Player("test test", new List<string>() { "G" }) };
            validTeam.SavePlayerToFile();

            Assert.Throws<ArgumentOutOfRangeException>(() => new Lineup("4-4-2", validTeam));
        }
    }
}
