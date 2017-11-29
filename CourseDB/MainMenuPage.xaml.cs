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
using Microsoft.Office.Interop;

namespace CourseDB
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page, INotifier
    {
        public MainMenuPage()
        {
            InitializeComponent();
            //Microsoft.Office.Interop.Word.
        }
        
        public event MessageSentEventHandler MessageSent;

        private void Log(string logText)
        {
            MessageSent.Invoke(this, new MessageSentEventArgs(MessageType.Log, logText));
        }

        private void Navigate(INotifier destination)
        {
            MessageSent.Invoke(this, new MessageSentEventArgs(MessageType.Navigation, destination));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigate(new ExhibitPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Navigate(new ArtistPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Navigate(new StatisticsPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Navigate(new ReportsPage());
        }
    }
}
