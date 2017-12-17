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
    /// Interaction logic for ArtistFilterWindow.xaml
    /// </summary>
    public partial class ArtistFilterWindow : Window
    {
        public MultipleFilterHandler Filters { get; set; }
        public Dictionary<string, FilterEventHandler> Delegates { get; set; }
        public ArtistFilterWindow(MultipleFilterHandler filters)
        {
            Filters = filters;
            Delegates = new Dictionary<string, FilterEventHandler>();
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int from = Misc.FromMask(FromYear.Text, int.MinValue);
            int to = Misc.FromMask(ToYear.Text, int.MaxValue);
            FilterEventHandler handler = (s, ee) =>
            {
                var art = ee.Item as Artist;
                ee.Accepted = art.date_of_birth.Value.Year >= from && art.date_of_death.Value.Year <= to;
            };
            Filters.Filter += handler;
            ListOfFilters.Items.Add(FilterName.Text);
            Delegates.Add(FilterName.Text, handler);
            FilterName.Text = NameGenerator.GenerateName(ListOfFilters.Items, "Фильтр");
            FromYear.Text = "*";
            ToYear.Text = "*";
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;  // cancels the window close    
            this.Hide();      // Programmatically hides the window
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selected = ListOfFilters.SelectedItem?.ToString();
            if (selected != null)
            {
                Filters.Filter -= Delegates[selected];
                Delegates.Remove(selected);
                ListOfFilters.Items.Remove(selected);
            }
            FromYear.Text = "*";
            ToYear.Text = "*";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Filters.Operation = MultipleFilterLogic.And;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Filters.Operation = MultipleFilterLogic.Or;
        }

        public void ClearAllFilters()
        {
            foreach(var handler in Delegates)
            {
                Filters.Filter -= handler.Value;
            }
            Delegates.Clear();
            ListOfFilters.Items.Clear();
            FilterName.Text = NameGenerator.GenerateName(ListOfFilters.Items, "Фильтр");
            FromYear.Text = "*";
            ToYear.Text = "*";
        }
    }
}