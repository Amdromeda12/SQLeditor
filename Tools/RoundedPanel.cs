using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SQLeditor.Tools
{
    public class RoundedPanel : Panel
    {
        // Properties for customization
        public int CornerRadius { get; set; } = 25; // Radius of the rounded corners
        public int BorderThickness { get; set; } = 2; // Thickness of the border
        public Color BorderColor { get; set; } = Color.Black; // Color of the border

        public RoundedPanel()
        {
            // Enable double buffering to reduce flicker
            this.DoubleBuffered = true;
            this.ResizeRedraw = true; // Redraw the panel when resized
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a graphics path to draw the rounded rectangle
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = CornerRadius;
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

                // Adjust the rectangle to account for the border thickness
                rect.Inflate(-BorderThickness, -BorderThickness);

                // Add arcs to create rounded corners
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Top-left corner
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Top-right corner
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Bottom-left corner
                path.CloseFigure();

                // Set the region of the panel to the rounded rectangle
                this.Region = new Region(path);

                // Draw the background with rounded corners
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Smooth edges
                    e.Graphics.FillPath(brush, path);
                }

                // Draw the border
                if (BorderThickness > 0)
                {
                    using (Pen pen = new Pen(BorderColor, BorderThickness))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }
    }
}