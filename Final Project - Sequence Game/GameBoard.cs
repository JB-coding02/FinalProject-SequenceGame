using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Final_Project___Sequence_Game;

public partial class GameBoard : Form
{
    // State used for mouse hit-testing and custom cursor drawing
    private bool _showGlowingCursor = false;

    // Grouped configuration for the rectangular glow. Update these values
    // to customize trigger region, draw rectangle, thickness, layers and
    // base color in one place.
    private class GlowConfig
    {
        public Rectangle HitRegion { get; set; } = new Rectangle(29, 92, 86, 67);
        public Rectangle Box { get; set; } = new Rectangle(700, 200, 120, 80);
        public int BorderThickness { get; set; } = 4;
        public int Layers { get; set; } = 6;
        public Color Color { get; set; } = Color.FromArgb(0, 200, 255);
    }

    private GlowConfig _glow = new GlowConfig();

    public GameBoard(string? PlayerUsername)
    {
        InitializeComponent();
        // Reduce flicker when custom painting
        this.DoubleBuffered = true;
        // Attach MouseMove handlers to the form and all child controls so we can
        // perform hit-testing regardless of which control the mouse is over.
        AttachMouseMoveHandlers(this);
    }

    // Allow other code to change where the glowing box is drawn and its size
    public void SetGlowBox(Rectangle rect)
    {
        _glow.Box = rect;
        Invalidate();
    }

    public void SetGlowBox(int x, int y, int width, int height)
    {
        SetGlowBox(new Rectangle(x, y, width, height));
    }

    public string[,] CreateGrid()
    {
        string[,] grid = new string[10, 10];
        return grid;
    }

    public string[,] GetGrid()
    {
        string[,] gameGrid = CreateGrid();
        return gameGrid;
    }

    public void SetGridValues()
    {
        string[,] grid = GetGrid();
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 10; col++)
            {
                grid = GetCardArray();
            }
        }
    }

    // Recursively attach MouseMove to all controls so we get MouseMove events
    // even when the pointer is over child controls.
    private void AttachMouseMoveHandlers(Control parent)
    {
        parent.MouseMove += OnAnyMouseMove;
        foreach (Control c in parent.Controls)
        {
            AttachMouseMoveHandlers(c);
        }
    }

    // Centralized MouseMove handler which performs hit-testing against
    // `_hitRegion` (in form client coordinates). If the mouse enters or
    // leaves the region we flip `_showGlowingCursor` and call Invalidate()
    // so OnPaint will be called.
    private void OnAnyMouseMove(object? sender, MouseEventArgs e)
    {
        // Convert coordinates to form client coordinates if the event came
        // from a child control.
        Point pt;
        if (sender is Control c && c != this)
        {
            pt = c.PointToScreen(e.Location);
            pt = this.PointToClient(pt);
        }
        else
        {
            pt = e.Location;
        }

        bool hit = _glow.HitRegion.Contains(pt);
        if (hit != _showGlowingCursor)
        {
            _showGlowingCursor = hit;
            // When state changes request a repaint so the glow appears/disappears.
            Invalidate();
        }
    }

    // Override OnPaint so we can draw the custom glowing cursor when
    // `_showGlowingCursor` is true. We draw several translucent concentric
    // ellipses to simulate a soft glow and a small white core.
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (!_showGlowingCursor)
            return;

        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Draw layered rectangle strokes with increasing width and decreasing
        // alpha to simulate a soft rectangular glow around the configured box.
        for (int i = 0; i < _glow.Layers; i++)
        {
            int penWidth = _glow.BorderThickness + i * 6;
            int alpha = Math.Max(0, 180 - i * 26);
            using (var pen = new Pen(Color.FromArgb(alpha, _glow.Color.R, _glow.Color.G, _glow.Color.B), penWidth))
            {
                pen.LineJoin = LineJoin.Round;
                // Inflate so thicker pens draw outside the box boundary
                var r = _glow.Box;
                r.Inflate(penWidth / 2, penWidth / 2);
                g.DrawRectangle(pen, r);
            }
        }

        // Draw a sharp inner border (bright) to define the box edge.
        using (var inner = new Pen(Color.FromArgb(220, 255, 255, 255), 2))
        {
            g.DrawRectangle(inner, _glow.Box);
        }
    }

    public string[,] GetCardArray()
    {
        string[,] cardArray = new string[10, 10]
        {
        { "FREE", "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "FREE" },
        { "6C", "5C", "4C", "3C", "2C", "AH", "KH", "QH", "10H", "10S" },
        { "7C", "AS", "2D", "3D", "4D", "5D", "6D", "7D", "9H", "QS" },
        { "8C", "KS", "6C", "5C", "4C", "3C", "2C", "8D", "8H", "KS" },
        { "9C", "QS", "7C", "6H", "5H", "4H", "AH", "9D", "7H", "AS" },
        { "10C", "10S", "8C", "7H", "2H", "3H", "KH", "10D", "6H", "2D" },
        { "QC", "9S", "9C", "8H", "9H", "10H", "QH", "QD", "5H", "3D" },
        { "KC", "8S", "10C", "QC", "KC", "AC", "AD", "KD", "4H", "4D" },
        {  "AC", "7S", "6S", "5S", "4S", "3S", "2S", "2H", "3H", "5D" },
        {  "FREE", "AD", "KD", "QD", "10D", "9D", "8D", "7D", "6D", "FREE" }
        };
        return cardArray;
    }



}
