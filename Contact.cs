using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    class Contact
    {
/*                         VARIABLES                    */
        /* private string for each field's info */
        private String firstName;
        private String lastName;
        private String phone;
        private String email;
        private String note;
        private String contactDate;
        

        /* public getters and setters to access info  */

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public String Note
        {
            get { return note; }
            set { note = value; }
        }

        /* Date the contact was added to the list */
        public String ContactDate
        {
            get { return contactDate; }
            set { contactDate = value; }
        }

        /* Constructor with 5 Strings */
        public Contact(String firstName, String lastName, String phone, String email, String note, String contactDate)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.email = email;
            this.note = note;
            this.contactDate = contactDate;
        }

        public Contact()
        {
        }

        /* override ToString function to print out correct info */
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(firstName).Append(" ");
            sb.Append(lastName);
            return sb.ToString();
        }

    }//closes class
}
