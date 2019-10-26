using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MemberList
{
    class Member
    {
        // PUBLIC properties of Member Class

        public string FirstName         // First name of the member
        {
            get
            {
                return firstName;
            }
        }
        public string LastName         // Last Name of the member
        {
            get
            {
                return lastName;
            }
        }
        public string MemberType       // The type of the member Faculty or Student
        {
            get
            {
                return memberType;
            }
        }
        public string Department       // The type of the member Faculty or Student
        {
            get
            {
                return department;
            }
        }

        public string Email            // The email of a member
        {
            get
            {
                return email;
            }
        }

        // PRIVATE SHADOW properties

        private string firstName;
        private string lastName;
        private string memberType;
        private string department;
        private string email;

        // CONSTRUCTORS

        public Member(string fName, string lName, string mType, string dptmnt, string em)
        {
            if (!validateMemberName(fName))
                throw new ArgumentException("Incorrect first name Entry");

            if (!validateMemberName(lName))
                throw new ArgumentException("Incorrect last name Entry");

            if (!validateMemberType(mType))
                throw new ArgumentException("Member type can only be Faculty or Student");

            /*if (!validateEmail(email))
                throw new ArgumentException("Member type can only be Faculty or Student");*/

            firstName   = fName;
            lastName    = lName;
            memberType  = mType;
            department  = dptmnt;
            email       = em;
        }

        public Member(string fromFile)
        {
            char[] delimiters = { '|', ',' };

            string[] tokens = fromFile.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            firstName   = tokens[0];
            lastName    = tokens[1];
            memberType  = tokens[2];
            department  = tokens[3];
            email       = tokens[4];
        }


        public virtual string ToFileString()
        {
            string theString = "";

            theString += $"{firstName}|";
            theString += $"{lastName}|";
            theString += $"{memberType}|";
            theString += $"{department}|";
            theString += $"{email}";

            return theString;
        }

        public virtual string ToFormattedString()
        {
            string theString = "";

            theString += $"{firstName,-15}";
            theString += $"{lastName,-15}";
            theString += $"{memberType,10}";
            theString += $"{department,10}";
            theString += $"{email,15}";

            return theString;

        }

        public virtual string ToDisplayString()
        {
            string theString = "";

            theString += $"{firstName,-15}";
            theString += $"{lastName,-15}";
            theString += $"{memberType,-10}";
            theString += $"{department,-10}";

            return theString;

        }


        public override string ToString()
        {
            return $"First Name: '{FirstName}' Last Name:{LastName} Type:{MemberType} Department: {Department} Email: {Email}";
        }

        // Private Validation Methods

        private bool validateMemberName( string name) // Checks whether a name (firs or last) is null or an empty string
        {
            if(!((name != null) && (name.Length > 0)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validateMemberType(string type) // Checks whether the type is Faculty or Student 
        {
            if(!(type == "Faculty" | type == "Student"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validateEmail(string email) // Pulled from https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

        }
    }
}
