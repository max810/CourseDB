using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    /// Interaction logic for PaintingFilterWindow.xaml
    /// </summary>
    public partial class PaintingFilterWindow : Window
    {
        private ArtistPage Context;
        public PaintingFilterWindow(ArtistPage context)
        {
            InitializeComponent();
            Context = context;
            DataContext = this;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int chosenMovement = (int)ChosenMovement.SelectedValue;
            int from = FromYear.Text.Trim() == "*" || string.IsNullOrWhiteSpace(FromYear.Text) ? int.MinValue : int.Parse(FromYear.Text);
            int to = ToYear.Text.Trim() == "*" || string.IsNullOrWhiteSpace(ToYear.Text) ? int.MaxValue : int.Parse(ToYear.Text);
            var func1 = new Func<Painting, bool>(x => true);
            var func2 = new Func<Painting, bool>(x => true);
            if (MovementChoiceCheckBox.IsChecked == true)
            {
                func1 = (s) => s.art_movement_id == chosenMovement;
            }
            if(YearChoiceCheckBox.IsChecked == true)
            {
                func2 = (s) => s.year_of_creation >= from && s.year_of_creation <= to;
            }
            FilterEventHandler filter = (s, ee) =>
            {
                var painting = ee.Item as Painting;
                ee.Accepted = func1(painting) && func2(painting);
            };
            Context.PaintingFilters.Add(filter);
            ListOfFilters.Items.Add(FilterName.Text);
            FromYear.Text = "*";
            ToYear.Text = "*";
            ChosenMovement.SelectedIndex = 0;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;  // cancels the window close    
            this.Hide();      // Programmatically hides the window
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selected = ListOfFilters.SelectedItem;
            if (selected != null)
            {
                Context.paintingFilterHandler.Filter -= Context.PaintingFilters[ListOfFilters.SelectedIndex];
                Context.PaintingFilters.RemoveAt(ListOfFilters.SelectedIndex);
                ListOfFilters.Items.Remove(ListOfFilters.SelectedItem);
            }
            FromYear.Text = "*";
            ToYear.Text = "*";
            ChosenMovement.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //(this.FindResource("art_movementViewSource") as CollectionViewSource).Source = Context.art_movementViewSource.Source;
        }
    }

    public class TwoBoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool one = (bool)values[0];
            bool two = (bool)values[1];
            return one || two;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
