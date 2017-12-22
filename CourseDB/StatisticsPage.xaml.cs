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
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.Wpf;
using Microsoft.Win32;

namespace CourseDB
{
    /// <summary>
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page, INotifier
    {
        private MuseumContext context = App.Current.FindResource("museumContext") as MuseumContext;

        public event MessageSentEventHandler MessageSent;

        public PlotModel StatModel { get; set; }
        public int Artist_Id { get; set; }
        public StatisticsPage()
        {
            InitializeComponent();
            StatModel = new PlotModel();
            this.Loaded += (s, e) =>
            {
                ChosenArtist.SelectionChanged += ChosenArtist_SelectionChanged;
                ChosenArtist.SelectedIndex = 0;
            };
            DataContext = this;
        }

        private void ChosenArtist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currArtist = context.Artists.Find(Artist_Id);
            if (currArtist != null)
            {
                DrawGraph(currArtist);
            }
        }

        private void DrawGraph(Artist artist)
        {
            StatModel.Series.Clear();
            StatModel.Axes.Clear();

            var categoryAxis = new OxyPlot.Axes.CategoryAxis
            {
                Position = AxisPosition.Bottom
            };
            var s1 = new OxyPlot.Series.ColumnSeries
            {
                Title = $"Творчество художника ({artist.full_name})",
                StrokeColor = OxyColors.Black, StrokeThickness = 1
            };

            var paintings = context.Paintings.Where(x => x.artist_id == artist.id 
                && x.year_of_creation != null)
                .OrderBy(x => x.year_of_creation)
                .ToArray();
            if (paintings.Any())
            {
                var min = artist.date_of_birth.Value.Year;
                var max = artist.date_of_death?.Year != null ?
                    artist.date_of_death.Value.Year :
                    artist.date_of_birth.Value.AddYears(120).Year;
                int currIndex = 0;
                for (int i = min; ; i += 5)
                {
                    var nextBound = i + 5;
                    if (nextBound > max)
                    {
                        nextBound = max;
                    }
                    int count = 0;
                    while (currIndex < paintings.Length 
                        && paintings[currIndex].year_of_creation <= nextBound)
                    {
                        count++;
                        currIndex++;
                    }
                    s1.Items.Add(new ColumnItem(count));
                    categoryAxis.Labels.Add(i + Environment.NewLine + nextBound);
                    if (nextBound == max)
                    {
                        break;
                    }
                }

                var valueAxis = new OxyPlot.Axes.LinearAxis
                {
                    Position = AxisPosition.Left,
                    MinimumPadding = 0,
                    MaximumPadding = 0.06,
                    AbsoluteMinimum = 0
                };

                StatModel.Series.Add(s1);
                StatModel.Axes.Add(categoryAxis);
                StatModel.Axes.Add(valueAxis);
                StatModel.InvalidatePlot(true);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            PngExporter x = new PngExporter();
            var dialog = new SaveFileDialog()
            {
                Filter = "Image Files (*.png)|*.png;"
            };
            if(dialog.ShowDialog() == true)
            {
                x.ExportToFile(StatModel, dialog.FileName);
            }
        }

        private void SavePdf_Click(object sender, RoutedEventArgs e)
        {
            PdfExporter x = new PdfExporter()
            {
                Width = 700,
                Height = 400
            };
            var dialog = new SaveFileDialog()
            {
                Filter = "Potable Document Files (*.pdf)|*.pdf;"
            };
            if (dialog.ShowDialog() == true)
            {
                x.ExportToFile(StatModel, dialog.FileName);
            }
        }
    }
}
