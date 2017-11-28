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
using Microsoft.Win32;
using System.IO;

namespace CourseDB
{
    /// <summary>
    /// Interaction logic for PaintingEditWindow.xaml
    /// </summary>
    public partial class PaintingEditWindow : Window
    {
        private bool edit;
        private MuseumContext context = App.Current.FindResource("museumContext") as MuseumContext;

        public Painting CurrentPainting { get; set; }
        public PaintingEditWindow()
        {
            CurrentPainting = new Painting();
            InitializeComponent();
        }

        public PaintingEditWindow(Painting painting)
        {
            CurrentPainting = painting;
            edit = true;
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (!edit)
            {
                context.Paintings.Add(CurrentPainting);
            }
            context.SaveChanges();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if(edit)
                context.Entry(CurrentPainting).State = EntityState.Unchanged;
            this.Close();
        }

        private void ChooseFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                DefaultExt = ".png",
                Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif",
                CheckPathExists = true
            };
            if(dialog.ShowDialog() == true)
            {
                string name = dialog.FileName;
                byte[] image = File.ReadAllBytes(name);
                CurrentPainting.image = image;
            }
        }
    }
}
