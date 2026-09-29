namespace Clock
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
            components = new System.ComponentModel.Container();
            glView1 = new OpenGL.glView();
            tick = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // glView1
            // 
            glView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            glView1.Location = new Point(12, 12);
            glView1.Name = "glView1";
            glView1.Size = new Size(760, 449);
            glView1.TabIndex = 0;
            glView1.Text = "glView1";
            glView1.RenderContextCreated += glView1_RenderContextCreated;
            glView1.Paint += glView1_Paint;
            // 
            // tick
            // 
            tick.Enabled = true;
            tick.Tick += tick_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 473);
            Controls.Add(glView1);
            MinimumSize = new Size(480, 480);
            Name = "MainForm";
            Text = "CLock";
            ResumeLayout(false);
        }

        #endregion

        private OpenGL.glView glView1;
        private System.Windows.Forms.Timer tick;
    }
}
