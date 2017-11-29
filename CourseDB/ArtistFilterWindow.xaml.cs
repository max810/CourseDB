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
        private ArtistPage Context;
        public ArtistFilterWindow(ArtistPage context)
        {
            InitializeComponent();
            Context = context;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int from = FromYear.Text.Trim() == "*" || string.IsNullOrWhiteSpace(FromYear.Text) ? int.MinValue : int.Parse(FromYear.Text);
            int to = ToYear.Text.Trim() == "*" || string.IsNullOrWhiteSpace(ToYear.Text) ? int.MaxValue : int.Parse(ToYear.Text);
            FilterEventHandler handler = (s, ee) =>
            {
                var art = ee.Item as Artist;
                ee.Accepted = art.date_of_birth.Value.Year >= from && art.date_of_death.Value.Year <= to;
            };
            Context.ArtistFilters.Add(handler);
            ListOfFilters.Items.Add(FilterName.Text);
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
            var selected = ListOfFilters.SelectedItem;
            if (selected != null)
            {
                Context.artistFilterHandler.Filter -= Context.ArtistFilters[ListOfFilters.SelectedIndex];
                Context.ArtistFilters.RemoveAt(ListOfFilters.SelectedIndex);
                ListOfFilters.Items.Remove(ListOfFilters.SelectedItem);
            }
            FromYear.Text = "*";
            ToYear.Text = "*";
        }
    }
}
