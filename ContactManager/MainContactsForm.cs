using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MemberList;


namespace ContactManager
{
    public partial class MainContactsForm : Form
    {
        List<Member> memberList = new List<Member>(); //List of Faculty and Students members

        string openFileName; //Used to store the opened file name and to use the same filename to save the file

        public MainContactsForm()
        {
            InitializeComponent();
        }

        //checks if any modification in the listbox has been saved. Here just after loading the value is set to true 
        private bool listIsSaved =true;

        // Responds to Open menu item in the Main Form - Selects a file to open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // let the user pick the file to open


            contactsListBox.Items.Clear();
            OpenFileDialog ofd = new OpenFileDialog(); //Open file dialog box 

            ofd.Title = "Select a Contact List";

            ofd.Filter = "Contact List Files|*.pil|Text Files|*.txt|All Files|*.*";
            ofd.FilterIndex = 1;

            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Desktop selected as the initial file directory

            DialogResult result = ofd.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            // all inside a try/catch
            //
            // open a stream reader on 'productlist.txt' on the desktop
            // for each line in the file call the constructor that takes single string
            // and get a product object back. Add that object to my list and to the display list
            // close the file

            Member m = null;
            try
            {
                StreamReader input = new StreamReader(ofd.FileName);

                while (!input.EndOfStream)
                {
                    string memberType = input.ReadLine();
                    switch (memberType)
                    {
                        case "Faculty":
                            m = new Faculty(input.ReadLine());
                            break;
                        case "Student":
                            m = new Student(input.ReadLine());
                            break;
                        default:
                            MessageBox.Show("Unknown member in the file");
                            m = null;
                            break;
                    }

                    if (m != null)
                    {
                        memberList.Add(m);
                        contactsListBox.Items.Add(m.ToDisplayString());
                    }
                }
                openFileName = ofd.FileName; //Stores the filename in a variable that can be used to directly save the file
                input.Close();
            }
            catch (Exception excp)
            {
                MessageBox.Show($"File did not load. {excp.Message}");
                return;
            }
        }

        //To save the current list 
        private void saveContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(openFileName == null) //Checks whether there is anything to save - First a file needs to have been loaded before one can save it 
            {
                MessageBox.Show("No Contact List has been loaded yet");
                return;
            }

