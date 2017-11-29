using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
//using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using Word = Microsoft.Office.Interop.Word;

namespace CourseDB
{
    /// <summary>
    /// Interaction logic for ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page, INotifier
    {
        private MuseumContext context = App.Current.FindResource("museumContext") as MuseumContext;

        public event MessageSentEventHandler MessageSent;

        public DataView CrossView { get; set; }
        public DataView HallStatView { get; set; }
        private Artist chosenArtist;
        public Artist ChosenArtist
        {
            get { return chosenArtist; }
            set
            {
                chosenArtist = value;
                if(ArtistExhibitDataGrid != null)
                    ArtistExhibitDataGrid.ItemsSource = GetArtistExhibitStatTable(chosenArtist).DefaultView;
            }
        }
        public ReportsPage()
        {
            CrossView = GetCrossTable().DefaultView;
            HallStatView = GetHallStatTable().DefaultView;
            InitializeComponent();
        }

        private DataTable GetCrossTable()
        {
            var pivot = new DataTable("Статистика по направлениям");
            pivot.Columns.Add("Полное имя художника", typeof(string));
            var artMovements = context.Art_movement.ToArray();
            foreach (var movement in context.Art_movement)
            {
                pivot.Columns.Add(movement.name, typeof(int));
            }
            foreach (var artist in context.Artists)
            {
                DataRow entry = pivot.NewRow();
                int columnNumber = 0;
                entry[columnNumber] = artist.full_name;
                columnNumber++;
                while (columnNumber < pivot.Columns.Count)
                {
                    var paintingsCount = artist.Paintings.Where(x => x.Art_movement == artMovements[columnNumber - 1]).Count();
                    entry[columnNumber] = paintingsCount;
                    columnNumber++;
                }
                pivot.Rows.Add(entry);
            }
            return pivot;
        }

        private DataTable GetHallStatTable()
        {
            var hallStatTable = new DataTable("Статистика по залам");
            hallStatTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Название зала", typeof(string)),
                new DataColumn("Всего экспонатов", typeof(int)),
                new DataColumn("Из них оригиналов", typeof(int)),
                new DataColumn("И репродукций", typeof(int)),
                new DataColumn("Основное направление", typeof(string)),
                new DataColumn("Средний размер экспоната, см", typeof(string))
            });
            foreach (var hall in context.Halls)
            {
                int columnNumber = 0;
                var entry = hallStatTable.NewRow();

                entry[columnNumber] = hall.name;
                columnNumber++;
                entry[columnNumber] = hall.Exhibits.Count;
                columnNumber++;

                var origCount = hall.Exhibits.Where(x => x.is_original).Count();
                entry[columnNumber] = origCount;
                columnNumber++;

                entry[columnNumber] = hall.Exhibits.Count - origCount;
                columnNumber++;

                entry[columnNumber] = GetMainMovement(hall.Exhibits);
                columnNumber++;

                entry[columnNumber] = hall.Exhibits.Any() 
                    ? $"{hall.Exhibits.Average(x => x.width)} x {hall.Exhibits.Average(x => x.height)}" 
                    : "-";


                hallStatTable.Rows.Add(entry);
            }

