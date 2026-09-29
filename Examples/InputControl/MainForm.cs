using static OpenGL.GL;

namespace InputControl
{
    public partial class MainForm : Form
    {
        Scene scene = new Scene();

        public MainForm()
        {
            InitializeComponent();
            Text = "OpenGL Segment Drawer";
            mousePos.Text = "Mouse Position: X=0, Y=0";
            segmentLabel.Text = "Segment: (0, 0)-(0, 0)";
            propertyScene.SelectedObject = scene;
            scene.SegmentChanged += (s, e) => viewer.Invalidate(); // Refresh the viewer when segments change
            propertyScene.PropertyValueChanged += (s, e) => viewer.Invalidate(); // Refresh the viewer when properties change
        }

        int W => viewer.ClientSize.Width;
        int H => viewer.ClientSize.Height;

        double left = -1, right=3, top=10, bottom=-30, far=-1, near= +1;

        private void viewer_Paint(object sender, PaintEventArgs e)
        {
            glLoadIdentity();
            glClearColor(scene.Background.R/255.0f, scene.Background.G / 255.0f, scene.Background.B / 255.0f, 1);
            glClear(GL_COLOR_BUFFER_BIT);

            glViewport(0, 0, W, H);
            glOrtho(left, right, bottom, top, near, far);

            //glColor3d(1, 1, 1);
            //glVertex2d(x1, y1);
            //glVertex2d(x2, y2);
            foreach (var segment in scene.Segments)
            {
                glLineWidth((float)segment.Width);
                glColor3d(segment.Color.R / 255.0, segment.Color.G / 255.0, segment.Color.B / 255.0);
                glBegin(GL_LINES);
                glVertex2d(segment.X1, segment.Y1);
                glVertex2d(segment.X2, segment.Y2);
                glEnd();
            }
        }

        (double X, double Y) MouseToWorld(int screenX, int screenY)
        {
            // Implementation for converting mouse coordinates to world coordinates
            return (
                left + screenX * (right - left) / W,
                top + screenY * (bottom - top) / H
            );
        }

        private void viewer_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos.Text = $"Mouse Position: X={e.X}, Y={e.Y}";

            if (isDragging)
            {
                //x2 = e.X;
                //y2 = e.Y;
                (x2, y2) = MouseToWorld(e.X, e.Y);
                currentSegment.X2 = x2;
                currentSegment.Y2 = y2;
                segmentLabel.Text = $"Segment: Start=({x1:F2}, {y1:F2}), End=({x2:F2}, {y2:F2})";
                viewer.Invalidate();
            }
        }

        double x1, y1, x2, y2;
        Segment? currentSegment = null;
        bool isDragging = false;

        private void viewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;

                //x1 = e.X;
                //y1 = e.Y;
                (x1, y1) = MouseToWorld(e.X, e.Y);
                currentSegment = new Segment(x1, y1, x1, y1);
                scene.Segments.Add(currentSegment);
            }
        }

        private void viewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDragging)
            {
                isDragging = false;
                //x2 = e.X;
                //y2 = e.Y;
                (x2, y2) = MouseToWorld(e.X, e.Y);
                currentSegment.X2 = x2;
                currentSegment.Y2 = y2;

                //scene.Segments.Add(new Segment(x1, y1, x2, y2));

                viewer.Invalidate(); // Refresh the viewer to show the line
            }

        }
    }
}
