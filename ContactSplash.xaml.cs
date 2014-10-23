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

using System.Windows.Threading;
namespace ContactList
{
    /// <summary>
    /// Interaction logic for ContactSplash.xaml
    /// </summary>
    public partial class ContactSplash : Window
    {
        private DispatcherTimer timer = null;

        /// <summary>
        /// Initializes GUI, Instantiates a new instance of DispatchTimer and configures it's tick delay.
        /// </summary>
        public ContactSplash()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerTick;
        }

        /// <summary>
        /// Instantiates a new instance of ContactWindow and displays it to the user. The timer is then stopped and the ContactSplash is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void timerTick(Object sender, EventArgs e)
        {
            ContactWindow main = new ContactWindow();

            main.Show();
            timer.Stop();
            this.Close();
        }

        /// <summary>
        /// Starts the DispatcherTimer upon loading of this Window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

    }//closes class
}
