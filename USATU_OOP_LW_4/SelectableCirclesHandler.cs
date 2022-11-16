using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace USATU_OOP_LW_4
{
    public class SelectableCirclesHandler
    {
        public delegate void NeedUpdateHandler();

        public event NeedUpdateHandler NeedUpdate;


        private readonly List<SelectableCircle> _allCircles = new List<SelectableCircle>();
        private bool _isMultipleSelectionEnabled;

        public void ProcessClick(Point clickPoint)
        {
            bool wasOnCircleClick = false;
            foreach (var circle in _allCircles.Where(circle => circle.IsClicked(clickPoint)))
            {
                wasOnCircleClick = true;
                if (!circle.IsSelected() && !_isMultipleSelectionEnabled)
                {
                    UnselectAll();
                }

                circle.ProcessClick();
            }

            if (!wasOnCircleClick)
            {
                if (_allCircles.Count == 0)
                {
                    _allCircles.Add(new SelectableCircle(clickPoint, true));
                }
                else
                {
                    if (_allCircles.Count == 1)
                    {
                        UnselectAll();
                    }

                    _allCircles.Add(new SelectableCircle(clickPoint, false));
                }
            }

            NeedUpdate?.Invoke();
        }

        public void PaintAllCirclesOnGraphics(Graphics graphics)
        {
            foreach (var circle in _allCircles)
            {
                circle.DrawCircleOnGraphics(graphics);
            }
        }

        public void EnableMultipleSelection()
        {
            _isMultipleSelectionEnabled = true;
        }

        public void DisableMultipleSelection()
        {
            _isMultipleSelectionEnabled = false;
        }

        public void DeleteAllSelected()
        {
            _allCircles.RemoveAll(circle => circle.IsSelected());
            NeedUpdate?.Invoke();
        }

        private void UnselectAll()
        {
            foreach (var circle in _allCircles)
            {
                circle.Unselect();
            }
        }
    }
}