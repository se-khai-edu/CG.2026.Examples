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

        public double Width { get; set; } = 1;

        public Color Color { get; set; } = Color.White;

        public Segment() { }

        public Segment(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        override public string ToString()
        {
            return $"({X1}, {Y1})-({X2}, {Y2}), W={Width}, C={Color}";
        }
    }
}
