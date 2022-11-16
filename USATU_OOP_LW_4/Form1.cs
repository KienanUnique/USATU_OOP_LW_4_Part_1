using System.Windows.Forms;

namespace USATU_OOP_LW_4
{
    public partial class Form1 : Form
    {
        private readonly SelectableCirclesHandler _selectableCirclesHandler;
        private bool _wasControlAlreadyPressed;
        private bool _wasDeleteAlreadyPressed;

        public Form1()
        {
            InitializeComponent();
            _selectableCirclesHandler = new SelectableCirclesHandler();
            this.KeyPreview = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            _selectableCirclesHandler.NeedUpdate += panelForCircles_Update;
        }

        private void panelForCircles_MouseClick(object sender, MouseEventArgs e)
        {
            _selectableCirclesHandler.ProcessClick(e.Location);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    if (!_wasControlAlreadyPressed)
                    {
                        _selectableCirclesHandler.EnableMultipleSelection();
                        _wasControlAlreadyPressed = true;
                    }

                    break;
                case Keys.Delete:
                    if (!_wasDeleteAlreadyPressed)
                    {
                        _selectableCirclesHandler.DeleteAllSelected();
                        _wasDeleteAlreadyPressed = true;
                    }

                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    _selectableCirclesHandler.DisableMultipleSelection();
                    _wasControlAlreadyPressed = false;
                    break;
                case Keys.Delete:
                    _wasDeleteAlreadyPressed = false;
                    break;
            }
        }

        private void panelForCircles_Paint(object sender, PaintEventArgs e)
        {
            _selectableCirclesHandler.PaintAllCirclesOnGraphics(e.Graphics);
        }

        private void panelForCircles_Update()
        {
            panelForCircles.Invalidate();
        }
    }
}