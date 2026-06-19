using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClassLibrary
{
    public static class AllowedFieldPositions
    {
        public static readonly ReadOnlyCollection<string> ALLOWED_FIELD_POSITIONS = new ReadOnlyCollection<string>(new List<string>
        {
            "ST","LW","RW",
            "AM",
            "ML","MC","MR",
            "DM",
            "DL","DC","DR",
            "G"
        });
    }
}
