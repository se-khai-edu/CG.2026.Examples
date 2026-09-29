namespace InputControl
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            status = new StatusStrip();
            mousePos = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            viewer = new OpenGL.glView();
            segmentLabel = new ToolStripStatusLabel();
            status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // status
            // 
            status.Items.AddRange(new ToolStripItem[] { mousePos, segmentLabel });
            status.Location = new Point(0, 428);
            status.Name = "status";
            status.Size = new Size(800, 22);
            status.TabIndex = 0;
            status.Text = "statusStrip1";
            // 
            // mousePos
            // 
            mousePos.Name = "mousePos";
            mousePos.Size = new Size(118, 17);
            mousePos.Text = "toolStripStatusLabel1";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(viewer);
            splitContainer1.Size = new Size(800, 428);
            splitContainer1.SplitterDistance = 622;
            splitContainer1.TabIndex = 1;
            // 
            // viewer
            // 
            viewer.Cursor = Cursors.Cross;
            viewer.Dock = DockStyle.Fill;
            viewer.Location = new Point(0, 0);
            viewer.Name = "viewer";
            viewer.Size = new Size(622, 428);
            viewer.TabIndex = 0;
            viewer.Text = "glView1";
            viewer.Paint += viewer_Paint;
            viewer.MouseDown += viewer_MouseDown;
            viewer.MouseMove += viewer_MouseMove;
            viewer.MouseUp += viewer_MouseUp;
            // 
            // segmentLabel
            // 
            segmentLabel.Name = "segmentLabel";
            segmentLabel.Size = new Size(118, 17);
            segmentLabel.Text = "toolStripStatusLabel1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(status);
            Name = "MainForm";
            Text = "Form1";
            status.ResumeLayout(false);
            status.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip status;
        private SplitContainer splitContainer1;
        private OpenGL.glView viewer;
        private ToolStripStatusLabel mousePos;
        private ToolStripStatusLabel segmentLabel;
    }
}
