using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace Final_Project___Sequence_Game;

/// <summary>
/// Custom control for rendering a rectangular glow effect.
/// Provides smooth rendering with proper double-buffering and background caching.
/// </summary>
public class GlowRectangleControl : Control
{
    #region Customize
    // ============================================================
    //  CUSTOMIZABLE PROPERTIES & SETTINGS
    //  Adjust these values to fine-tune the glow effect
    // ============================================================

    /// <summary>Gets or sets the glow opacity (0-255).</summary>
    private int glowOpacity = 255;
    [Description("Opacity of the outer glow (0-255).")]
    [Browsable(true)]
    [DefaultValue(255)]
    public int GlowOpacity
    {
        get => glowOpacity;
        set
        {
            if (glowOpacity != value)  // Only invalidate if actually changed
            {
                glowOpacity = Math.Max(0, Math.Min(255, value));
                InvalidateWithBuffer();  // Invalidate parent too!
            }
        }
    }

    /// <summary>Gets or sets the glow color.</summary>
    private Color glowColor = Color.Cyan;
    [Description("Color of the outer glow.")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color GlowColor
    {
        get => glowColor;
        set
        {
            if (glowColor != value)
            {
                glowColor = value;
                InvalidateWithBuffer();
            }
        }
    }

    /// <summary>Gets or sets the glow thickness in pixels.</summary>
    private int glowThickness = 6;
    [Description("Thickness of the outer glow.")]
    [Browsable(true)]
    [DefaultValue(6)]
    public int GlowThickness
    {
        get => glowThickness;
        set
        {
            if (glowThickness != value)
            {
                glowThickness = Math.Max(1, value);
                InvalidateWithBuffer();
            }
        }
    }

    /// <summary>Gets or sets the inner highlight thickness in pixels.</summary>
    private int innerThickness = 2;
    [Description("Thickness of the inner highlight line.")]
    [Browsable(true)]
    [DefaultValue(2)]
    public int InnerThickness
    {
        get => innerThickness;
        set
        {
            if (innerThickness != value)
            {
                innerThickness = Math.Max(1, value);
                InvalidateWithBuffer();
            }
        }
    }

    /// <summary>Debug mode: allows positioning with mouse/keyboard.</summary>
    private bool debugMode = true;

    /// <summary>Background offset - shift the visible background in X and Y.</summary>
    private Point backgroundOffsetProperty = Point.Empty;
    [Description("Offset of the background image display (editable in designer).")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [DefaultValue(typeof(Point), "10, 45")]
    public Point BackgroundOffsetProperty
    {
        get => backgroundOffsetProperty;
        set
        {
            if (backgroundOffsetProperty != value)
            {
                backgroundOffsetProperty = value;
                backgroundOffset = value;
                InvalidateWithBuffer();
            }
        }
    }

    /// <summary>Offset scale ratio - multiplier for how offset affects the display.</summary>
    private float offsetScaleRatio = 1.0f;
    [Description("Scale ratio for background offset (1.0 = normal, higher = more offset effect).")]
    [Browsable(true)]
    [DefaultValue(1.0f)]
    public float OffsetScaleRatio
    {
        get => offsetScaleRatio;
        set
        {
            if (!offsetScaleRatio.Equals(value) && value > 0)
            {
                offsetScaleRatio = Math.Max(0.1f, value);
                InvalidateWithBuffer();
            }
        }
    }

    /// <summary>Drag speed multiplier (1.0 = normal, adjustable with Shift+MouseWheel)</summary>
    private float dragSpeedMultiplier = 1.0f;

    /// <summary>Offset adjustment speed (1 = normal, adjustable with Shift+PageUp/PageDown)</summary>
    private float offsetSpeedMultiplier = 1.0f;
    #endregion

    #region Internal State
    // ============================================================
    //  INTERNAL STATE (not for customization)
    // ============================================================

    private bool isHovered = false;
    private bool isDragging = false;
    private Point dragStartPoint;
    private Point originalLocation;
    private Point previousLocation;
    private Bitmap? cachedBackground = null;
    private bool backgroundCacheValid = false;
    private bool isCapturingBackground = false;
    private Point backgroundOffset = Point.Empty;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle GlowArea { get; set; }
    #endregion

    #region Initialization
    // ============================================================
    //  CONSTRUCTOR & SETUP
    // ============================================================

    /// <summary>Initializes a new instance of the GlowRectangleControl.</summary>
    public GlowRectangleControl()
    {
        // Enable optimized rendering
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |  // Critical for smooth rendering
                 ControlStyles.UserPaint |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.Selectable, true);

        BackColor = Color.Transparent;
        GlowArea = new Rectangle(0, 0, Width - 1, Height - 1);
        previousLocation = Location;
        this.TabStop = true;
    }

    /// <summary>Handles control resize events.</summary>
    protected override void OnResize(EventArgs e)
    {
        GlowArea = new Rectangle(0, 0, Width - 1, Height - 1);
        InvalidateBackgroundCache();
        base.OnResize(e);
    }

    /// <summary>Handles location change events and invalidates affected areas.</summary>
    protected override void OnLocationChanged(EventArgs e)
    {
        // Invalidate old position (with padding for glow)
        int padding = glowThickness + 10;
        var oldRect = new Rectangle(
            previousLocation.X - padding,
            previousLocation.Y - padding,
            Width + (padding * 2),
            Height + (padding * 2));

        if (Parent != null)
        {
            Parent.Invalidate(oldRect);  // Clear old trails!
        }

        // Invalidate new position
        var newRect = new Rectangle(
            Location.X - padding,
            Location.Y - padding,
            Width + (padding * 2),
            Height + (padding * 2));

        if (Parent != null)
        {
            Parent.Invalidate(newRect);
        }

        previousLocation = Location;
        base.OnLocationChanged(e);
    }

    /// <summary>Handles parent control changes.</summary>
    protected override void OnParentChanged(EventArgs e)
    {
        InvalidateBackgroundCache();
        base.OnParentChanged(e);
    }

    /// <summary>Invalidates the cached background.</summary>
    private void InvalidateBackgroundCache()
    {
        backgroundCacheValid = false;
    }

    /// <summary>Invalidates this control and its buffer for smooth rendering.</summary>
    private void InvalidateWithBuffer()
    {
        Invalidate();
        if (Parent != null)
        {
            Parent.Invalidate();  // Clear parent too!
        }
    }
    #endregion

    #region Event Handlers
    // ============================================================
    //  USER INTERACTION EVENTS
    // ============================================================

    /// <summary>Handles mouse enter event.</summary>
    protected override void OnMouseEnter(EventArgs e)
    {
        isHovered = true;
        InvalidateWithBuffer();
        base.OnMouseEnter(e);
    }

    /// <summary>Handles mouse leave event.</summary>
    protected override void OnMouseLeave(EventArgs e)
    {
        isHovered = false;
        InvalidateWithBuffer();
        base.OnMouseLeave(e);
    }

    /// <summary>Handles focus gained event.</summary>
    protected override void OnGotFocus(EventArgs e)
    {
        InvalidateWithBuffer();
        base.OnGotFocus(e);
    }

    /// <summary>Handles focus lost event.</summary>
    protected override void OnLostFocus(EventArgs e)
    {
        InvalidateWithBuffer();
        base.OnLostFocus(e);
    }

    /// <summary>Handles mouse down for dragging control.</summary>
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (e.Button == MouseButtons.Left)
        {
            this.Focus();

            if (debugMode)
            {
                isDragging = true;
                dragStartPoint = e.Location;
                originalLocation = this.Location;
                this.Cursor = Cursors.SizeAll;
            }
        }
    }

