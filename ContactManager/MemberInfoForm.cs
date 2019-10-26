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
    public partial class contactInfo : Form
    {
        public contactInfo()
        {
            InitializeComponent();
        }
        public bool EditMode = false; // This one will allow us to determine whether 
        public string FirstName;
        public string LastName;
        public string MemberType;
        public string Department;
        public string Email;
        public string Building;
        public string Address;
        public int Graduation;
        public List<string> Courses; 

        private void contactInfo_Load(object sender, EventArgs e)
        {

            if (EditMode)
            {
                firstNameContactInfoTextBox.Text = FirstName;
                lastNameContactInfoTextBox.Text = LastName;
                typeContactInfoTextBox.Text = MemberType;
                departmentContactInfoTextBox.Text = Department;
                emailContactInfoTextBox.Text = Email;
                if (MemberType == "Faculty") 
                {
                    buildingContactInfoTextBox.Text = Building;
                    //Make Student specific labels and textboxes invisible
                    addressContactInfoLabel.Visible = false;
                    addressContactInfoTextBox.Visible = false;
                    graduationCompactInfoLabel.Visible = false;
                    graduationCompactInfoTextBox.Visible = false;
                    coursesContactInfoLabel.Visible = false;
                    coursesListBox.Visible = false;
                    
                }
                else if(MemberType == "Student")
                {
                    addressContactInfoTextBox.Text = Address;
                    graduationCompactInfoTextBox.Text = Graduation.ToString();
                    buildingContactInfoLabel.Visible = false;
                    buildingContactInfoTextBox.Visible = false;
                    
                    foreach (string crs in Courses)
                    {
                        coursesListBox.Items.Add(crs);
                    }
                }
            }
        }
    }
}
