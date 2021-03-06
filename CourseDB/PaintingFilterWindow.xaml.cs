﻿using System;
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
        public MultipleFilterHandler Filters { get; set; }
        public Dictionary<string, FilterEventHandler> Delegates { get; set; }
        public PaintingFilterWindow(MultipleFilterHandler filters)
        {
            Filters = filters;
            Delegates = new Dictionary<string, FilterEventHandler>();
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int chosenMovement = (int)ChosenMovement.SelectedValue;
            int from = Misc.FromMask(FromYear.Text, int.MinValue);
            int to = Misc.FromMask(ToYear.Text, int.MaxValue);
            var func1 = new Func<Painting, bool>(x => true);
            var func2 = new Func<Painting, bool>(x => true);
            if (MovementChoiceCheckBox.IsChecked == true)
            {
                func1 = (s) => s.art_movement_id == chosenMovement;
            }
            if (YearChoiceCheckBox.IsChecked == true)
            {
                func2 = (s) => s.year_of_creation >= from && s.year_of_creation <= to;
            }
            FilterEventHandler handler = (s, ee) =>
            {
                var painting = ee.Item as Painting;
                ee.Accepted = func1(painting) && func2(painting);
            };
            Filters.Filter += handler;
            ListOfFilters.Items.Add(FilterName.Text);
            Delegates.Add(FilterName.Text, handler);
            FilterName.Text = NameGenerator.GenerateName(ListOfFilters.Items, "Фильтр");
            FromYear.Text = "*";
            ToYear.Text = "*";
            ChosenMovement.SelectedIndex = 0;
            MovementChoiceCheckBox.IsChecked = false;
            YearChoiceCheckBox.IsChecked = false;
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //(this.FindResource("art_movementViewSource") as CollectionViewSource).Source = Context.art_movementViewSource.Source;
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
            foreach (var handler in Delegates)
            {
                Filters.Filter -= handler.Value;
            }
            Delegates.Clear();
            ListOfFilters.Items.Clear();
            FilterName.Text = NameGenerator.GenerateName(ListOfFilters.Items, "Фильтр");
            FromYear.Text = "*";
            ToYear.Text = "*";
            ChosenMovement.SelectedIndex = 0;
            MovementChoiceCheckBox.IsChecked = false;
            YearChoiceCheckBox.IsChecked = false;
        }
    }
}