    /// <summary>Handles mouse move for smooth dragging.</summary>
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        if (debugMode && isDragging)
        {
            float deltaX = (e.X - dragStartPoint.X) * dragSpeedMultiplier;
            float deltaY = (e.Y - dragStartPoint.Y) * dragSpeedMultiplier;

            // Update location - OnLocationChanged will handle invalidation
            this.Location = new Point((int)Math.Round(originalLocation.X + deltaX), (int)Math.Round(originalLocation.Y + deltaY));
        }
    }

    /// <summary>Handles mouse up to end dragging.</summary>
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

        if (debugMode && isDragging)
        {
            isDragging = false;
            this.Cursor = Cursors.Default;

            System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Final Location: X={this.Left}, Y={this.Top}");
            System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Code: glowRectangleControl.Location = new Point({this.Left}, {this.Top});");
        }
        else if (isDragging)
        {
            isDragging = false;
            this.Cursor = Cursors.Default;
        }
    }

    /// <summary>Handles mouse wheel for adjusting drag speed when Shift is held.</summary>
    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);

        if (debugMode && ModifierKeys == Keys.Shift)
        {
            const float speedDelta = 0.1f;
            const float minSpeed = 0.1f;
            const float maxSpeed = 5.0f;

            dragSpeedMultiplier += e.Delta > 0 ? speedDelta : -speedDelta;
            dragSpeedMultiplier = Math.Max(minSpeed, Math.Min(maxSpeed, dragSpeedMultiplier));

            System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Drag Speed Multiplier: {dragSpeedMultiplier:F2}x");
        }
    }

    /// <summary>Identifies input keys for arrow key handling.</summary>
    protected override bool IsInputKey(Keys keyData)
    {
        switch (keyData)
        {
            case Keys.Left:
            case Keys.Right:
            case Keys.Up:
            case Keys.Down:
            case Keys.Shift | Keys.Left:
            case Keys.Shift | Keys.Right:
            case Keys.Shift | Keys.Up:
            case Keys.Shift | Keys.Down:
                return true;
        }
        return base.IsInputKey(keyData);
    }

    /// <summary>Handles keyboard input for positioning (debug mode).</summary>
    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);

        if (!debugMode) return;

        // Handle offset speed adjustment with Shift+PageUp/PageDown
        if (e.Shift && (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown))
        {
            const float speedDelta = 0.1f;
            const float minSpeed = 0.1f;
            const float maxSpeed = 5.0f;

            offsetSpeedMultiplier += e.KeyCode == Keys.PageUp ? speedDelta : -speedDelta;
            offsetSpeedMultiplier = Math.Max(minSpeed, Math.Min(maxSpeed, offsetSpeedMultiplier));

            System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Offset Speed Multiplier: {offsetSpeedMultiplier:F2}x");
            e.Handled = true;
            return;
        }

        int step = (int)Math.Round(1 * offsetSpeedMultiplier);
        if (step < 1) step = 1;

        bool moved = false;

        switch (e.KeyCode)
        {
            case Keys.Left:
                backgroundOffset.X -= step;
                moved = true;
                break;
            case Keys.Right:
                backgroundOffset.X += step;
                moved = true;
                break;
            case Keys.Up:
                backgroundOffset.Y -= step;
                moved = true;
                break;
            case Keys.Down:
                backgroundOffset.Y += step;
                moved = true;
                break;
            case Keys.R:
                System.Diagnostics.Debug.WriteLine("[GlowRectangle] Current Background Offset");
                System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Code: backgroundOffset = new Point({backgroundOffset.X}, {backgroundOffset.Y});");
                e.Handled = true;
                return;
        }

        if (moved)
        {
            InvalidateWithBuffer();
            System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Background Offset: X={backgroundOffset.X}, Y={backgroundOffset.Y}");
            e.Handled = true;
        }
    }

    /// <summary>Handles keyboard key up events.</summary>
    protected override void OnKeyUp(KeyEventArgs e)
    {
        base.OnKeyUp(e);

        if (!debugMode) return;

        if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
            e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
        {
            System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Final Background Offset: X={backgroundOffset.X}, Y={backgroundOffset.Y}");
            System.Diagnostics.Debug.WriteLine($"[GlowRectangle] Code: backgroundOffset = new Point({backgroundOffset.X}, {backgroundOffset.Y});");
        }
    }
    #endregion

    #region Painting
    // ============================================================
    //  RENDERING LOGIC - OPTIMIZED FOR SMOOTH MOVEMENT
    // ============================================================

    /// <summary>Paints the background with caching for transparency support.</summary>
    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        if (isCapturingBackground)
        {
            // During capture, just use default background to avoid recursion
            pevent.Graphics.Clear(Color.Transparent);
            return;
        }

        // For transparent background, draw the parent's content
        if (Parent != null && BackColor == Color.Transparent)
        {
            // Only recapture background if cache is invalid (location change, resize, etc.)
            if (!backgroundCacheValid || cachedBackground == null)
            {
                cachedBackground?.Dispose();

                // Create a bitmap of the entire parent to capture all controls
                cachedBackground = new Bitmap(Parent.Width, Parent.Height);

                isCapturingBackground = true;
                try
                {
                    // Draw parent to bitmap - this captures all controls including the board
                    Parent.DrawToBitmap(cachedBackground, new Rectangle(0, 0, Parent.Width, Parent.Height));
                    backgroundCacheValid = true;
                }
                finally
                {
                    isCapturingBackground = false;
                }
            }

            // Draw the cached background at this control's position with offset applied
            if (cachedBackground != null)
            {
                // Calculate source rectangle with offset and scale ratio applied
                int scaledOffsetX = (int)Math.Round(backgroundOffset.X * offsetScaleRatio);
                int scaledOffsetY = (int)Math.Round(backgroundOffset.Y * offsetScaleRatio);

                int sourceX = Left + scaledOffsetX;
                int sourceY = Top + scaledOffsetY;

                // Ensure we don't read outside the bitmap bounds
                int clampedSourceX = Math.Max(0, Math.Min(sourceX, cachedBackground.Width - Width));
                int clampedSourceY = Math.Max(0, Math.Min(sourceY, cachedBackground.Height - Height));

                pevent.Graphics.DrawImage(cachedBackground,
                    new Rectangle(0, 0, Width, Height),
                    new Rectangle(clampedSourceX, clampedSourceY, Width, Height),
                    GraphicsUnit.Pixel);
            }
            else
            {
                // Fallback if cache is null
                pevent.Graphics.Clear(Color.Transparent);
            }
        }
        else
        {
            // Non-transparent background
            base.OnPaintBackground(pevent);
        }
    }

    /// <summary>Main paint method for rendering the glow effect.</summary>
    protected override void OnPaint(PaintEventArgs e)
    {
        // Don't call base.OnPaint here - we handle our own painting
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Draw glow effect when hovering
        if (isHovered)
        {
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
        }
        else if (this.Focused && debugMode)
        {
            // Show focus indicator in debug mode
            using (var focusPen = new Pen(Color.FromArgb(128, Color.Yellow), 2))
            {
                focusPen.DashStyle = DashStyle.Dash;
                e.Graphics.DrawRectangle(focusPen, GlowArea);
            }
        }

        // Show positioning help when focused (debug mode)
        if (debugMode && this.Focused)
        {
            using (var helpBrush = new SolidBrush(Color.FromArgb(200, Color.White)))
            using (var font = new Font("Arial", 8))
            {
                string help = isDragging
                    ? "Dragging Control..."
                    : $"Drag: Move | Arrows: Adjust | R: Output";
                e.Graphics.DrawString(help, font, helpBrush, 5, 5);
            }
        }
    }

    /// <summary>Cleans up resources.</summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            cachedBackground?.Dispose();
            cachedBackground = null;
        }
        base.Dispose(disposing);
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