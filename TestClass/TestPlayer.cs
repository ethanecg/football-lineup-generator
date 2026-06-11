using ClassLibrary;

namespace TestClass
{
    [TestClass]
    public sealed class TestPlayer
    {
        string validName = "Cristiano Ronaldo";
        List<string> validPositions = new List<string>(){ "ST", "MC" };

        [TestMethod]
        public void TestCreateValidPlayer()
        {
            Player player = new Player(validName, validPositions);
            List<string> listofFailures = new List<string>();

            if (!player.FieldPositions.Contains("ST"))
            {
                listofFailures.Add("Missing 'ST' from FieldPositions.");
            }
            if (!player.FieldPositions.Contains("MC"))
            {
                listofFailures.Add("Missing 'MC' from FieldPositions.");
            }

            if (player.FirstName != "Cristiano")
            {
                listofFailures.Add($"Expected FirstName 'Cristiano', but got '{player.FirstName}'.");
            }
            if (player.LastName != "Ronaldo")
            {
                listofFailures.Add($"Expected LastName 'Ronaldo', but got '{player.LastName}'.");
            }

            if (listofFailures.Count != 0)
            {
                Assert.Fail("TestCreateValidPlayer failed with the following errors:\n" + string.Join("\n", listofFailures));
            }
        }

        [TestMethod]
        public void TestCreatePlayerWithNullName()
        {
            Assert.Throws<ArgumentNullException>( () => new Player(null, validPositions));
        }

        [TestMethod]
        public void TestCreatePlayerWithEmptyName()
        {
            Assert.Throws<ArgumentNullException>(() => new Player(" ", validPositions));
        }

        [TestMethod]
        public void TestCreatePlayerWithTwoLastName()
        {
            Player player = new Player("Trent Alexander Arnold", validPositions);

            Assert.AreEqual("Alexander Arnold", player.LastName);
        }

        [TestMethod]
        public void TestCreatePlayerWithEmptyFieldPositions()
        {
            Assert.Throws<ArgumentNullException>(() => new Player(validName, new List<string>()));
        }

        [TestMethod]
        public void TestCreatePlayerWithNullFieldPositions()
        {
            Assert.Throws<ArgumentNullException>(() => new Player(validName, null));
        }
        [TestMethod]
        public void TestCreatePlayerWithInvalidFieldPositions()
        {
            Assert.Throws<ArgumentException>(() => new Player(validName, new List<string>() { "ST", "INV"}));
        }

        [TestMethod]
        public void TestMethodPlayerInCsvFormat()
        {
            Player player = new Player(validName, validPositions);

            Assert.AreEqual($"{validName};ST,MC", player.PlayerInCsvFormat());
        }

    }
}
