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
    public partial class FacultyForm : Form
    {
        public FacultyForm()
        {
            InitializeComponent();
        }
        public bool EditMode = false; // This one will allow us to determine whether we are in Edit or Add mode
        public string FirstName;
        public string LastName;
        public string MemberType;
        public string Department;
        public string Email;
        public string Building;

        private bool haveValidFirstName     = false;
        private bool haveValidLastName      = false;
        private bool haveValidType          = false;
        private bool haveValidDepartment    = false;
        private bool haveValidEmail         = false;
        private bool haveValidBuilding      = false;
     

        private void FacultyForm_Load(object sender, EventArgs e)
        {
            if (EditMode)
            {
                FirstNameFacultyFormTextBox.Text = FirstName;
                LastNameFacultyFormTextBox.Text = LastName;
                typeFacultyFormTextBox.Text = MemberType;
                departmentFacultyFormTextBox.Text = Department;
                emailFacultyFormTextBox.Text = Email;
                buildingFacultyFormTextBox.Text = Building;
            }
        }

        private void FacultyForm_Load_1(object sender, EventArgs e)
        {
            if (EditMode)
            {
                FirstNameFacultyFormTextBox.Text = FirstName;
                LastNameFacultyFormTextBox.Text = LastName;
                typeFacultyFormTextBox.Text = MemberType;
                departmentFacultyFormTextBox.Text = Department;
                emailFacultyFormTextBox.Text = Email;
                buildingFacultyFormTextBox.Text = Building;

                addFacultyFormButton.Text = "Update";
                this.Text = "Update Faculty Member";
            }
        }

        private void CancelFacultyFormButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddFacultyFormButton_Click(object sender, EventArgs e)
        {
            string badFieldName = null;
            string adviceString = null;

            if (!haveValidFirstName)
            {
                badFieldName = "First Name";
                adviceString = "Must enter the First Name of Faculty Member";
            }
            else if (!haveValidLastName)
            {
                badFieldName = "Last Name";
                adviceString = "Must enter the Last Name of Faculty Member";
            }
            else if (!haveValidType)
            {
                badFieldName = "Member Type";
                adviceString = "Must enter Faculty type for a Faculty Member";
            }
            else if (!haveValidDepartment)
            {
                badFieldName = "Department";
                adviceString = "Must enter a valid Department for a Faculty Member";
            }
            else if (!haveValidEmail)
            {
                badFieldName = "E-mail";
                adviceString = "Must enter E-mail for a Faculty Member";
            }
            else if (!haveValidBuilding)
            {
                badFieldName = "Building";
                adviceString = "Must have a valid Building";
            }

            if (badFieldName != null)
            {
                MessageBox.Show($"Invalid {badFieldName}.\n{adviceString}", "Data Entry Error");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void FirstNameFacultyFormTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FirstNameFacultyFormTextBox.Text.Trim().Length == 0)
            {
                haveValidFirstName = false;
            }
            else
            {
                haveValidFirstName = true;
                FirstName = FirstNameFacultyFormTextBox.Text.Trim();
            }
        }

        private void LastNameFacultyFormTextBox_TextChanged(object sender, EventArgs e)
        {
            if (LastNameFacultyFormTextBox.Text.Trim().Length == 0)
            {
                haveValidLastName = false;
            }
            else
            {
                haveValidLastName = true;
                LastName = LastNameFacultyFormTextBox.Text.Trim();
            }
        }

        private void typeFacultyFormTextBox_TextChanged(object sender, EventArgs e)
        {
            if (typeFacultyFormTextBox.Text.Trim().Length == 0)
            {
                haveValidType = false;
            }
            else
            {
                haveValidType = true;
                MemberType = typeFacultyFormTextBox.Text.Trim();
            }
        }

        private void departmentFacultyFormTextBox_TextChanged(object sender, EventArgs e)
        {
            if (departmentFacultyFormTextBox.Text.Trim().Length == 0)
            {
                haveValidDepartment = false;
            }
            else
            {
                haveValidDepartment = true;
                Department = departmentFacultyFormTextBox.Text.Trim();
            }
        }

        private void emailFacultyFormTextBox_TextChanged(object sender, EventArgs e)
        {
            if (emailFacultyFormTextBox.Text.Trim().Length == 0)
            {
                haveValidEmail = false;
            }
            else
            {
                haveValidEmail = true;
                Email = emailFacultyFormTextBox.Text.Trim();
            }
        }

        private void buildingFacultyFormTextBox_TextChanged(object sender, EventArgs e)
        {
            if (buildingFacultyFormTextBox.Text.Trim().Length == 0)
            {
                haveValidBuilding = false;
            }
            else
            {
                haveValidBuilding = true;
                Building = buildingFacultyFormTextBox.Text.Trim();
            }
        }
    }
}
