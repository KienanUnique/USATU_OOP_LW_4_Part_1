using System.Drawing;
using CustomDoublyLinkedListLibrary;

namespace USATU_OOP_LW_4_Part_1
{
    public class SelectableCirclesHandler
    {
        public delegate void NeedUpdateHandler();

        public event NeedUpdateHandler NeedUpdate;


        private readonly CustomDoublyLinkedList<SelectableCircle> _allCircles =
            new CustomDoublyLinkedList<SelectableCircle>();

        private bool _isMultipleSelectionEnabled;

        public void ProcessClick(Point clickPoint)
        {
            bool wasOnCircleClick = false;
            for (var i = _allCircles.GetPointerOnBeginning(); !i.IsBorderReached(); i.MoveNext())
            {
                if (i.Current.IsClicked(clickPoint))
                {
                    wasOnCircleClick = true;
                    if (!i.Current.IsSelected() && !_isMultipleSelectionEnabled)
                    {
                        UnselectAll();
                    }

                    i.Current.ProcessClick();
                }
            }

            if (!wasOnCircleClick)
            {
                if (_allCircles.Count == 1) 
                    UnselectAll();
                
                _allCircles.Add(new SelectableCircle(clickPoint, _allCircles.Count == 0));
            }

            NeedUpdate?.Invoke();
        }

        public void PaintAllCirclesOnGraphics(Graphics graphics)
        {
            for (var i = _allCircles.GetPointerOnBeginning(); !i.IsBorderReached(); i.MoveNext())
            {
                i.Current.DrawCircleOnGraphics(graphics);
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
            bool needUpdate = false;
            for (var i = _allCircles.GetPointerOnBeginning(); !i.IsBorderReached(); i.MoveNext())
            {
                if (i.Current.IsSelected())
                {
                    needUpdate = true;
                    _allCircles.RemovePointerElement(i);
                }
            }

            if (needUpdate)
            {
                NeedUpdate?.Invoke();
            }
        }

        private void UnselectAll()
        {
            for (var i = _allCircles.GetPointerOnBeginning(); !i.IsBorderReached(); i.MoveNext())
            {
                i.Current.Unselect();
            }
        }
    }
}