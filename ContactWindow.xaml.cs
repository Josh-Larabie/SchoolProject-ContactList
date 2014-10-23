/* File: ContactWindow.xaml.cs
 * Author: Sheila Galbraith, member of Group 1
 * Date: October 21, 2014
 * Description: Code behind for the ContactWindow.xaml class
 * Additional Note: Part of the ContactList app for Project 1
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace ContactList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {

        Contact contact; 
          
        /// <summary>
        /// Constructor initializes the window's components
        /// </summary>
        public ContactWindow()
        {
            InitializeComponent();
        }


/*                              BUTTONS                                            */

       /// <summary>
       /// Event handler creates a new contact with 5 strings and adds it to the contactListBox items when the addButton is clicked.
       /// Throws a FormatException if the information in the textboxes aren't usable.
       /// Clears the textboxes so they can be reused.
       /// </summary>
       /// <param name="sender">Created by VS when the handler is created</param>
       /// <param name="e">Created by VS when the handler was created</param>
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            /* strings to hold the contact's pieces of information*/
            String firstName = "";
            String lastName = "";
            String phoneNumber = "";
            String email = "";
            String note = "";
            String contactDate = "";

            try
            {
                /* puts the values in the textboxes into the string variables */
                firstName = firstNameTextBox.Text;
                lastName = lastNameTextBox.Text;
                phoneNumber = phoneTextBox.Text;
                email = emailTextBox.Text;
                note = notesTextBox.Text;
                contactDate = DateTime.Now.ToString("MMMM dd, yyyy"); // date time item for the date created info in a string format so its easier to work with
                contact = new Contact(firstName, lastName, phoneNumber, email, note, contactDate); //new Contact
                contactListBox.Items.Add(contact); //contact added to the contactListBox items
            }
            catch(FormatException)
            {
                MessageBox.Show("Please enter a valid contact","Problem",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            /* clear the textboxes */
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            phoneTextBox.Clear();
            emailTextBox.Clear();
            notesTextBox.Clear();
        }

        
        /// <summary>
        /// Event handler to remove a contact from the contactListBox items when the deleteButton is clicked.
        /// If there isn't anything to remove or the user doesn't select anything a message box pops up warning them of this.
        /// </summary>
        /// <param name="sender">Created by VS when the event handler was made</param>
        /// <param name="e">Created by VS when the event handler was made</param>
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            /*make sure the selected item isn't a null value */
            if (contactListBox.SelectedItem != null)
            {
                /* remove the item from items */
                contactListBox.Items.Remove(contactListBox.SelectedItem);
            }
            else
            {
                String errorMessage;
                /*MessageBox pops up if there isn't anything to remove from the list or if the user hasn't selected anything to remove */
                if (contactListBox.Items.Count == 0)
                {
                    errorMessage = "Nothing to remove";
                }
                else
                {
                    errorMessage = "Please select an item to remove";
                }
                MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        /// <summary>
        /// Event handler that updates the textboxes with the information for the contact when the item in the listbox is selected by the user.
        /// Throws an exception if the contact can't be opened.
        /// </summary>
        /// <param name="sender">Created by VS when the event handler was made</param>
        /// <param name="e">Created by VS when the event handler was made</param>
        private void contactListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (contactListBox.SelectedItem != null)
                {
                    Object si = contactListBox.SelectedItem;
                    Contact c = null;

                    if (si is Contact)
                    {
                        c = (Contact)si;
                        firstNameTextBox.Text = c.FirstName;
                        lastNameTextBox.Text = c.LastName;
                        phoneTextBox.Text = c.Phone;
                        emailTextBox.Text = c.Email;
                        notesTextBox.Text = c.Note;
                        dateCreatedTextBox.Text = c.ContactDate.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

/*                              MENU ITEMS                                                    */
      
        /// <summary>
        /// Event handler to clear the contactListBox and all the text fields so the user can start a new contactlist when the user selects the New menu item.
        /// Throws an exception if the contactlist items and textboxes can't be cleared.
        /// </summary>
        /// <param name="sender">Created by VS when the event handler was made</param>
        /// <param name="e">Created by VS when the event handler was made</param>
        private void newMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contactListBox.Items.Clear();
                firstNameTextBox.Clear();
                lastNameTextBox.Clear();
                phoneTextBox.Clear();
                emailTextBox.Clear();
                notesTextBox.Clear();
                dateCreatedTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Event handler to open a saved contact list and update the information in the list with that in the selected file.
        /// Throws an exception if the file cannot be opened.
        /// </summary>
        /// <param name="sender">Created by VS when the event handler was made</param>
        /// <param name="e">Created by VS when the event handler was made</param>
        private void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            /* file dialog */
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.FileName = "Document";
            openDialog.DefaultExt = ".txt";
            openDialog.Filter = "Text Documents|*.txt";
            Nullable<bool> canOpenFile = openDialog.ShowDialog();

            if (canOpenFile == true)
            {
                try
                {
                    using (StreamReader streamIn = new StreamReader(openDialog.FileName))
                    {
                        /* reads to the end of the stream*/
                       while (!streamIn.EndOfStream)
                        {
                           /* read the line into a string */
                           String fileString = streamIn.ReadLine();

                           /* split the string up into array items of contacts at the pipes(|) */
                            String[] recordString = fileString.Split(new char[] {'|'});

                            String fname = recordString[0];
                            String lname = recordString[1];
                            String phone = recordString[2];
                            String emails = recordString[3];
                            String note = recordString[4];
                            String cdate = recordString[5];

                           /* make a new Contact */
                            Contact contact = new Contact(fname, lname, phone, emails, note, cdate);

                           /* add the contact to contactListBox items*/
                            contactListBox.Items.Add(contact);
                        }
                    }
                }
                    catch(Exception)
                    {
                        /* catch if the file can't be opened */
                        MessageBox.Show("The file couldn't be opened","Error", MessageBoxButton.OK,MessageBoxImage.Warning);
                    }
                }
        }

        /// <summary>
        /// Event handler to save the contacts in the list to a text file when the user selects the save menu item.
        /// Throws and exception if the file cannot be saved.
        /// </summary>
        /// <param name="sender">Created by VS when the event handler was made</param>
        /// <param name="e">Created by VS when the event handler was made</param>
        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            /* open the file dialog to save file */
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = "Document";
            saveDialog.DefaultExt = ".txt";
            saveDialog.Filter = "Text Documents|*.txt";
            Nullable<bool> canOpenFile = saveDialog.ShowDialog();

            if (canOpenFile == true)
            {

                try
                {
                    using (StreamWriter outfile = new StreamWriter(saveDialog.FileName))
                    {
                        
                        foreach (Contact c in contactListBox.Items)
                        {
                            StringBuilder outString = new StringBuilder();
                                outString.Append(c.FirstName).Append("|");
                                outString.Append(c.LastName).Append("|");
                                outString.Append(c.Phone).Append("|");
                                outString.Append(c.Email).Append("|");
                                outString.Append(c.Note).Append("|");
                                outString.Append(c.ContactDate.ToString());

                                outfile.WriteLine(outString.ToString());
                        }

                    }
                }catch(Exception){
                    MessageBox.Show("The file could not be saved", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            } 
        }

        /// <summary>
        /// Event handler to open the Instructions window when the user selects the instructions menu item.
        /// Throws an exception if the window can't open.
        /// </summary>
        /// <param name="sender">Created by VS when the event handler was made</param>
        /// <param name="e">Created by VS when the event handler was made</param>
        private void instructionsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContactInstructions instructions = new ContactInstructions();
                instructions.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("The Instructions Window didn't open, please try again.","Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Event handler that closes the app when the user selects the exit menu item
        /// </summary>
        /// <param name="sender">Created by VS when the event handler was made</param>
        /// <param name="e">Created by VS when the event handler was made</param>
        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            /* return to main window? OR exit program entirely?  */
        }
    }
}
