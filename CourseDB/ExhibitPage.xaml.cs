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

namespace CourseDB
{
    /// <summary>
    /// Interaction logic for ExhibitPage.xaml
    /// </summary>
    public partial class ExhibitPage : Page, INotifier
    {
        private MuseumContext context = App.Current.FindResource("museumContext") as MuseumContext;
        public MultipleFilterHandler exhibitFilterHandler;
        private List<object> foundExhibits;
        private ExhibitFilterWindow filterWindow;
        public int CurrentExhibitFoundIndex { get; set; } = -1;
        public ExhibitPage()
        {
            InitializeComponent();
        }

        public event MessageSentEventHandler MessageSent;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            exhibitFilterHandler = new MultipleFilterHandler(App.Current.FindResource("exhibitViewSource") as CollectionViewSource, MultipleFilterLogic.And);
            filterWindow = new ExhibitFilterWindow(exhibitFilterHandler);
        }

        private void NextFoundExhibitButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentExhibitFoundIndex = exhibitDataGrid.MoveFoundPointer(Direction.Forward, CurrentExhibitFoundIndex, foundExhibits);
        }

        private void PreviousFoundExhibitButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentExhibitFoundIndex = exhibitDataGrid.MoveFoundPointer(Direction.BackWard, CurrentExhibitFoundIndex, foundExhibits);
        }

        private void ExhibitFilterButton_Click(object sender, RoutedEventArgs e)
        {
            filterWindow.ShowDialog();
        }

        private void ClearAllExhibitFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            filterWindow.ClearAllFilters();
        }

        private void ExhibitSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            foundExhibits = exhibitDataGrid.GetFoundItems().ToList();
        }

        private void AddExhibit_Click(object sender, RoutedEventArgs e)
        {
            Log("Добавление художника начато.");
            if (new ExhibitEditWindow().ShowDialog() == true)
            {
                Log("Добавление художника успешно.");
            }
            else
            {
                Log("Отмена добавления");
            }
            exhibitDataGrid.Items.Refresh();
        }

        private void EditExhibit_Click(object sender, RoutedEventArgs e)
        {
            Log("Изменение художника начато.");
            if (exhibitDataGrid.SelectedValue is Exhibit selected)
            {
                Log("Редактирование информации об экспонате начато.");
                if (new ExhibitEditWindow(selected).ShowDialog() == true)
                {
                    Log("Редактирование успешно.");
                }
                else
                {
                    Log("Отмена редактирования.");
                }
            }
            exhibitDataGrid.Items.Refresh();
        }

        private void DeleteExhibit_Click(object sender, RoutedEventArgs e)
        {
            var entity = exhibitDataGrid.SelectedValue as Exhibit;
            context.Exhibits.Remove(entity);
            context.SaveChanges();
            Log("Экспонат удален.");
        }

        private void Log(string logText)
        {
            MessageSent.Invoke(this, new MessageSentEventArgs(MessageType.Log, logText));
        }

        private void Navigate(INotifier destination)
        {
            MessageSent.Invoke(this, new MessageSentEventArgs(MessageType.Navigation, destination));
        }
    }
}
