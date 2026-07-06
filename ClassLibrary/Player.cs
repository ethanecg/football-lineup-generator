using System.ComponentModel.Design;
using System.Linq.Expressions;
using ClassLibrary;

namespace ClassLibrary
{
    public class Player
    {
        private string _firstName;
        private string _lastName;
        private List<string> _fieldPositions;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                // can be empty.
                value.ToLower().Replace(" ", "");
                _firstName = value;
            }
        }

        /// <exception cref="ArgumentNullException">Thrown if the last name of the player is empty or null.</exception>
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value == null || value.ToLower().Replace(" ", "") == "")
                {
                    throw new ArgumentNullException(nameof(LastName), " of the player cannot be empty or null.");
                }
                _lastName = value;
            }
        }

        /// <summary>Check if the field positions are allowed and make sure the player have at least 1.</summary>
        /// <exception cref="ArgumentNullException">Thrown if the list of field positions is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown if a field position is not allowed.</exception>
        public List<string> FieldPositions
        {
            get { return _fieldPositions; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException(nameof(FieldPositions), " cannot be empty or null.");
                }
                foreach (string fp in value) // Check if the fp match a value in validFieldPositions.
                {
                    bool valid = false;
                    foreach (string vfp in AllowedFieldPositions.ALLOWED_FIELD_POSITIONS)
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

        /// <param name="playerCsv">The fullname and the position of a player in a csv format.</param>
        /// <exception cref="ArgumentNullException">Thrown if the fullname is null or empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the last name of the player is empty or null.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the list of field positions is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown if a field position is not allowed.</exception>
        public Player(string playerCsv)
        {
            string[] player = playerCsv.Split(';');
            string fullName = player[0];
            string fieldPositions = player[1];

            // Name
            if (fullName == null || fullName.Replace(" ", "") == "")
            {
                throw new ArgumentNullException(nameof(fullName), "The full name cannot be null or empty.");
            }

            fullName.Trim();
            string[] nameArray = fullName.Split(" "); //  The first name and last name are expected to be separated by a space.

            if (nameArray.Count() == 1) // Only last name like Vitinha
            {
                LastName = nameArray[0];
            }
            else
            {
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
                        lastName += $"{nameArray[i]} ";
                    }
                }
                LastName = lastName;
            }

            // Field position
            FieldPositions = fieldPositions.Split(',').ToList();
        }

        /// <summary>Transform the player into a text so it can be store in a csv file.</summary>
        public string ToCsvFormat()
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
