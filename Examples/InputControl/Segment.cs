using static OpenGL.GL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InputControl
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Segment
    {
        public double X1 { get; set; } = 0;
        public double Y1 { get; set; } = 0;
        public double X2 { get; set; } = 1;
        public double Y2 { get; set; } = 1;

        [Category("Зовнішній вигляд"), DisplayName("Товщина лінії")]
        [Description("Додатна товщина лінії в пікселях. Доступні значення залежать від драйвера OpenGL.")]
        public double Width { get; set; } = 2;

        [Category("Зовнішній вигляд"), DisplayName("Колір")]
        public Color Color { get; set; } = Color.White;

        public Segment() { }

        public Segment(double x1, double y1, double x2, double y2)
        {
            X1 = x1;    Y1 = y1;
            X2 = x2;    Y2 = y2;
        }

        override public string ToString()
        {
            return $"({X1:F2}, {Y1:F2})-({X2:F2}, {Y2:F2}), W={Width}, C={Color.Name}";
        }

        internal void Draw()
        {
            glLineWidth((float)Width);
            glColor3d(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0);

            glBegin(GL_LINES);
                glVertex2d(X1, Y1);
                glVertex2d(X2, Y2);
            glEnd();
        }
    }
}