            return hallStatTable;
        }
        private string GetMainMovement(IList<Exhibit> list)
        {
            if (list.Count < 2)
            {
                return "-";
            }
            int delta = list.Count < 10 ? 1
                : list.Count > 100 ? 5
                : 2;

            var counts = list.GroupBy(x => x.Painting.Art_movement)
                .Select(x => new { MovementName = x.Key.name, PaintingCount = x.Count() })
                .OrderByDescending(x => x.PaintingCount)
                .ToArray();
            if (counts[0].PaintingCount - counts[1].PaintingCount < delta)
            {
                return "-";
            }
            else
            {
                return counts[0].MovementName;
            }
        }

        private DataTable GetArtistExhibitStatTable(Artist artist)
        {
            var artistExhibitStatTable = new DataTable("Картины художника");
            artistExhibitStatTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Картина", typeof(string)),
                new DataColumn("Наличие экспоната", typeof(string)),
                new DataColumn("Оригинал ли", typeof(string)),
                new DataColumn("Зал, где выставляется", typeof(string))
            });

            foreach(var painting in artist.Paintings)
            {
                int columnNumber = 0;
                var entry = artistExhibitStatTable.NewRow();

                entry[columnNumber] = painting.name;
                columnNumber++;

                var exhibit = painting.Exhibit;

                entry[columnNumber] = exhibit == null ? "-" : "+";
                columnNumber++;

                entry[columnNumber] = (exhibit?.is_original ?? false) ? "+" : "-";
                columnNumber++;

                entry[columnNumber] = exhibit?.Hall.name ?? "-";

                artistExhibitStatTable.Rows.Add(entry);
            }
            return artistExhibitStatTable;
        }

        private void SaveHallReport(object sender, RoutedEventArgs e)
        {
            object missing = System.Reflection.Missing.Value;
            Word.ApplicationClass WordApp = new Word.ApplicationClass();
            Word.Document doc = WordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            Word.Range range = doc.Range(0, ref missing);
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Word Files (*doc)|*.doc;"
            };
            if (dialog.ShowDialog() == true)
            {
                object fileName = dialog.FileName;
                try
                {
                    range.Font.Name = "Georgia";
                    range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    range.Font.Size = 14.0F;
                    range.Font.Bold = 1;
                    range.InsertAfter("Статистика по залам \n\n");

                    var table = range.Tables.Add(range.Paragraphs[2].Range, HallStatView.Table.Rows.Count + 1, HallStatView.Table.Columns.Count, ref missing, ref missing);
                    range.Tables[1].Range.Font.Size = 10;
                    range.Tables[1].Range.Font.Name = "Consolas";
                    range.Tables[1].Range.Font.Bold = 0;
                    range.Tables[1].Columns.DistributeWidth();
                    range.Tables[1].Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    range.Tables[1].Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

                    for (int i = 0; i < HallStatView.Table.Columns.Count; i++)
                        range.Tables[1].Cell(1, i + 1).Range.Text = HallStatView.Table.Columns[i].ColumnName;

                    for (int k = 0; k < HallStatView.Table.Rows.Count; k++)
                    {
                        var items = HallStatView.Table.Rows[k].ItemArray;
                        for (int i = 0; i <items.Length; i++)
                        {
                            range.Tables[1].Cell(k + 2, i + 1).Range.Text = items[i].ToString();
                        }
                    }
                    range.InsertAfter("\nDate:" + DateTime.Now.ToString());

                    doc.SaveAs2(ref fileName);
                    WordApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Создать отчет не удалось. Ошибка: " + ex.Message);
                }
            }
        }

        private void SaveCrossReport(object sender, RoutedEventArgs e)
        {
            object missing = System.Reflection.Missing.Value;
            Word.ApplicationClass WordApp = new Word.ApplicationClass();
            Word.Document doc = WordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            Word.Range range = doc.Range(0, ref missing);
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Word Files (*doc)|*.doc;"
            };
            if (dialog.ShowDialog() == true)
            {
                object fileName = dialog.FileName;
                try
                {
                    range.Font.Name = "Georgia";
                    range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    range.Font.Size = 14.0F;
                    range.Font.Bold = 1;
                    range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
                    range.InsertAfter("Перекрестная статистика по художникам\n\n");
                    range.Font.Underline = Word.WdUnderline.wdUnderlineNone;

                    var table = range.Tables.Add(range.Paragraphs[2].Range, CrossView.Table.Rows.Count + 1, CrossView.Table.Columns.Count, ref missing, ref missing);
                    range.Tables[1].Range.Font.Size = 10;
                    range.Tables[1].Range.Font.Name = "Consolas";
                    range.Tables[1].Range.Font.Bold = 0;
                    range.Tables[1].Columns.DistributeWidth();
                    range.Tables[1].Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    range.Tables[1].Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

                    for (int i = 0; i < CrossView.Table.Columns.Count; i++)
                        range.Tables[1].Cell(1, i + 1).Range.Text = CrossView.Table.Columns[i].ColumnName;

                    for (int k = 0; k < CrossView.Table.Rows.Count; k++)
                    {
                        var items = CrossView.Table.Rows[k].ItemArray;
                        for (int i = 0; i < items.Length; i++)
                        {
                            range.Tables[1].Cell(k + 2, i + 1).Range.Text = items[i].ToString();
                        }
                    }
                    range.InsertAfter("\nDate:" + DateTime.Now.ToString());

                    doc.SaveAs2(ref fileName);
                    WordApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Создать отчет не удалось. Ошибка: " + ex.Message);
                }
            }
        }

        private void UI_Loaded(object sender, RoutedEventArgs e)
        {
            ChosenArtist = ChosenArtistComboBox.SelectedItem as Artist;
        }
    }
}
