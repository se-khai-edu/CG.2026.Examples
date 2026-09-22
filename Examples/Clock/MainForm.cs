using static OpenGL.GL;

namespace Clock;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void glView1_Paint(object sender, PaintEventArgs e)
    {
        glClearColor(0.5f, 0.5f, 0.6f, 1);
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        glLoadIdentity();

        //glViewport(0, 0, Width, Height);
        glViewport(0, 0, glView1.Width, glView1.Height);
        glOrtho(-1.1, +1.1, -1.1, +1.1, -1, 1);

        glColor3d(1, 1, 1);
        DrawClockTable(60, 2);
        DrawClockTable(12, 6);
        DrawClockTable(4, 10);

        DateTime time = DateTime.Now;
        double h = time.Hour + time.Minute / 60.0;
        double m = time.Minute + time.Second / 60.0;
        double s = time.Second;

        DrawArrow(2, s, 60, 1.05);
        DrawArrow(5, m, 60, 0.9);
        DrawArrow(9, h, 12, 0.7);

    }

    private void DrawArrow(int width, double units, int N, double size)
    {
        glLineWidth(width);

        double dAngle = 2 * Math.PI / N;
        double x0 = 0.2 * size * Math.Sin(dAngle * units + Math.PI);
        double y0 = 0.2 * size * Math.Cos(dAngle * units + Math.PI);
        double x1 = size * Math.Sin(dAngle * units);
        double y1 = size * Math.Cos(dAngle * units);

        glBegin(GL_LINES);
        glVertex2d(x0, y0);
        glVertex2d(x1, y1);
        glEnd();
    }

    private void DrawClockTable(int nPoint, int ptSize)
    {
        glPointSize(ptSize);
        double dAngle = 2 * Math.PI / nPoint;
        glBegin(GL_POINTS);
        for (int i = 0; i < nPoint; i++)
        {
            double x = Math.Cos(i * dAngle);
            double y = Math.Sin(i * dAngle);
            glVertex2d(x, y);
        }
        glEnd();
    }

    private void tick_Tick(object sender, EventArgs e)
    {
        glView1.Invalidate();
    }
}
