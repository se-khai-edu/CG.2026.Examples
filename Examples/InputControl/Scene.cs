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
        public event EventHandler? SegmentChanged;

        internal void NotifySegmentChanged()
        {
            SegmentChanged?.Invoke(this, EventArgs.Empty);
        }

        public Color Background { get; set; } = Color.DarkGray;
        [Editor(typeof(SegmentCollectionEditor), typeof(UITypeEditor))]
        public List<Segment> Segments { get; } = new List<Segment>();

    }
}