            saveList(openFileName);
            listIsSaved = true;

        }


        //Option to save the current list under a different file name
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "Select File to Save Contact List";

            sfd.Filter = "Contact List Files|*.pil|Text Files|*.txt|All Files|*.*";
            sfd.FilterIndex = 1;

            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            DialogResult result = sfd.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            saveList(sfd.FileName);

            listIsSaved = true;

            MessageBox.Show($"Products have been saved in {sfd.FileName}");
        }
        //Type of member 
        private string productTypeString(Member m)
        {
            if (m is Faculty)
                return "Faculty";
            else if (m is Student)
                return "Student";
            else
                return "UNKNOWN";
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }


        private void saveList(string fileName)
        {
            try
            {
                StreamWriter output = new StreamWriter(fileName);
                foreach (Member m in memberList)
                {
                    output.WriteLine(productTypeString(m));
                    output.WriteLine(m.ToFileString());
                }
                output.Close();
                listIsSaved = true; //The list has been saved and the listIsSaved variable is set to true
            }
            catch (Exception excp)
            {
                MessageBox.Show($"File did not write. {excp.Message}");
                return;
            }
        }


        //Exit Method -Gives the option to save the file if the list has been updated

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listIsSaved == false)
            {
                string message = "The list has been updated. Do you want to save it?";
                string title = "Close Window";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    saveList(openFileName);
                }
                else
                {
                    return; 
                }
            }
            else
            {
                this.Close();
            }
        }

        private void ContactDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = contactsListBox.SelectedIndex;
            if (contactsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select an item of the list");
                return;
            }
            else
            {
                Member m = memberList[index]; //our product 
                switch (m.MemberType)
                {
                    case "Faculty":
                        ViewFacultyMember(index);
                        break;
                    case "Student":
                        ViewStudentMember(index);
                        break;
                    default:
                        MessageBox.Show("Error in member type");
                        return;
                }
            }
        }


        private void ViewFacultyMember(int index)
        {
            contactInfo continf = new contactInfo(); //Invokes the contact info form
            continf.EditMode = true;
            Faculty f = (Faculty)memberList[index];

            continf.FirstName   = f.FirstName;
            continf.LastName    = f.LastName;
            continf.MemberType  = f.MemberType;
            continf.Department  = f.Department;
            continf.Email       = f.Email;
            continf.Building    = f.Building;

            continf.ShowDialog();
        }

        private void ViewStudentMember(int index)
        {
            contactInfo continf = new contactInfo(); //Invokes the contact info form
            continf.EditMode = true;
            Student s = (Student)memberList[index];

            continf.FirstName   = s.FirstName;
            continf.LastName    = s.LastName;
            continf.MemberType  = s.MemberType;
            continf.Department  = s.Department;
            continf.Email       = s.Email;
            continf.Address     = s.Address;
            continf.Graduation  = s.Graduation;
            continf.Courses     = s.Courses;


            continf.ShowDialog();
        }

        private void AddContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacultyForm facForm = new FacultyForm();

            DialogResult result;

            result = facForm.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            Member m = new Faculty(facForm.FirstName,
                                   facForm.LastName,
                                   facForm.MemberType,
                                   facForm.Department,
                                   facForm.Email,
                                   facForm.Building);
            if (m != null)
            {
                memberList.Add(m);
                contactsListBox.Items.Add(m.ToFormattedString());

            }
            listIsSaved = false;

        }

        private void FacultyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // pop a AddComputerDialog. If return is cancel, give up
            // if return is dialog ok, try to create a computer object
            // return that reference

            FacultyForm facForm = new FacultyForm();

            DialogResult result;
            
            result = facForm.ShowDialog();
            
            if (result != DialogResult.OK)
            {
                return;
            }



            Faculty f = new Faculty(facForm.FirstName,
                                     facForm.LastName,
                                     facForm.MemberType,
                                     facForm.Department,
                                     facForm.Email,
                                     facForm.Building);

            if (f != null)
            {
                memberList.Add(f);
                contactsListBox.Items.Add(f.ToDisplayString());
            }

            listIsSaved = false;
        }

        private void contactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Method to display contact details in case by doubleclicking
        void contactsListBoxDoubleClick(object sender, MouseEventArgs e)
        {

            //MessageBox.Show(memberList[contactsListBox.SelectedIndex].ToString());
            int indice = contactsListBox.SelectedIndex;

            if (indice == -1)
            {
                MessageBox.Show("A contact must be selected");
                return;
            }
           
            string type = memberList[indice].MemberType;

            if (type == "Faculty")
            {
                ViewFacultyMember(indice);
            }
            else if (type == "Student")
            {
                ViewStudentMember(indice);
            }
            else
            {
                MessageBox.Show("A invalid type has been set");
            }
            
        }

        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit has been selected");

            //Make sure we have something selected
            int index = contactsListBox.SelectedIndex;

            
            if (index == -1)
            {
                MessageBox.Show("You need to make a selection before editing product.");
                return;
            }

            //Create the Edit dialog, have it prepopulated the contents of the field
            //and then show the dialog



            Member m = memberList[index]; //our product 

            if (m is Faculty)
            {
                EditFacultyMember(index);
            }
            else if (m is Student)
            {
                EditStudentMember(index);
            }
            else
            {
                MessageBox.Show("Unknown member tryng to be edited");
            }


            //if the user selects cancel give up. 
            //If the user selects update then change all the fields in the objects
        }

        private void EditFacultyMember(int index)
        {
            //create a dialog and configure for edit

            FacultyForm facForm = new FacultyForm();
            facForm.EditMode = true;

            Faculty f = (Faculty)memberList[index]; //We cast the Faculty class to the memberList as Faculty is a subclass of the Member class

            facForm.FirstName = f.FirstName;
            facForm.LastName = f.LastName;
            facForm.MemberType = f.MemberType;
            facForm.Department = f.Department;
            facForm.Email = f.Email;
            facForm.Building = f.Building;

            DialogResult result = facForm.ShowDialog();

            //show the dialog and wait for an OK


            //if answer was OK update the product inventory with the new values and update dispaly
            //create Computer product a new computer  with updated properties

            if (result != DialogResult.OK)
            {
                return;
            }

            Member m = new Faculty(facForm.FirstName,
                                     facForm.LastName,
                                     facForm.MemberType,
                                     facForm.Department,
                                     facForm.Email,
                                     facForm.Building);

            string message = $"Are you sure that you would like to update the { m.MemberType} item?";

            string caption = "Update Item";
            var result2 = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result2 == DialogResult.No)
            {
                // cancel the closure of the form.
                return;
            }

            memberList[index] = m; //Update the inventory
            contactsListBox.Items[index] = m.ToDisplayString(); //update the listBox display

            listIsSaved = false;
        }
        //Delete a contact from the listbox
        private void deleteContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check to see if we have something selected first .Message if not.

            int selectionIndex = contactsListBox.SelectedIndex;

            Member m = memberList[selectionIndex];

            if (selectionIndex == -1)
            {
                MessageBox.Show("You need to make a selection before deleting");
            }
            else
            {
                //MessageBox.Show()
                string message = $"Are you sure that you would like to delete the { m.MemberType} item?";

                string caption = "Delete Item";
                var result = MessageBox.Show(($"Are you sure that you would like to delete the { m.MemberType} item?"), caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    // cancel the closure of the form.
                    return;
                }

                memberList.Remove(memberList[selectionIndex]);
                contactsListBox.Items.RemoveAt(selectionIndex);
                listIsSaved = false;
            }

            //Issue confirmation dialog that item is really to be deleted.


            //so really delete the item take it out of the product inventory list and the display list.
        }

        private void MainContactsForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Right click on list box to access Contact List Options");
        }


        //Add Student is selected from the context menu
        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StudentForm studForm = new StudentForm();

            DialogResult result;

            result = studForm.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            Member m = new Student(studForm.FirstName,
                                   studForm.LastName,
                                   studForm.MemberType,
                                   studForm.Department,
                                   studForm.Email,
                                   studForm.Address,
                                   studForm.Graduation,
                                   studForm.Courses);
            if (m != null)
            {
                memberList.Add(m);
                contactsListBox.Items.Add(m.ToDisplayString());
            }

            listIsSaved = false;
        }

        //A student is selected for Edit
        private void EditStudentMember(int index)
        {
            //create a dialog and configure for edit

            StudentForm studForm = new StudentForm();
            studForm.EditMode = true;

            Student f = (Student)memberList[index]; //We cast the Faculty class to the memberList as Faculty is a subclass of the Member class

            studForm.FirstName = f.FirstName;
            studForm.LastName = f.LastName;
            studForm.MemberType = f.MemberType;
            studForm.Department = f.Department;
            studForm.Email = f.Email;
            studForm.Address = f.Address;
            studForm.Graduation = f.Graduation;
            studForm.Courses = f.Courses;

            DialogResult result = studForm.ShowDialog();

            //show the dialog and wait for an OK


            //if answer was OK update the product inventory with the new values and update dispaly
            //create Computer product a new computer  with updated properties

            if (result != DialogResult.OK)
            {
                return;
            }

            Member m = new Student(studForm.FirstName,
                                     studForm.LastName,
                                     studForm.MemberType,
                                     studForm.Department,
                                     studForm.Email,
                                     studForm.Address,
                                     studForm.Graduation,
                                     studForm.Courses);

            string message = $"Are you sure that you would like to update the { m.MemberType} item?";

            string caption = "Update Item";
            var result2 = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result2 == DialogResult.No)
            {
                // cancel the closure of the form.
                return;
            }

            memberList[index] = m; //Update the inventory
            contactsListBox.Items[index] = m.ToDisplayString(); //update the listBox display

            listIsSaved = false;
        }
        //Search of the contacts listbox by first name
        private void firstNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm shForm = new SearchForm();

            shForm.SearchMode = 0;

            DialogResult result;

            result = shForm.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            string fName = shForm.FirstName.ToLower();

            int index = 0;
            List<int> listIndex = new List<int>();
            contactsListBox.SelectedItems.Clear(); // Remove any previously selected item.

            foreach( Member m in memberList)
            {
                if (m.FirstName.ToLower() == fName)
                {
                    listIndex.Add(index);
                    contactsListBox.SetSelected(index, true);
                }

                index++;

                if((index >= memberList.Count) && (listIndex.Count == 0))
                {
                    MessageBox.Show("No Student or Faculty Member has such a first name");
                }
            } 

           
        }
        

        //About form
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm abForm = new AboutForm();

            DialogResult result;

            result = abForm.ShowDialog();


            if (result != DialogResult.OK)
            {
                return;
            }


        }

        //search by last name
        private void lastNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm shForm = new SearchForm();

            DialogResult result;

            shForm.SearchMode = 1;

            result = shForm.ShowDialog();

            

            if (result != DialogResult.OK)
            {
                return;
            }

            string lName = shForm.LastName.ToLower();

            int index = 0;
            List<int> listIndex = new List<int>();
            contactsListBox.SelectedItems.Clear(); // Remove any previously selected item.

            foreach (Member m in memberList)
            {
                if (m.LastName.ToLower() == lName)
                {
                    listIndex.Add(index);
                    contactsListBox.SetSelected(index, true);
                }

                index++;

                if ((index >= memberList.Count) && (listIndex.Count == 0))
                {
                    MessageBox.Show("No Student or Faculty Member has such a first name");
                }
            }
        }


        //Search by first and last name
        private void firstAndLastNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm shForm = new SearchForm();

            DialogResult result;

            shForm.SearchMode = 2;

            result = shForm.ShowDialog();



            if (result != DialogResult.OK)
            {
                return;
            }

            string fName = shForm.FirstName.ToLower();
            string lName = shForm.LastName.ToLower();

            int index = 0;
            List<int> listIndex = new List<int>();
            contactsListBox.SelectedItems.Clear(); // Remove any previously selected item.

            foreach (Member m in memberList)
            {
                if ((m.FirstName.ToLower() == fName.ToLower()) && (m.LastName.ToLower() == lName.ToLower()))
                {
                    listIndex.Add(index);
                    contactsListBox.SetSelected(index, true);
                }

                index++;

                if ((index >= memberList.Count) && (listIndex.Count == 0))
                {
                    MessageBox.Show("No Student or Faculty Member has such a first name");
                }
            }
        }
    }   
}
