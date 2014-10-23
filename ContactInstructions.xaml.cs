/* File: Instructions.xaml.cs
 * Author: Sheila Galbraith, Member of Group 1
 * Date: October 21, 2014
 * Description: Code behind for the Instructions.xaml class
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
using System.Windows.Shapes;

namespace ContactList
{
    /// <summary>
    /// Interaction logic for Instructions.xaml
    /// </summary>
    public partial class ContactInstructions : Window
    {
        public ContactInstructions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// event handler to set, using a StringBuilder, the text of the Instructions TextBlock when the window is initialized
        /// </summary>
        /// <param name="sender">Set by VS when the handler is created</param>
        /// <param name="e">Set by VS when the handler is creaed</param>
        private void instrTextBlock_Initialized(object sender, EventArgs e)
        {
            StringBuilder instrString = new StringBuilder();

            instrString.Append("How to Use the Contact List").Append("\r\n");
            instrString.Append("\r\n");
            instrString.Append("1. Enter the person's information in the given boxes.").Append("\r\n");
            instrString.Append("2. Click the 'Add Contact' button to add the person to your list of contacts.").Append("\r\n");
            instrString.Append("3. To check the contact's information, click on their name in list.").Append("\r\n");
            instrString.Append("4. To save the list to a text file, select 'Save' in the File menu.").Append("\r\n");
            instrString.Append("5. To open a previously saved list, select 'Open' in the File menu.").Append("\r\n");

            instrTextBlock.Text = instrString.ToString();
        }

        /// <summary>
        /// Event handler to close the window when the user clicks the backButton to return to the contact list window
        /// </summary>
        /// <param name="sender">Set by VS when the handler is created</param>
        /// <param name="e">Set by VS when the handler is created</param>
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }//closes class
}
