using static OpenGL.GL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;

namespace InputControl
{
    public class Scene
    {
        [Category("X Axis"), DisplayName("min")]
        public double left {  get; set; } = -1;
        [Category("X Axis"), DisplayName("max")]
        public double right { get; set; } = 3;
        [Category("Y Axis"), DisplayName("max")]
        public double top { get; set; } = 10;
        [Category("Y Axis"), DisplayName("min")]
        public double bottom { get; set; } = -30;
        [Category("Z Axis"), DisplayName("far")]
        public double far { get; set; } = -1;
        [Category("Z Axis"), DisplayName("near")]
        public double near { get; set; } = 1;

        public event EventHandler? SegmentChanged;

        internal void NotifySegmentChanged()
        {
            SegmentChanged?.Invoke(this, EventArgs.Empty);
        }

        [Category("Сцена"), DisplayName("Колір тла")]
        public Color Background { get; set; } = Color.DimGray;


        [Category("Сцена"), DisplayName("Відрізки")]
        [Description("Відкрийте редактор кнопкою …, щоб додати, видалити або змінити відрізки.")]
        [Editor(typeof(SegmentCollectionEditor), typeof(UITypeEditor))]
        public List<Segment> Segments { get; } = new List<Segment>();
        public void Draw()
        {
            glLineWidth(1);
            glLineStipple(2, 0xAAAA);
            glEnable(GL_LINE_STIPPLE);
                glBegin(GL_LINES);
                    glVertex2d(left, 0);
                    glVertex2d(right, 0);
                    glVertex2d(0, bottom);
                    glVertex2d(0, top);
                glEnd();
            glDisable(GL_LINE_STIPPLE);

            Segments.ForEach( seg => seg.Draw() );
        }
    }
}
