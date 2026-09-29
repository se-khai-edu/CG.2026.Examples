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

            // Refresh the viewer when segments change
            scene.SegmentChanged += (s, e) => viewer.Invalidate();
            // Refresh the viewer when properties change
            propertyScene.PropertyValueChanged += (s, e) => viewer.Invalidate(); 
        }

        int W => viewer.ClientSize.Width;
        int H => viewer.ClientSize.Height;

        private void viewer_Paint(object sender, PaintEventArgs e)
        {
            glLoadIdentity();
            glClearColor(scene.Background.R/255.0f, scene.Background.G / 255.0f, scene.Background.B / 255.0f, 1);
            glClear(GL_COLOR_BUFFER_BIT);

            glViewport(0, 0, W, H);
            glOrtho(scene.left, scene.right, scene.bottom, scene.top, scene.near, scene.far);

            scene.Draw();
        }

        (double X, double Y) MouseToWorld(int screenX, int screenY)
        {
            // Implementation for converting mouse coordinates to world coordinates
            return (
                scene.left + screenX * (scene.right - scene.left) / W,
                scene.top + screenY * (scene.bottom - scene.top) / H
            );
        }

        Segment? currentSegment = null;
        bool isDragging = false;

        private void viewer_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos.Text = $"Mouse Position: X={e.X}, Y={e.Y}";

            if (isDragging && currentSegment != null)
            {
                (currentSegment.X2, currentSegment.Y2)=MouseToWorld(e.X, e.Y);
                segmentLabel.Text = currentSegment.ToString();
                viewer.Invalidate();
            }
        }

        private void viewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;

                currentSegment = new Segment();
                (currentSegment.X1, currentSegment.Y1) = MouseToWorld(e.X, e.Y);

                scene.Segments.Add(currentSegment);
            }
        }

        private void viewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDragging)
            {
                isDragging = false;

                if (currentSegment != null)
                {
                    (currentSegment.X2, currentSegment.Y2) = MouseToWorld(e.X, e.Y);
                    viewer.Invalidate(); // Refresh the viewer to show the line
                }
            }

        }
    }
}
