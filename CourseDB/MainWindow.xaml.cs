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

namespace CourseDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model state;

        public MainWindow()
        {
            InitializeComponent();
            //this.Loaded += (s, e) => Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        public MainWindow(Model newState) : this()
        {
            state = newState;
            WriteToConsole($"Добро пожаловать, {state.CurrentUser.name} {state.CurrentUser.surname}!");
            WriteToConsole($"Сейчас {DateTime.Now}");
            SetMainContent(new MainMenuPage());
        }

        private void WriteToConsole(string text)
        {
            ConsoleBar.Text += "\n" + text;
            ConsoleScroll.ScrollToEnd();
        }

        private void SetMainContent(INotifier resource)
        {
            MainFrame.Content = resource;
            resource.MessageSent -= OnMessageReceived;
            resource.MessageSent += OnMessageReceived;
        }

        private void OnMessageReceived(object sender, MessageSentEventArgs e)
        {
            switch (e.MessageType)
            {
                case MessageType.Log:
                    WriteToConsole(e.Message);
                    return;
                case MessageType.Navigation:
                    var prevName = (MainFrame.Content as INotifier).Title;
                    SetMainContent(e.Parameter as INotifier);
                    WriteToConsole($"Навигация: {prevName} -> {(e.Parameter as INotifier).Title}");
                    return;
            }
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            SetMainContent(new MainMenuPage());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
