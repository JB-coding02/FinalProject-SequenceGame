using System.Drawing.Drawing2D;
using Final_Project___Sequence_Game.Classes;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

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

    // Click handler for hand picture boxes. Replaces the clicked picture with a random
    // card image from Images/CardsForHand so long as there aren't already two of that
    // image among the other hand picture boxes.
    private void picHand_Click(object? sender, EventArgs e)
    {
        if (sender is not PictureBox pb)
            return;

        // Only operate if the picture box currently has an image (per your request)
        if (pb.Image == null)
            return;

        var cardFiles = FindCardFiles();
        if (cardFiles == null || cardFiles.Length == 0)
            return; // no images available (user asked to ignore missing images for now)

        var rnd = new Random();

        // Helper to get the current tag/name of a picture box image
        string GetBoxImageKey(PictureBox box)
        {
            return box.Tag as string ?? string.Empty;
        }

        // Get all hand picture boxes
        PictureBox[] hands = new PictureBox[] { picHand0, picHand1, picHand2, picHand3, picHand4, picHand5, picHand6 };

        // Shuffle candidate files
        var shuffled = cardFiles.OrderBy(x => rnd.Next()).ToArray();

        foreach (var file in shuffled)
        {
            var key = Path.GetFileNameWithoutExtension(file);

            // Count occurrences among other hand boxes (exclude the clicked one)
            int count = hands.Where(h => h != pb)
                             .Count(h => string.Equals(GetBoxImageKey(h), key, StringComparison.OrdinalIgnoreCase));

            // Allow up to 1 occurrence already (so max 2 including new), per user's request
            if (count >= 2)
                continue; // skip this candidate

            try
            {
                // Load image into memory to avoid locking the file
                byte[] bytes = File.ReadAllBytes(file);
                using var ms = new MemoryStream(bytes);
                using var tmp = Image.FromStream(ms);
                var newImg = new Bitmap(tmp);

                // Dispose existing image to avoid leaks
                var old = pb.Image;
                pb.Image = newImg;
                pb.Tag = key;
                old?.Dispose();

                break; // applied one image
            }
            catch
            {
                // Ignore load errors and try next file
                continue;
            }
        }
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

    // Search for card image files in a "CardsForHand" folder located under typical relative paths.
    private string[] FindCardFiles()
    {
        try
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var candidates = new List<string>();

            // Try several relative locations up to two parent directories to be resilient in both IDE and published runs
            var relativePaths = new[]
            {
                Path.Combine("Images", "CardsForHand"),
                Path.Combine("..", "Images", "CardsForHand"),
                Path.Combine("..", "..", "Images", "CardsForHand"),
                Path.Combine("..", "..", "..", "Images", "CardsForHand")
            };

            foreach (var rel in relativePaths)
            {
                var full = Path.GetFullPath(Path.Combine(baseDir, rel));
                if (Directory.Exists(full))
                {
                    candidates.Add(full);
                }
            }

            // Also check if an Images folder exists next to the executable
            var alt = Path.Combine(baseDir, "Images", "CardsForHand");
            if (Directory.Exists(alt) && !candidates.Contains(alt))
                candidates.Add(alt);

            var exts = new[] { "*.png", "*.jpg", "*.jpeg", "*.bmp", "*.gif" };
            var results = new List<string>();
            foreach (var dir in candidates)
            {
                foreach (var ext in exts)
                {
                    try
                    {
                        results.AddRange(Directory.GetFiles(dir, ext, SearchOption.TopDirectoryOnly));
                    }
                    catch { }
                }
            }

            return results.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
        }
        catch
        {
            return Array.Empty<string>();
        }
    }
}
