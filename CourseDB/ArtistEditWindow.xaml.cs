using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
    /// Interaction logic for ArtistEditWindow.xaml
    /// </summary>
    public partial class ArtistEditWindow : Window
    { 
        private bool edit;
        private MuseumContext context = App.Current.FindResource("museumContext") as MuseumContext;

        public Artist CurrentArtist { get; set; }
        public ArtistEditWindow()
        {
            CurrentArtist = new Artist();
            InitializeComponent();
        }
        public ArtistEditWindow(Artist artist)
        {
            CurrentArtist = artist;
            edit = true;
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (!edit)
            {
                context.Artists.Add(CurrentArtist);
            }
            context.SaveChanges();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if(edit)
                context.Entry(CurrentArtist).State = EntityState.Unchanged;
            this.Close();
        }
    }
}
