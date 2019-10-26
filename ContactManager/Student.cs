using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberList
{
    class Student : Member
    {
        // Public properties

        public string Address
        {
            get
            {
                return address;
            }
        }
        public int Graduation
        {
            get
            {
                return graduation;
            }
        }

        public List<string> Courses
        {
            get
            {
                return courses;
            }

        }
        // private properties

        private string address;
        private int graduation;
        private List<string> courses;

        public Student(string fname,
                       string lname,
                       string type,
                       string department,
                       string email,
                       string adrs,
                       int grad,
                       List<string> _courses) : base(fname, lname, type, department, email)
        {
            if (!validateAddress(adrs))
            {
                throw new ArgumentException("Address entry is invalid");
            }
            address = adrs;

            if (!validateGraduation(grad))
            {
                throw new ArgumentException("Graduation year is invalid");
            }
            graduation = grad;

            courses = _courses;

        }


        public Student(string fromFile ) : base(fromFile) // Continues reading from file for Student class
        {
            char[] delimiters = { '|', ',' };

            string[] tokens = fromFile.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            address = tokens[5];
            graduation = int.Parse(tokens[6]);

            int i = 7;

            courses = new List<string>();

            if (tokens.Length > 7)
            {
                while (i < tokens.Length)
                {
                    courses.Add(tokens[i]);
                    i++;
                }
            }
        }

        public override string ToFileString()
        {
            string str = "";

            foreach (string crs in Courses)
            {
                str += "|" + crs;
            }
            return base.ToFileString() + $"|{address}|{graduation} {str}";
        }


        public override string ToString() // Continues the ToString Method for Student class
        {
            string str = "";

            foreach (string crs in Courses)
            {
                str += crs;
            }

            return base.ToString() + $" Adress:{address} Graduation:{graduation} Course:{str}";
        }


        
        public override string ToFormattedString() // Continues the ToFormattedString for the Student class
        {
            return base.ToFormattedString() + $" {address,20} Graduation:{graduation,6}" ;
        }


        public string ToTextBoxString()
        {
            string str = "";
            

            foreach (string crs in Courses)
            {
                str += crs +"|";
            }

            str.Remove(str.Length - 1, 1);
            return str;
        }


        private bool validateAddress(string adrs) //Checks that the building is a non null and non empty string
        {
            if (!((adrs != null) && (adrs.Length > 0)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validateGraduation(int gradYear) //Checks that the building is a non null and non empty string
        {
            int currentYear = DateTime.Now.Year; //Brings in the current year as an integer
            
            if (!(gradYear >= currentYear) ) //Checks whether the graduation year is not in the past
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
