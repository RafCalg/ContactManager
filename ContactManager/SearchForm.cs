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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        public int SearchMode = 0; // This one will allow us to determine whether we are in Edit or Add mode
        public string FirstName;
        public string LastName;

        private bool haveValidFirstName = false;
        private bool haveValidLastName = false;


        private void SearchForm_Load(object sender, EventArgs e)
        {
            switch (SearchMode)
            {
                case 0:
                    lastNameSearchFormTextBox.Visible   = false;
                    lastNameSearchFormLabel.Visible     = false;
                    break;
                case 1:
                    firstNameSearchFormTextBox.Visible  = false;
                    firstNameSearchFormLabel.Visible    = false;
                    break;
                case 2:
                    break;
            }
        }


        private void searchSearchFormButton_Click(object sender, EventArgs e)
        {
            string badFieldName = null;
            string adviceString = null;

            
            if (!haveValidFirstName && SearchMode == 0)
            {
                badFieldName = "First Name";
                adviceString = "Must enter the First Name of Faculty Member";
            }

            if (!haveValidFirstName && SearchMode == 2)
            {
                badFieldName = "First Name";
                adviceString = "Must enter the First Name of Faculty Member";
            }

            if (!haveValidLastName && SearchMode == 1)
            {
                badFieldName = "Last Name";
                adviceString = "Must enter the Last Name of Faculty Member";
            }

            if (!haveValidLastName && SearchMode == 2)
            {
                badFieldName = "Last Name";
                adviceString = "Must enter the Last Name of Faculty Member";
            }



            if (badFieldName != null)
            {
                MessageBox.Show($"Invalid {badFieldName}.\n{adviceString}", "Data Entry Error");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void firstNameSearchFormTextBox_TextChanged(object sender, EventArgs e)
        {
            if (firstNameSearchFormTextBox.Text.Trim().Length == 0)
            {
                haveValidFirstName = false;
            }
            else
            {
                haveValidFirstName = true;
                FirstName = firstNameSearchFormTextBox.Text.Trim();
            }
        }
        private void lastNameSearchFormTextBox_TextChanged(object sender, EventArgs e)
        {
            if (lastNameSearchFormTextBox.Text.Trim().Length == 0)
            {
                haveValidLastName = false;
            }
            else
            {
                haveValidLastName = true;
                LastName = lastNameSearchFormTextBox.Text.Trim();
            }
        }
        private void cancelSearchFormButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


    }
}
