using static OpenGL.GL;

namespace InputControl
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        int W => viewer.ClientSize.Width;
        int H => viewer.ClientSize.Height;

        double left, right, top, bottom;

        private void viewer_Paint(object sender, PaintEventArgs e)
        {
            glLoadIdentity();
            glClearColor(0.3f, 0.3f, 0.4f, 1);
            glClear(GL_COLOR_BUFFER_BIT);

            glViewport(0, 0, W, H);
            glOrtho(0, W, H, 0, -1, 1);

            glColor3d(1, 1, 1);
            glBegin(GL_LINES);
            glVertex2d(x1, y1);
            glVertex2d(x2, y2);
            glEnd();
        }

        private void viewer_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos.Text = $"Mouse Position: X={e.X}, Y={e.Y}";

            if (isDragging)
            {
                x2 = e.X;
                y2 = e.Y;
                viewer.Invalidate();
            }
        }

        double x1, y1, x2, y2;
        bool isDragging = false;

        private void viewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;

                x1 = e.X;
                y1 = e.Y;
            }
        }

        private void viewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDragging)
            {
                isDragging = false;
                x2 = e.X;
                y2 = e.Y;

                viewer.Invalidate(); // Refresh the viewer to show the line
            }

        }
    }
}
