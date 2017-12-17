using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace CourseDB
{
    public enum Direction { Forward, BackWard };
    public static class DataGridExtensionClass
    {
        public static IEnumerable<DataGridRow> GetRows(this DataGrid grid)
        {
            foreach (var item in grid.Items)
            {
                yield return (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(item);
            }
        }

        public static IEnumerable<DataGridCellInfo> GetCellsInfo(this DataGrid grid, Func<DataGridCell, bool> predicate)
        {
            foreach (var item in grid.Items)
            {
                foreach (var col in grid.Columns)
                {
                    var cellInfo = new DataGridCellInfo(item, col);
                    var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
                    if (cellContent?.Parent is DataGridCell cell && predicate(cell))
                    {
                        yield return cellInfo;
                    }
                }
            }
        }

        public static IEnumerable<object> GetFoundItems(this DataGrid grid)
        {
            return grid.GetCellsInfo(x => DataGridSearch.GetIsTextMatch(x)).Select(x => x.Item).Distinct();
        }

        public static int MoveFoundPointer<T>(this DataGrid grid, Direction direction, int index, IList<T> foundItems)
        {
            switch (direction)
            {
                case Direction.Forward:
                    index++;
                    break;
                case Direction.BackWard:
                    index--;
                    break;
            }
            index = 
                index >= foundItems.Count ? 0 :
                index < 0 ? foundItems.Count - 1 : index;

            grid.SelectedItem = foundItems[index];
            grid.Focus();
            grid.ScrollIntoView(grid.SelectedItem);
            grid.UpdateLayout();
            return index;
        }
    }

}
