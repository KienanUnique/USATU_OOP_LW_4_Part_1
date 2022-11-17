using System.Windows.Forms;

namespace USATU_OOP_LW_4_Part_1
{
    public partial class FormMain : Form
    {
        private readonly SelectableCirclesHandler _selectableCirclesHandler;
        private bool _wasControlAlreadyPressed;

        public FormMain()
        {
            InitializeComponent();
            _selectableCirclesHandler = new SelectableCirclesHandler();
            this.KeyPreview = true;

            _selectableCirclesHandler.NeedUpdate += panelForCircles_Update;
        }

        private void panelForCircles_MouseClick(object sender, MouseEventArgs e)
        {
            _selectableCirclesHandler.ProcessClick(e.Location);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey && !_wasControlAlreadyPressed)
            {
                _selectableCirclesHandler.EnableMultipleSelection();
                _wasControlAlreadyPressed = true;
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
                    _selectableCirclesHandler.DeleteAllSelected();
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