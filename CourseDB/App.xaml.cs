using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CourseDB
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        private void Application_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            var context = this.FindResource("museumContext") as MuseumContext;
            context.Artists.Load();
            context.Paintings.Load();
            context.Art_movement.Load();
            context.Exhibits.Load();
            context.Halls.Load();
            (this.FindResource("artistViewSource") as CollectionViewSource).Source = context.Artists.Local;
            (this.FindResource("paintingViewSource") as CollectionViewSource).Source = context.Paintings.Local;
            (this.FindResource("art_movementViewSource") as CollectionViewSource).Source = context.Art_movement.Local;
            (this.FindResource("exhibitViewSource") as CollectionViewSource).Source = context.Exhibits.Local;
            (this.FindResource("hallViewSource") as CollectionViewSource).Source = context.Halls.Local;
        }
    }
}
