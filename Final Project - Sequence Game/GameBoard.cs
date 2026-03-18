namespace Final_Project___Sequence_Game;

/// <summary>
/// Represents the main game board form where players interact with the sequence game interface.
/// Manages the game grid, card array, and glow effect interactions for an interactive gaming experience.
/// </summary>
public partial class GameBoard : Form
{
    private bool _showGlowingCursor = false;

    // Original dimensions for scaling calculations (scaled down to 1440x900 base)
    private const int OriginalBoardWidth = 763;
    private const int OriginalBoardHeight = 721;
    private const int OriginalBoardX = 7;
    private const int OriginalBoardY = 8;
    private const int OriginalCardWidth = 86;
    private const int OriginalCardHeight = 141;
    private const int OriginalCardStartX = 776;
    private const int OriginalCardStartY = 751;
    private const int OriginalGlowX = 685;
    private const int OriginalGlowY = 78;
    private const int OriginalGlowWidth = 74;
    private const int OriginalGlowHeight = 64;
    private const int CardSpacing = 5;
    private const int BottomMargin = 8;
    private const float OriginalWidth = 1440f;
    private const float OriginalHeight = 900f;

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
    private float _scaleX = 1f;
    private float _scaleY = 1f;

    private static readonly string[,] CardArray = new string[10, 10]
    {
        { "FREE", "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "FREE" },
        { "6C", "5C", "4C", "3C", "2C", "AH", "KH", "QH", "10H", "10S" },
        { "7C", "AS", "2D", "3D", "4D", "5D", "6D", "7D", "9H", "QS" },
        { "8C", "KS", "6C", "5C", "4C", "3C", "2C", "8D", "8H", "KS" },
        { "9C", "QS", "7C", "6H", "5H", "4H", "AH", "9D", "7H", "AS" },
        { "10C", "10S", "8C", "7H", "2H", "3H", "KH", "10D", "6H", "2D" },
        { "QC", "9S", "9C", "8H", "9H", "10H", "QH", "QD", "5H", "3D" },
        { "KC", "8S", "10C", "QC", "KC", "AC", "AD", "KD", "4H", "4D" },
        { "AC", "7S", "6S", "5S", "4S", "3S", "2S", "2H", "3H", "5D" },
        { "FREE", "AD", "KD", "QD", "10D", "9D", "8D", "7D", "6D", "FREE" }
    };

    private string[,]? gameGrid;

    public GameBoard(string? PlayerUsername)
    {
        InitializeComponent();
        _handPictureBoxes = new[] { picHand0, picHand1, picHand2, picHand3, picHand4, picHand5, picHand6 };
        this.DoubleBuffered = true;
        AttachMouseMoveHandlers(this);
        this.Load += (_, _) => ScaleAllControls();
        this.Resize += (_, _) => ScaleAllControls();
        InitializeGlowEffect();
    }

    private void ScaleAllControls()
    {
        if (ClientSize.Width == 0 || ClientSize.Height == 0)
            return;

        _scaleX = ClientSize.Width / OriginalWidth;
        _scaleY = ClientSize.Height / OriginalHeight;

        ScaleBoardImage();
        LayoutHandPictureBoxes();
        ScaleGlowControl();
    }

    private void ScaleBoardImage()
    {
        int newBoardX = (int)Math.Round(OriginalBoardX * _scaleX);
        int newBoardY = (int)Math.Round(OriginalBoardY * _scaleY);
        int newBoardWidth = (int)Math.Round(OriginalBoardWidth * _scaleX);
        int newBoardHeight = (int)Math.Round(OriginalBoardHeight * _scaleY);

        picZoomedInBoard.Bounds = new Rectangle(newBoardX, newBoardY, newBoardWidth, newBoardHeight);
    }

    private void ScaleGlowControl()
    {
        foreach (Control control in Controls)
        {
            if (control is GlowRectangleControl glowControl)
            {
                int glowX = (int)Math.Round(OriginalGlowX * _scaleX);
                int glowY = (int)Math.Round(OriginalGlowY * _scaleY);
                int glowWidth = (int)Math.Round(OriginalGlowWidth * _scaleX);
                int glowHeight = (int)Math.Round(OriginalGlowHeight * _scaleY);
                glowControl.Bounds = new Rectangle(glowX, glowY, glowWidth, glowHeight);
                glowControl.Invalidate();
            }
        }
    }

    private void InitializeGlowEffect()
    {
        foreach (Control control in Controls)
        {
            if (control is GlowRectangleControl glowControl)
            {
                glowControl.GlowOpacity = 0;
                glowControl.MouseEnter += GlowControl_OnHoverEnter;
                glowControl.MouseLeave += GlowControl_OnHoverLeave;
            }
        }
    }

    private void GlowControl_OnHoverEnter(object? sender, EventArgs e)
    {
        if (sender is GlowRectangleControl glowControl)
        {
            glowControl.GlowOpacity = 255;
        }
    }

    private void GlowControl_OnHoverLeave(object? sender, EventArgs e)
    {
        if (sender is GlowRectangleControl glowControl)
        {
            glowControl.GlowOpacity = 0;
        }
    }

    private void LayoutHandPictureBoxes()
    {
        const int cardCount = 7;

        int scaledCardWidth = (int)Math.Round(OriginalCardWidth * _scaleX);
        int scaledCardHeight = (int)Math.Round(OriginalCardHeight * _scaleY);
        int scaledSpacing = (int)Math.Round(CardSpacing * _scaleX);
        int scaledStartX = (int)Math.Round(OriginalCardStartX * _scaleX);
        int scaledStartY = (int)Math.Round(OriginalCardStartY * _scaleY);

        for (var i = 0; i < _handPictureBoxes.Length; i++)
        {
            _handPictureBoxes[i].Bounds = new Rectangle(scaledStartX + (i * (scaledCardWidth + scaledSpacing)), scaledStartY, scaledCardWidth, scaledCardHeight);
            _handPictureBoxes[i].Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }
    }

    public void SetGlowBox(Rectangle rect)
    {
        _glow.Box = rect;
        Invalidate();
    }

    public void SetGlowBox(int x, int y, int width, int height)
    {
        SetGlowBox(new Rectangle(x, y, width, height));
    }

    private void picHand_Click(object? sender, EventArgs e)
    {
        if (sender is not PictureBox pb)
            return;

        if (pb.Image == null)
            return;

        var cardFiles = FindCardFiles();
        if (cardFiles == null || cardFiles.Length == 0)
            return;

        var rnd = new Random();

        string GetBoxImageKey(PictureBox box)
        {
            return box.Tag as string ?? string.Empty;
        }

        PictureBox[] hands = new PictureBox[] { picHand0, picHand1, picHand2, picHand3, picHand4, picHand5, picHand6 };

        var shuffled = cardFiles.OrderBy(x => rnd.Next()).ToArray();

        foreach (var file in shuffled)
        {
            var key = Path.GetFileNameWithoutExtension(file);

            int count = hands.Where(h => h != pb)
                             .Count(h => string.Equals(GetBoxImageKey(h), key, StringComparison.OrdinalIgnoreCase));

            if (count >= 2)
                continue;

            try
            {
                byte[] bytes = File.ReadAllBytes(file);
                using var ms = new MemoryStream(bytes);
                using var tmp = Image.FromStream(ms);
                var newImg = new Bitmap(tmp);

                var old = pb.Image;
                pb.Image = newImg;
                pb.Tag = key;
                old?.Dispose();

                break;
            }
            catch
            {
                continue;
            }
        }
    }

    public string[,] CreateGrid()
    {
        return new string[10, 10];
    }

    public string[,] GetGrid()
    {
        gameGrid ??= CreateGrid();
        return gameGrid;
    }

    public void SetGridValues()
    {
        string[,] grid = GetGrid();
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 10; col++)
            {
                grid[row, col] = CardArray[row, col];
            }
        }
    }

    public string[,] GetCardArray()
    {
        return CardArray;
    }

    private void AttachMouseMoveHandlers(Control parent)
    {
        parent.MouseMove += OnAnyMouseMove;
        foreach (Control c in parent.Controls)
        {
            AttachMouseMoveHandlers(c);
        }
    }

    private void OnAnyMouseMove(object? sender, MouseEventArgs e)
    {
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
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (!_showGlowingCursor)
            return;

        var g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        for (int i = 0; i < _glow.Layers; i++)
        {
            int penWidth = _glow.BorderThickness + i * 6;
            int alpha = Math.Max(0, 180 - i * 26);
            using (var pen = new Pen(Color.FromArgb(alpha, _glow.Color.R, _glow.Color.G, _glow.Color.B), penWidth))
            {
                pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                var r = _glow.Box;
                r.Inflate(penWidth / 2, penWidth / 2);
                g.DrawRectangle(pen, r);
            }
        }

        using (var inner = new Pen(Color.FromArgb(220, 255, 255, 255), 2))
        {
            g.DrawRectangle(inner, _glow.Box);
        }
    }

    private string[] FindCardFiles()
    {
        try
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var candidates = new List<string>();

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
