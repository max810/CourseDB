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
        private MuseumContext context = App.Current.FindResource("museumContext") as MuseumContext;
        public ArtistFilterWindow artistFilterWindow;
        public PaintingFilterWindow paintingFilterWindow;

        public MultipleFilterHandler artistFilterHandler;
        public MultipleFilterHandler paintingFilterHandler;
        private List<object> foundArtists;
        private List<object> foundPaintings;
        public int CurrentArtistFoundIndex { get; set; } = -1;
        public int CurrentPaintingFoundIndex { get; set; } = -1;
        public ArtistPage()
        {
            InitializeComponent();
        }

        public event MessageSentEventHandler MessageSent;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //artistViewSource = ;

            //paintingViewSource = ;
            //context.Paintings.Load(); - already done in App.xaml.cs

            artistFilterHandler = new MultipleFilterHandler(App.Current.FindResource("artistViewSource") as CollectionViewSource, MultipleFilterLogic.And);
            paintingFilterHandler = new MultipleFilterHandler(this.FindResource("artistPaintingsViewSource") as CollectionViewSource, MultipleFilterLogic.And);

            artistFilterWindow = new ArtistFilterWindow(artistFilterHandler);
            paintingFilterWindow = new PaintingFilterWindow(paintingFilterHandler);

        }

        private void ArtistFilterButton_Click(object sender, RoutedEventArgs e)
        {
            artistFilterWindow.ShowDialog();
        }

        private void PaintingFilterButton_Click(object sender, RoutedEventArgs e)
        {
            paintingFilterWindow.ShowDialog();
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

        private void NextFoundArtistButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentArtistFoundIndex = artistDataGrid.MoveFoundPointer(Direction.Forward, CurrentArtistFoundIndex, foundArtists);
        }

        private void ArtistSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            foundArtists = artistDataGrid.GetFoundItems().ToList();
        }

        private void PreviousFoundArtistButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentArtistFoundIndex = artistDataGrid.MoveFoundPointer(Direction.BackWard, CurrentArtistFoundIndex, foundArtists);
        }

        private void PreviousFoundPaintingButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPaintingFoundIndex = paintingsDataGrid.MoveFoundPointer(Direction.BackWard, CurrentPaintingFoundIndex, foundPaintings);
        }

        private void NextFoundPaintingButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPaintingFoundIndex = paintingsDataGrid.MoveFoundPointer(Direction.Forward, CurrentPaintingFoundIndex, foundPaintings);
        }

        private void ClearAllArtistFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            artistFilterWindow.ClearAllFilters();
        }

        private void ClearAllPaintingFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            paintingFilterWindow.ClearAllFilters();
        }

        private void PaintingSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            foundPaintings = paintingsDataGrid.GetFoundItems().ToList();
        }
    }
}
