using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestClass
{
    [TestClass]
    public class TestLineUp
    {
        public List<Player> validListOfPlayer = new List<Player>()
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

            // Central & Side Midfielders (MC, ML, MR, MD)
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "MC" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "MC" }),
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "ML", "MR" }), // Wide Midfielder
            new Player($"Player {Guid.NewGuid()}", new List<string>() { "MD" }),       

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

        [TestMethod]
        public void TestCreateValidLineUp()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid}");
            validTeam.PlayerList = validListOfPlayer;
            validTeam.AddPlayerListToFile();

            LineUp validLineup = new LineUp("4-4-2", validTeam);

            /*
                { null }
                { null null null null }
                { null null null null }
                { null null }
            */

            Assert.AreEqual(4 ,validLineup.LineUpList.Count, "The lineUpList did not get the expected count.");
            for (int r = 0; r < validLineup.LineUpList.Count; r++)
            {
                switch (r)
                {
                    case 0:
                        Assert.AreEqual(1 ,validLineup.LineUpList[r].Count, "The player list in the LineUpList did not get the expected count.");
                        break;
                    case 1:
                        Assert.AreEqual(4, validLineup.LineUpList[r].Count, "The player list in the LineUpList did not get the expected count.");
                        break;
                    case 2:
                        Assert.AreEqual(4, validLineup.LineUpList[r].Count, "The player list in the LineUpList did not get the expected count.");
                        break;
                    case 3:
                        Assert.AreEqual(2, validLineup.LineUpList[r].Count, "The player list in the LineUpList did not get the expected count.");
                        break;
                }
            }

            if (File.Exists(validTeam.TeamFilePath))
            {
                File.Delete(validTeam.TeamFilePath);
            }
        }

        [TestMethod]
        public void TestCreateInvalidLineUp()
        {
            Team validTeam = new Team($"test_{Guid.NewGuid}");
            validTeam.PlayerList = validListOfPlayer;
            validTeam.AddPlayerListToFile();

            LineUp validLineup = new LineUp("4-4-2", validTeam);

            /*
                { null }
                { null null null null }
                { null null null null }
                { null null }
            */

            Assert.AreEqual(4, validLineup.LineUpList.Count, "The lineUpList did not get the expected count.");
            for (int r = 0; r < validLineup.LineUpList.Count; r++)
            {
                switch (r)
                {
                    case 0:
                        Assert.AreEqual(1, validLineup.LineUpList[r].Count, "The player list in the LineUpList did not get the expected count.");
                        break;
                    case 1:
                        Assert.AreEqual(4, validLineup.LineUpList[r].Count, "The player list in the LineUpList did not get the expected count.");
                        break;
                    case 2:
                        Assert.AreEqual(4, validLineup.LineUpList[r].Count, "The player list in the LineUpList did not get the expected count.");
                        break;
                    case 3:
                        Assert.AreEqual(2, validLineup.LineUpList[r].Count, "The player list in the LineUpList did not get the expected count.");
                        break;
                }
            }

            if (File.Exists(validTeam.TeamFilePath))
            {
                File.Delete(validTeam.TeamFilePath);
            }
        }
    }
}
