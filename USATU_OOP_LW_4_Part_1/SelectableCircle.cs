using System.Drawing;

namespace USATU_OOP_LW_4_Part_1
{
    public class SelectableCircle
    {
        private const int CircleRadius = 25;
        private const int CircleUnselectedWidth = 5;

        private static readonly Color CircleColor = Color.DodgerBlue;
        private static readonly Pen CirclePenUnselected = new Pen(CircleColor, CircleUnselectedWidth);
        private static readonly SolidBrush CircleBrushSelected = new SolidBrush(CircleColor);
        private readonly Rectangle _circleRectangle;

        private bool _isSelected;

        public SelectableCircle(Point circleCenter, bool isSelected) => (_circleRectangle, _isSelected) = (
            new Rectangle(circleCenter.X - CircleRadius, circleCenter.Y - CircleRadius, CircleRadius * 2,
                CircleRadius * 2), isSelected);

        public void DrawCircleOnGraphics(Graphics graphics)
        {
            if (_isSelected)
            {
                graphics.FillEllipse(CircleBrushSelected, _circleRectangle);
            }
            else
            {
                graphics.DrawEllipse(CirclePenUnselected, _circleRectangle);
            }
        }

        public bool IsSelected()
        {
            return _isSelected;
        }

        public void Select()
        {
            _isSelected = true;
        }

        public void Unselect()
        {
            _isSelected = false;
        }

        public bool IsClicked(Point clickPoint)
        {
            int tmpX = clickPoint.X - _circleRectangle.Location.X - CircleRadius;
            int tmpY = clickPoint.Y - _circleRectangle.Location.Y - CircleRadius;
            return tmpX * tmpX + tmpY * tmpY <= CircleRadius * CircleRadius;
        }

        public void ProcessClick()
        {
            _isSelected = !_isSelected;
        }
    }
}