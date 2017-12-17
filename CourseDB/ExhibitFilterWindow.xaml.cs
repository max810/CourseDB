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
    /// Interaction logic for ExhibitFilterWindow.xaml
    /// </summary>
    public partial class ExhibitFilterWindow : Window
    {
        public MultipleFilterHandler Filters { get; set; }
        public Dictionary<string, FilterEventHandler> Delegates { get; set; }
        public ExhibitFilterWindow(MultipleFilterHandler filters)
        {
            Filters = filters;
            Delegates = new Dictionary<string, FilterEventHandler>();
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selected = ListOfFilters.SelectedItem?.ToString();
            if(selected != null)
            {
                ListOfFilters.Items.Remove(selected);
                Filters.Filter -= Delegates[selected];
                Delegates.Remove(selected);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int yearFrom = Misc.FromMask(FromYear.Text, int.MinValue);
            int yearTo = Misc.FromMask(FromYear.Text, int.MinValue);

            int widthFrom = Misc.FromMask(WidthFrom.Text, int.MinValue);
            int widthTo = Misc.FromMask(WidthTo.Text, int.MinValue);
            int heightFrom = Misc.FromMask(HeightFrom.Text, int.MinValue);
            int heightTo = Misc.FromMask(HeightTo.Text, int.MinValue);

            bool shouldBeOriginal = Original.IsChecked.Value;

            Predicate<Exhibit> checkOriginal = (x) => true;
            Predicate<Exhibit> checkYear = (x) => true;
            Predicate<Exhibit> checkSize = (x) => true;

            if (IsOriginalChoiceCheckBox.IsChecked == true)
            {
                checkOriginal = (x) => x.is_original == shouldBeOriginal;
            }
            if (YearChoiceCheckBox.IsChecked == true)
            {
                checkYear = (x) => x.date_of_acquiring.Year >= yearFrom && x.date_of_acquiring.Year <= yearTo;
            }
            if (SizeChoiceCheckBox.IsChecked == true)
            {
                checkSize = (x) => x.width >= widthFrom && x.width <= widthTo && x.height >= heightFrom && x.height <= heightTo;
            }
            FilterEventHandler handler = (s, ee) =>
            {
                var exhibit = ee.Item as Exhibit;
                ee.Accepted = checkOriginal(exhibit) && checkYear(exhibit) && checkSize(exhibit);
            };
            Filters.Filter += handler;
            Delegates.Add(FilterName.Text, handler);
            ListOfFilters.Items.Add(FilterName.Text);
            FilterName.Text = NameGenerator.GenerateName(ListOfFilters.Items, "Фильтр");
            Original.IsChecked = true;
            FromYear.Text = "*";
            ToYear.Text = "*";
            WidthFrom.Text = "*";
            WidthTo.Text = "*";
            HeightFrom.Text = "*";
            HeightTo.Text = "*";
            IsOriginalChoiceCheckBox.IsChecked = false;
            SizeChoiceCheckBox.IsChecked = false;
            YearChoiceCheckBox.IsChecked = false;


        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Filters.Operation = MultipleFilterLogic.And;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Filters.Operation = MultipleFilterLogic.Or;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;  // cancels the window close    
            this.Hide();      // Programmatically hides the window
        }

        public void ClearAllFilters()
        {
            foreach (var handler in Delegates)
            {
                Filters.Filter -= handler.Value;
            }
            Delegates.Clear();
            ListOfFilters.Items.Clear();
            FilterName.Text = NameGenerator.GenerateName(ListOfFilters.Items, "Фильтр");
            Original.IsChecked = true;
            FromYear.Text = "*";
            ToYear.Text = "*";
            WidthFrom.Text = "*";
            WidthTo.Text = "*";
            HeightFrom.Text = "*";
            HeightTo.Text = "*";
            IsOriginalChoiceCheckBox.IsChecked = false;
            SizeChoiceCheckBox.IsChecked = false;
            YearChoiceCheckBox.IsChecked = false;
        }
    }
}
