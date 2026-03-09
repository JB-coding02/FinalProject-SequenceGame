using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace Final_Project___Sequence_Game;

public class GlowRectangleControl : Control
{
    #region Customize
    // ============================================================
    //  CUSTOMIZABLE PROPERTIES & SETTINGS
    //  Adjust these values to fine-tune the glow effect
    // ============================================================

    // Glow opacity (0–255)
    private int glowOpacity = 255;
    [Description("Opacity of the outer glow (0-255).")]
    [Browsable(true)]
    [DefaultValue(255)]
    public int GlowOpacity
    {
        get => glowOpacity;
        set
        {
            glowOpacity = Math.Max(0, Math.Min(255, value));
            Invalidate();
        }
    }

    // Glow color
    private Color glowColor = Color.Cyan;
    [Description("Color of the outer glow.")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color GlowColor
    {
        get => glowColor;
        set
        {
            glowColor = value;
            Invalidate();
        }
    }

    // Glow thickness
    private int glowThickness = 6;
    [Description("Thickness of the outer glow.")]
    [Browsable(true)]
    [DefaultValue(6)]
    public int GlowThickness
    {
        get => glowThickness;
        set
        {
            glowThickness = Math.Max(1, value);
            Invalidate();
        }
    }

    // Inner highlight thickness
    private int innerThickness = 2;
    [Description("Thickness of the inner highlight line.")]
    [Browsable(true)]
    [DefaultValue(2)]
    public int InnerThickness
    {
        get => innerThickness;
        set
        {
            innerThickness = Math.Max(1, value);
            Invalidate();
        }
    }

    // TEMPORARY: Debug positioning controls
    private bool debugMode = true; // Set to false to disable debug positioning
    #endregion

    #region Internal State
    // ============================================================
    //  INTERNAL STATE (not for customization)
    // ============================================================

    private bool isHovered = false;
    private bool isDragging = false;
    private Point dragStartPoint;
    private Point originalLocation;
    private Bitmap? cachedBackground = null;
    private bool backgroundCacheValid = false;
    private bool isCapturingBackground = false;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle GlowArea { get; set; }
    #endregion

    #region Initialization
    // ============================================================
    //  CONSTRUCTOR & SETUP
    // ============================================================

    public GlowRectangleControl()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.UserPaint |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.Selectable, true);

        BackColor = Color.Transparent;
        GlowArea = new Rectangle(0, 0, Width - 1, Height - 1);

