using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        public bool EditMode = false; // This one will allow us to determine whether we are in Edit or Add mode
        public string FirstName;
        public string LastName;
        public string MemberType;
        public string Department;
        public string Email;
        public string Address;
        public int Graduation;
        public List<string> Courses;

        private bool haveValidFirstName     = false;
        private bool haveValidLastName      = false;
        private bool haveValidType          = false;
        private bool haveValidDepartment    = false;
        private bool haveValidEmail         = false;
        private bool haveValidAddress       = false;
        private bool haveValidGraduation    = false;
        private bool haveValidCourses       = false;

        private void StudentForm_Load(object sender, EventArgs e)
        {
            if (EditMode)
            {
                firstNameStudentFormTextBox.Text = FirstName;
                lastNameStudentFormTextBox.Text = LastName;
                typeStudentFormTextBox.Text = MemberType;
                departmentStudentFormTextBox.Text = Department;
                emailStudentFormTextBox.Text = Email;
                AddressStudentFormTextBox.Text = Address;
                graduationStudentFormTextBox.Text = Graduation.ToString();
                coursesStudentFormTextBox.Text = ToTextBoxString(Courses);
                addStudentFormButton.Text = "Update";
                this.Text = "Update Student Member";
            }
        }

        public string ToTextBoxString(List <string> Courses)
        {
            string str = "";


            foreach (string crs in Courses)
            {
                str += crs + "|";
            }

            str.Remove(str.Length - 1, 1);
            return str;
        }
        private void addStudentFormButton_Click(object sender, EventArgs e)
        {
            string badFieldName = null;
            string adviceString = null;

            if (!haveValidFirstName)
            {
                badFieldName = "First Name";
                adviceString = "Must enter the First Name of Student Member";
            }
            else if (!haveValidLastName)
            {
                badFieldName = "Last Name";
                adviceString = "Must enter the Last Name of Student Member";
            }
            else if (!haveValidType)
            {
                badFieldName = "Member Type";
                adviceString = "Must enter Student type for a Student Member";
            }
            else if (!haveValidDepartment)
            {
                badFieldName = "Department";
                adviceString = "Must enter a valid Department for a Student Member";
            }
            else if (!haveValidEmail)
            {
                badFieldName = "E-mail";
                adviceString = "Must enter E-mail for a Student Member";
            }
            else if (!haveValidAddress)
            {
                badFieldName = "Address";
                adviceString = "Must have a valid Address";
            }
            else if (!haveValidCourses)
            {
                badFieldName = "Courses";
                adviceString = "Must have valid Courses";
            }

            if (badFieldName != null)
            {
                MessageBox.Show($"Invalid {badFieldName}.\n{adviceString}", "Data Entry Error");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void firstNameStudentFormTextBox_TextChanged_1(object sender, EventArgs e)
        {
            if (firstNameStudentFormTextBox.Text.Trim().Length == 0)
            {
                haveValidFirstName = false;
            }
            else
            {
                haveValidFirstName = true;
                FirstName = firstNameStudentFormTextBox.Text.Trim();
            }
        }

        private void lastNameStudentFormTextBox_TextChanged_1(object sender, EventArgs e)
        {
            if (lastNameStudentFormTextBox.Text.Trim().Length == 0)
            {
                haveValidLastName = false;
            }
            else
            {
                haveValidLastName = true;
                LastName = lastNameStudentFormTextBox.Text.Trim();
            }
        }

        private void typeStudentFormTextBox_TextChanged_1(object sender, EventArgs e)
        {
            if (typeStudentFormTextBox.Text.Trim().Length == 0)
            {
                haveValidType = false;
            }
            else
            {
                haveValidType = true;
                MemberType = typeStudentFormTextBox.Text.Trim();
            }
        }

        private void departmentStudentFormTextBox_TextChanged_1(object sender, EventArgs e)
        {
            if (departmentStudentFormTextBox.Text.Trim().Length == 0)
            {
                haveValidDepartment = false;
            }
            else
            {
                haveValidDepartment = true;
                Department = departmentStudentFormTextBox.Text.Trim();
            }
        }

        private void emailStudentFormTextBox_TextChanged_1(object sender, EventArgs e)
        {
            if (emailStudentFormTextBox.Text.Trim().Length == 0)
            {
                haveValidEmail = false;
            }
            else
            {
                haveValidEmail = true;
                Email = emailStudentFormTextBox.Text.Trim();
            }
        }

        private void AddressStudentFormTextBox_TextChanged_1(object sender, EventArgs e)
        {
            if (AddressStudentFormTextBox.Text.Trim().Length == 0)
            {
                haveValidAddress = false;
            }
            else
            {
                haveValidAddress = true;
                Address = AddressStudentFormTextBox.Text.Trim();
            }
        }


        private void graduationStudentFormTextBox_TextChanged(object sender, EventArgs e)
        {
            if (graduationStudentFormTextBox.Text.Trim().Length == 0)
            {
                haveValidGraduation = false;
            }
            else
            {
                haveValidGraduation = true;
                Graduation = int.Parse(graduationStudentFormTextBox.Text.Trim());
            }
        }

        private void coursesStudentFormTextBox_TextChanged(object sender, EventArgs e)
        {
            if (coursesStudentFormTextBox.Text.Trim().Length == 0)
            {
                haveValidCourses = false;
            }
            else
            {
                haveValidCourses = true;

                char[] delimiters = { '|', ',' };

                string[] tokens = coursesStudentFormTextBox.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                int i = 0;
                 Courses = new List<string>();

                while (i < tokens.Length)
                {
                    Courses.Add(tokens[i]);
                    i++;
                }
            }
        }

        private void cancelStudentFormButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


    }
}
