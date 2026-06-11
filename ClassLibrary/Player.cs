namespace ClassLibrary
{
    public class Player
    {
        private string _firstName;
        private string _lastName;
        private List<string> _fieldPositions;

        private List<string> validFieldPositions = new List<string>() // This list is never modified
        {
            "ST","LW","RW","AM",
            "MC","MR","ML","MD",
            "DM","DL","DC","DR",
            "G"
        };

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value == null || value.ToLower().Replace(" ", "") == "")
                {
                    throw new ArgumentNullException("The name of the player cannot be empty or null.");
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value == null || value.ToLower().Replace(" ", "") == "")
                {
                    throw new ArgumentNullException("The name of the player cannot be empty or null.");
                }
                _lastName = value;
            }
        }

        /// <summary>
        /// List of field positions. The valid positions are in validFieldPositions.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the field position dont match a value in validFieldPositions</exception>
        public List<string> FieldPositions
        {
            get { return _fieldPositions; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException("The name of the player cannot be empty or null.");
                }
                foreach (string fp in value) // Check if the fp match a value in validFieldPositions.
                {
                    bool valid = false;
                    foreach (string vfp in validFieldPositions)
                    {
                        if (fp == vfp)
                        {
                            valid = true;
                        }
                    }
                    if (valid == false)
                    {
                        throw new ArgumentException("The field position is not valid.");
                    }
                }
                _fieldPositions = value;
            }
        }

        public Player(string fullName, List<string> fieldPositionList)
        {
            string[] nameArray = fullName.Split(" ");
            FirstName = nameArray[0];
            LastName = nameArray[1];

            FieldPositions = fieldPositionList;
        }

        /// <summary>
        /// Transform the player so it can be in written in the .csv file.
        /// </summary>
        /// <returns></returns>
        public string playerInCsvFormat()
        {
            int count = 0;

            string playerCsvFormat = ($"{FirstName} {LastName};");
            foreach (string field in FieldPositions)
            {
                count++;
                if (count == FieldPositions.Count)
                {
                    playerCsvFormat += $"{field}";
                }
                else
                {
                    playerCsvFormat += $"{field},";
                }
            }
            return playerCsvFormat;
        }
    }
}
