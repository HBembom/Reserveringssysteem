using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ReservationSystem.Core.Model.OccupancyOverview
{
    internal class AssignPitchIndexGrid : IAssignElement
    {
        private Grid _grid;
        private int _pitchCountIndex;

        public AssignPitchIndexGrid(Grid grid)
        {
            this._grid = grid;
            _pitchCountIndex = 1;
        }

        public void AddElement(int row, int column)
        {
            TextBlock textBlock = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            textBlock.Text = _pitchCountIndex.ToString();
            _pitchCountIndex++;
            Grid.SetColumn(textBlock, column);
            Grid.SetRow(textBlock, row);
            _grid.Children.Add(textBlock); ;
        }
    }
}