        // TEMPORARY: Enable keyboard input for positioning
        this.TabStop = true;
    }

    protected override void OnResize(EventArgs e)
    {
        GlowArea = new Rectangle(0, 0, Width - 1, Height - 1);
        InvalidateBackgroundCache();
        base.OnResize(e);
    }

    protected override void OnLocationChanged(EventArgs e)
    {
        InvalidateBackgroundCache();
        base.OnLocationChanged(e);
    }

    protected override void OnParentChanged(EventArgs e)
    {
        InvalidateBackgroundCache();
        base.OnParentChanged(e);
    }

    private void InvalidateBackgroundCache()
    {
        backgroundCacheValid = false;
    }
    #endregion

    #region Event Handlers
    // ============================================================
    //  USER INTERACTION EVENTS
    // ============================================================

    protected override void OnMouseEnter(EventArgs e)
    {
        isHovered = true;
        Invalidate();
        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        isHovered = false;
        Invalidate();
        base.OnMouseLeave(e);
    }

    // TEMPORARY: Debug positioning with mouse drag
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (debugMode && e.Button == MouseButtons.Left)
        {
            isDragging = true;
            dragStartPoint = e.Location;
            originalLocation = this.Location;
            this.Cursor = Cursors.SizeAll;
            this.Focus();
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        if (debugMode && isDragging)
        {
            int deltaX = e.X - dragStartPoint.X;
            int deltaY = e.Y - dragStartPoint.Y;

            this.Location = new Point(originalLocation.X + deltaX, originalLocation.Y + deltaY);

            System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Dragging: X={this.Left}, Y={this.Top}");
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

        if (debugMode && isDragging)
        {
            isDragging = false;
            this.Cursor = Cursors.Default;

            System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Final Location: X={this.Left}, Y={this.Top}");
            System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Code: glowRectangleControl2.Location = new Point({this.Left}, {this.Top});");
        }
    }

    // TEMPORARY: Debug positioning with keyboard
    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);

        if (!debugMode) return;

        int step = e.Shift ? 10 : 1;
        bool moved = false;
        Point newLocation = this.Location;

        switch (e.KeyCode)
        {
            case Keys.Left:
                newLocation.X -= step;
                moved = true;
                break;
            case Keys.Right:
                newLocation.X += step;
                moved = true;
                break;
            case Keys.Up:
                newLocation.Y -= step;
                moved = true;
                break;
            case Keys.Down:
                newLocation.Y += step;
                moved = true;
                break;
            case Keys.R:
                System.Diagnostics.Debug.WriteLine("[GlowRectangle] Current Position Reset Command - current position will be new default");
                System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Code: glowRectangleControl2.Location = new Point({this.Left}, {this.Top});");
                e.Handled = true;
                return;
        }

        if (moved)
        {
            this.Location = newLocation;
            System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Location: X={this.Left}, Y={this.Top}");
            e.Handled = true;
        }
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        base.OnKeyUp(e);

        if (!debugMode) return;

        // Output final position when key is released
        if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || 
            e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
        {
            System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Final Location: X={this.Left}, Y={this.Top}");
            System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Code: glowRectangleControl2.Location = new Point({this.Left}, {this.Top});");
        }
    }
    #endregion

    #region Painting
    // ============================================================
    //  RENDERING LOGIC
    // ============================================================

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        if (isCapturingBackground)
        {
            // Don't try to capture background while already capturing
            base.OnPaintBackground(pevent);
            return;
        }

        if (Parent != null && BackColor == Color.Transparent)
        {
            if (!backgroundCacheValid || cachedBackground == null)
            {
                cachedBackground?.Dispose();
                cachedBackground = new Bitmap(Parent.Width, Parent.Height);
                
                isCapturingBackground = true;
                try
                {
                    Parent.DrawToBitmap(cachedBackground, new Rectangle(0, 0, Parent.Width, Parent.Height));
                    backgroundCacheValid = true;
                }
                finally
                {
                    isCapturingBackground = false;
                }
            }

            var graphics = pevent.Graphics;
            graphics.DrawImage(cachedBackground, 
                             new Rectangle(0, 0, Width, Height),
                             new Rectangle(Left, Top, Width, Height), 
                             GraphicsUnit.Pixel);
        }
        else
        {
            base.OnPaintBackground(pevent);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            cachedBackground?.Dispose();
            cachedBackground = null;
        }
        base.Dispose(disposing);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (!isHovered)
            return;

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Outer glow
        using (var glowPen = new Pen(Color.FromArgb(glowOpacity, glowColor), glowThickness))
        {
            e.Graphics.DrawRectangle(glowPen, GlowArea);
        }

        // Inner highlight
        using (var innerPen = new Pen(Color.FromArgb(glowOpacity / 2, glowColor), innerThickness))
        {
            Rectangle inner = Rectangle.Inflate(GlowArea, -glowThickness / 2, -glowThickness / 2);
            e.Graphics.DrawRectangle(innerPen, inner);
        }

        // TEMPORARY: Show positioning help when focused
        if (debugMode && this.Focused)
        {
            using (var helpBrush = new SolidBrush(Color.FromArgb(200, Color.White)))
            using (var font = new Font("Arial", 8))
            {
                string help = isDragging ? "Dragging..." : "Arrows: Move (Shift=Fast) | R: Output Code | Drag: Move";
                e.Graphics.DrawString(help, font, helpBrush, 5, 5);
            }
        }
    }
    #endregion

    #region Hidden Properties
    // ============================================================
    //  HIDE INHERITED PROPERTIES FROM DESIGNER
    // ============================================================

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Text
    {
        get => base.Text;
        set => base.Text = value;
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override Font Font
    {
        get => base.Font;
        set => base.Font = value;
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override Color ForeColor
    {
        get => base.ForeColor;
        set => base.ForeColor = value;
    }
    #endregion
}