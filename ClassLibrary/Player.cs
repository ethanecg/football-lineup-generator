using System.ComponentModel.Design;
using System.Linq.Expressions;

namespace ClassLibrary
{
    public class Player
    {
        public static readonly List<string> VALID_FIELD_POSITIONS = new List<string>() // This list cannot be modified
        {
            "ST","LW","RW",
            "AM",
            "MC","MR","ML","MD", 
            "DM",
            "DL","DC","DR",
            "G"
        };

        private string _firstName;
        private string _lastName;
        private List<string> _fieldPositions;


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
        /// <exception cref="ArgumentNullException">Thrown if the list is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown if the field position dont match a value in validFieldPositions.</exception>
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
                    foreach (string vfp in VALID_FIELD_POSITIONS)
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

        /// <param name="fullName">The first name and last name of a player separaated by a space.</param>
        /// <param name="fieldPositionList"></param>
        /// <exception cref="ArgumentNullException">Thrown if the full name is null.</exception>
        public Player(string fullName, List<string> fieldPositionList)
        {
            if (fullName == null)
            {
                throw new ArgumentNullException("The full name cannot be null");
            }
            string[] nameArray = fullName.Split(" ");
            FirstName = nameArray[0];
            string lastName = "";
            // In case the player have two last name.
            for (int i = 1; i < nameArray.Count(); i++)
            {
                if (i == nameArray.Count() - 1)
                {
                    lastName += $"{nameArray[i]}";
                }
                else
                {
                    lastName += $"{nameArray[i] } ";
                }
            }
            LastName = lastName;

            FieldPositions = fieldPositionList;
        }

        /// <summary>
        /// Transform the player so it can be in written in the .csv file.
        /// </summary>
        /// <returns></returns>
        public string PlayerInCsvFormat()
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
