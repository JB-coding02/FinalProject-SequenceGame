using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Final_Project___Sequence_Game;

public class GlowRectangleControl : Control
{
    #region Control Setup
    #region Designer Properties
    // ============================================================
    //  BACK-END STATE (all variables and properties in one place)
    // ============================================================

    // Hover state
    private bool isHovered = false;

    // Glow area (hidden from designer serialization)
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle GlowArea { get; set; }

    // Glow opacity (0–255)
    private int glowOpacity = 180;
    [Description("Opacity of the outer glow (0-255).")]
    [Browsable(true)]
    [DefaultValue(180)]
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
    #endregion

    #region Core Logic
    // ============================================================
    //  CONSTRUCTOR
    // ============================================================

    public GlowRectangleControl()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.UserPaint |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor, true);

        BackColor = Color.Transparent;

        GlowArea = new Rectangle(0, 0, Width - 1, Height - 1);
    }

    // ============================================================
    //  LAYOUT / RESIZE
    // ============================================================

    protected override void OnResize(EventArgs e)
    {
        GlowArea = new Rectangle(0, 0, Width - 1, Height - 1);
        base.OnResize(e);
    }

    // ============================================================
    //  HOVER LOGIC
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
    #endregion

    #region Public Methods
    // ============================================================
    //  PAINTING
    // ============================================================

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        // Transparent center — do not paint background
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
    }
    #endregion
    #endregion
}