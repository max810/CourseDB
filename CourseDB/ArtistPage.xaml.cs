using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using OxyPlot.Wpf;

namespace CourseDB
{
    /// <summary>
    /// Interaction logic for ArtistPage.xaml
    /// </summary>
    public partial class ArtistPage : Page, INotifier
    {
        public List<FilterEventHandler> ArtistFilters = new List<FilterEventHandler>();
        public List<FilterEventHandler> PaintingFilters = new List<FilterEventHandler>();
        private MuseumContext context = App.Current.FindResource("museumContext") as MuseumContext;
        public CollectionViewSource artistViewSource;
        public CollectionViewSource paintingViewSource;
        public CollectionViewSource art_movementViewSource;
        public ArtistFilterWindow artistFilterWindow;
        public PaintingFilterWindow paintingFilterWindow;
        public ArtistPage()
        {
            InitializeComponent();
            artistFilterWindow = new ArtistFilterWindow(this);
            paintingFilterWindow = new PaintingFilterWindow(this);
        }

        public event MessageSentEventHandler MessageSent;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            artistViewSource = App.Current.FindResource("artistViewSource") as CollectionViewSource;

            paintingViewSource = this.FindResource("artistPaintingsViewSource") as CollectionViewSource;
            context.Paintings.Load();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            artistFilterWindow.ShowDialog();
            if (ArtistFilters.Any())
            {
                foreach (var filter in ArtistFilters)
                {
                    artistViewSource.Filter -= filter;
                    artistViewSource.Filter += filter;
                }
            }
        }

        private void PaintingButton_Click(object sender, RoutedEventArgs e)
        {
            paintingFilterWindow.ShowDialog();
            if (PaintingFilters.Any())
            {
                foreach (var filter in PaintingFilters)
                {
                    paintingViewSource.Filter -= filter;
                    paintingViewSource.Filter += filter;
                }
            }
        }

        private void AddArtistClick(object sender, RoutedEventArgs e)
        {
            Log("Добавление художника начато.");
            if (new ArtistEditWindow().ShowDialog() == true)
            {
                Log("Добавление художника успешно.");
            }
            else
            {
                Log("Отмена добавления");
            }
            RefreshViews();
        }

        private void EditArtistClick(object sender, RoutedEventArgs e)
        {
            if (artistDataGrid.SelectedValue is Artist selected)
            {
                Log("Редактирование информации о художнике начато.");
                if (new ArtistEditWindow(selected).ShowDialog() == true)
                {
                    Log("Редактирование успешно.");
                }
                else
                {
                    Log("Отмена редактирования.");
                }
                RefreshViews();
            }
        }

        private void DeleteArtist_Click(object sender, RoutedEventArgs e)
        {
            var entity = artistDataGrid.SelectedValue as Artist;
            context.Artists.Remove(entity);
            context.SaveChanges();
            Log("Художник и его картины удалены.");
            RefreshViews();
        }

        private void AddPainting_Click(object sender, RoutedEventArgs e)
        {
            new PaintingEditWindow().ShowDialog();
            RefreshViews();
        }

        private void EditPainting_Click(object sender, RoutedEventArgs e)
        {
            if (paintingsDataGrid.SelectedValue is Painting selected)
            {
                Log("Редактирование информации о картине начато.");
                if (new PaintingEditWindow(selected).ShowDialog() == true)
                {
                    Log("Редактирование успешно.");
                }
                else
                {
                    Log("Отмена редактирования.");
                }
            }
            RefreshViews();
        }

        private void DeletePainting_Click(object sender, RoutedEventArgs e)
        {
            var entity = paintingsDataGrid.SelectedValue as Painting;
            context.Paintings.Remove(entity);
            context.SaveChanges();
            Log("Картина удалена");
            RefreshViews();
        }

        private void RefreshViews()
        {
            artistDataGrid.Items.Refresh();
            paintingsDataGrid.Items.Refresh();
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
