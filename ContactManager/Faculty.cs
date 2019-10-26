using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberList
{
    class Faculty : Member
    {
        // Public properties

        public string Building
        {
            get
            {
                return building;
            }
        }

        // private properties

        private string building;

        public Faculty(string fname,
                       string lname,
                       string type,
                       string department,
                       string email,
                       string bldng) : base(fname, lname, type, department,email)
        {
            if (!validateBuilding(bldng))
            {
                throw new ArgumentException("Building Entry is invalid");
            }

            building = bldng;
        }

        
        public Faculty(string fromFile) : base(fromFile) // Continues reading from file for Faculty class
        {
            char[] delimiters = { '|', ',' };

            string[] tokens = fromFile.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            building = tokens[5];
        }

        public override string ToFileString()
        {
            return base.ToFileString() + $"|{building}";
        }

        public override string ToString() // Continues the ToString Method for faculty class
        {
            return base.ToString() + $" Building:{building}";
        }

        public override string ToFormattedString() // Continues the ToFormattedString for the Faculty class
        {
            return base.ToFormattedString() + $" {building,20}";
        }


        private bool validateBuilding(string bldng) //Checks that the building is a non null and non empty string
        {
            if (!((bldng != null) && (bldng.Length > 0)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
