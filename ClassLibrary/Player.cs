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

        public List<string> FieldPositions
        {
            get { return _fieldPositions; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException("The name of the player cannot be empty or null.");
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
    }
}
