namespace Final_Project___Sequence_Game;

/// <summary>
/// Represents the main game board form where players interact with the sequence game interface.
/// Manages the game grid, card array, and glow effect interactions for an interactive gaming experience.
/// </summary>
public partial class GameBoard : Form
{
    // true when glow cursor should be shown
    private bool _showGlowingCursor = false;

    // Settings for the glow box (hit area, draw box, look)
    private class GlowConfig
    {
        public Rectangle HitRegion { get; set; } = new Rectangle(29, 92, 86, 67);
        public Rectangle Box { get; set; } = new Rectangle(700, 200, 120, 80);
        public int BorderThickness { get; set; } = 4;
        public int Layers { get; set; } = 6;
        public Color Color { get; set; } = Color.FromArgb(0, 200, 255);
    }

    private GlowConfig _glow = new GlowConfig();

    private readonly PictureBox[] _handPictureBoxes;

    public GameBoard(string? PlayerUsername)
    {
        InitializeComponent();
        _handPictureBoxes = new[] { picHand0, picHand1, picHand2, picHand3, picHand4, picHand5, picHand6 };
        // Turn on double buffering to reduce flicker
        this.DoubleBuffered = true;
        // Make sure we get mouse move events from all child controls
        AttachMouseMoveHandlers(this);
        Resize += (_, _) => LayoutHandPictureBoxes();
        LayoutHandPictureBoxes();
    }

    private void LayoutHandPictureBoxes()
    {
        const int cardCount = 7;
        const int bottomMargin = 12;
        const int sideMargin = 12;
        const int spacing = 12;
        const int maxCardWidth = 140;

        var availableWidth = ClientSize.Width - (sideMargin * 2);
        if (availableWidth <= 0)
        {
            if (control is GlowRectangleControl glowControl)
            {
                glowControl.GlowOpacity = 0;
                glowControl.MouseEnter += GlowControl_OnHoverEnter;
                glowControl.MouseLeave += GlowControl_OnHoverLeave;
            }
        }
            return;
        }

        var cardWidth = Math.Min(maxCardWidth, (availableWidth - (spacing * (cardCount - 1))) / cardCount);
        if (cardWidth < 1)
        {
            cardWidth = 1;
        }

        var cardHeight = (int)Math.Round(cardWidth * 1.4);
        var maxHeight = ClientSize.Height - bottomMargin;
        if (cardHeight > maxHeight)
        {
            cardHeight = Math.Max(1, maxHeight);
            cardWidth = Math.Max(1, (int)Math.Round(cardHeight / 1.4));
        }

        var totalWidth = (cardWidth * cardCount) + (spacing * (cardCount - 1));
        var startX = Math.Max(0, (ClientSize.Width - totalWidth) / 2);
        var y = Math.Max(0, ClientSize.Height - cardHeight - bottomMargin);

        for (var i = 0; i < _handPictureBoxes.Length; i++)
        {
            _handPictureBoxes[i].Bounds = new Rectangle(startX + (i * (cardWidth + spacing)), y, cardWidth, cardHeight);
            _handPictureBoxes[i].Anchor = AnchorStyles.Bottom;
        }
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

    /// <summary>
    /// Handles the mouse enter event for glow rectangle controls.
    /// Increases the glow opacity to 255 when the mouse enters the control region.
    /// </summary>
    /// <param name="sender">The GlowRectangleControl that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    private void GlowControl_OnHoverEnter(object? sender, EventArgs e)
    {
        if (sender is GlowRectangleControl glowControl)
        {
            glowControl.GlowOpacity = 255;
        }
    // When a hand picture is clicked, pick a random card image and show it.
    // Do not pick an image if two copies already exist in the other hand boxes.
    private void picHand_Click(object? sender, EventArgs e)
    {
        if (sender is not PictureBox pb)
            return;

        // Only run if the clicked box has an image
        if (pb.Image == null)
            return;

        var cardFiles = FindCardFiles();
        if (cardFiles == null || cardFiles.Length == 0)
            return; // no images available (user asked to ignore missing images for now)

        var rnd = new Random();

        // Get image key from the Tag
        string GetBoxImageKey(PictureBox box)
        {
            return box.Tag as string ?? string.Empty;
        }

        // Get all hand picture boxes
        PictureBox[] hands = new PictureBox[] { picHand0, picHand1, picHand2, picHand3, picHand4, picHand5, picHand6 };

        // Shuffle files
        var shuffled = cardFiles.OrderBy(x => rnd.Next()).ToArray();

        foreach (var file in shuffled)
        {
            var key = Path.GetFileNameWithoutExtension(file);

            // Count occurrences in other hand boxes (exclude clicked)
            int count = hands.Where(h => h != pb)
                             .Count(h => string.Equals(GetBoxImageKey(h), key, StringComparison.OrdinalIgnoreCase));

            // Allow at most 2 total copies. If already 2 or more, skip
            if (count >= 2)
                continue; // skip this candidate

            try
            {
                // Load image into memory
                byte[] bytes = File.ReadAllBytes(file);
                using var ms = new MemoryStream(bytes);
                using var tmp = Image.FromStream(ms);
                var newImg = new Bitmap(tmp);

                // Dispose old image
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

    /// <summary>
    /// Handles the mouse leave event for glow rectangle controls.
    /// Decreases the glow opacity to 0 when the mouse leaves the control region.
    /// </summary>
    /// <param name="sender">The GlowRectangleControl that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    private void GlowControl_OnHoverLeave(object? sender, EventArgs e)
    {
        if (sender is GlowRectangleControl glowControl)
        {
            glowControl.GlowOpacity = 0;
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

    // Attach MouseMove to all child controls so we always get mouse events
    private void AttachMouseMoveHandlers(Control parent)
    {
        parent.MouseMove += OnAnyMouseMove;
        foreach (Control c in parent.Controls)
        {
            AttachMouseMoveHandlers(c);
        }
    }

    // Handle mouse moves. Check if pointer is inside the glow area and repaint.
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

    // Draw the glow when _showGlowingCursor is true.
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (!_showGlowingCursor)
            return;

        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Draw layered glow rectangles.
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

        // Draw inner border to show the box edge.
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
