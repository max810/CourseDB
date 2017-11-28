using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CourseDB
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MuseumContext dbcontext;
        //private INotifyPropertyChanged curr;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string login = loginBox.Text;
            string pwd = passwordBox.Password;
            dbcontext = new MuseumContext();
            Account account;
            if((account = dbcontext.Accounts.FirstOrDefault(x => x.login == login && x.password == pwd)) != null)
            {
                if(this.Owner == null)
                {
                    MainWindow mainWindow = new MainWindow(new Model()
                        {
                            CurrentUser = account.User_profile,
                            DbContext = dbcontext
                        }
                    );
                    mainWindow.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong login or password");
            }
        }
    }
}
