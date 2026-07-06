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

        #region TestFormation

        [TestMethod]
        public void TestCreateEmptyLineup()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayersToFile();

            Assert.Throws<ArgumentNullException>(() => new Lineup("", validTeam));

            if (File.Exists(validTeam.FilePath))
            {
                File.Delete(validTeam.FilePath);
            }
        }

        [TestMethod]
        public void TestCreateNullLineup()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayersToFile();

            Assert.Throws<ArgumentNullException>(() => new Lineup(null, validTeam));

            if (File.Exists(validTeam.FilePath))
            {
                File.Delete(validTeam.FilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfWithInvalidChar()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayersToFile();

            Assert.Throws<FormatException>(() => new Lineup("1-4-A-2", validTeam));

            if (File.Exists(validTeam.FilePath))
            {
                File.Delete(validTeam.FilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfThreeRowsLineup()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayersToFile();

            Assert.Throws<FormatException>(() => new Lineup("1-5-5", validTeam));

            if (File.Exists(validTeam.FilePath))
            {
                File.Delete(validTeam.FilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfSevenRowsLineup()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayersToFile();

            Assert.Throws<FormatException>(() => new Lineup("1-2-2-2-2-1-1", validTeam));

            if (File.Exists(validTeam.FilePath))
            {
                File.Delete(validTeam.FilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfWithLessThanElevenPlayers()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayersToFile();

            Assert.Throws<ArgumentOutOfRangeException>(() => new Lineup("1-4-4-1", validTeam));

            if (File.Exists(validTeam.FilePath))
            {
                File.Delete(validTeam.FilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfWithMoreThanElevenPlayers()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayersToFile();

            Assert.Throws<ArgumentOutOfRangeException>(() => new Lineup("1-4-4-3", validTeam));

            if (File.Exists(validTeam.FilePath))
            {
                File.Delete(validTeam.FilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfWithTwoGoalers()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayersToFile();

            Assert.Throws<FormatException>(() => new Lineup("2-4-4-1", validTeam));

            if (File.Exists(validTeam.FilePath))
            {
                File.Delete(validTeam.FilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfWithAValueOf0InTheFormation()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayersToFile();

            Assert.Throws<FormatException>(() => new Lineup("1-4-4-0-2", validTeam));

            if (File.Exists(validTeam.FilePath))
            {
                File.Delete(validTeam.FilePath);
            }
        }
        #endregion

        #region TestTeam
        [TestMethod]
        public void TestCreateLineupOfWithANullTeam()
        {
            Assert.Throws<ArgumentNullException>(() => new Lineup("1-4-4-2", null));
        }
        #endregion

        #region TestOption
        [TestMethod]
        public void TestCreateLineupOfWithANullOption()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayersToFile();

            Assert.Throws<ArgumentNullException>(() => new Lineup("1-4-4-1-1", validTeam, null));

            if (File.Exists(validTeam.FilePath))
            {
                File.Delete(validTeam.FilePath);
            }
        }

        [TestMethod]
        public void TestCreateLineupOfWithAnInvalidOption()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid()}");
            validTeam.Players = validPlayers;
            validTeam.SavePlayersToFile();

            Assert.Throws<FormatException>(() => new Lineup("1-4-4-1-1", validTeam, "CM"));

            if (File.Exists(validTeam.FilePath))
            {
                File.Delete(validTeam.FilePath);
            }
        }
        #endregion
    }
}
