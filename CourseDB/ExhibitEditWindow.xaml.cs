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
using System.Windows.Shapes;

namespace CourseDB
{
    /// <summary>
    /// Interaction logic for ExhibitEditWindow.xaml
    /// </summary>
    public partial class ExhibitEditWindow : Window
    {
        private bool edit;
        private MuseumContext context = App.Current.FindResource("museumContext") as MuseumContext;
        public CollectionViewSource paintingViewSource = App.Current.FindResource("paintingViewSource") as CollectionViewSource;
        public Exhibit CurrentExhibit { get; set; }
        private FilterEventHandler paintingFilter = (s, e) => e.Accepted = (e.Item as Painting).Exhibit == null;
        public ExhibitEditWindow()
        {
            CurrentExhibit = new Exhibit();
            InitializeComponent();
        }
        public ExhibitEditWindow(Exhibit current)
        {
            edit = true;
            CurrentExhibit = current;
            InitializeComponent();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            CurrentExhibit.canvas_type = (CanvasTypeComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            CurrentExhibit.paint_type = (PaintTypeComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            if (!edit)
            {
                context.Exhibits.Add(CurrentExhibit);
            }
            paintingViewSource.Filter -= paintingFilter;
            context.SaveChanges();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (edit)
                context.Entry(CurrentExhibit).State = EntityState.Unchanged;
            this.Close();
        }

        private void UI_Loaded(object sender, RoutedEventArgs e)
        {
            paintingViewSource.Filter += paintingFilter;
        }
    }
}
