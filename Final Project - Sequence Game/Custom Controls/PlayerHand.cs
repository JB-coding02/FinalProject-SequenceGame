using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Final_Project___Sequence_Game.Custom_Controls;

/// <summary>
/// Represents a control that displays and lays out a horizontal hand of card images.
/// </summary>
public class PlayerHand : Control
{
    /// <summary>
    /// The fixed card aspect ratio (width to height) used when sizing card slots.
    /// </summary>
    private const double CardAspectRatio = 2.5d / 3.5d;

    /// <summary>
    /// The internal collection of card picture boxes managed by this control.
    /// </summary>
    private readonly List<PictureBox> _cardPictureBoxes = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerHand"/> class.
    /// </summary>
    public PlayerHand()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        CardSpacing = 8;
    }

    /// <summary>
    /// Gets the read-only list of card picture boxes contained in the hand.
    /// </summary>
    public IReadOnlyList<PictureBox> CardPictureBoxes => _cardPictureBoxes;

    /// <summary>
    /// The horizontal spacing, in pixels, between adjacent card picture boxes.
    /// </summary>
    public int CardSpacing = 250;

    /// <summary>
    /// The number of cards represented by this hand.
    /// </summary>
    public int CardCount = 350;

    /// <summary>
    /// Sets the image for a card at the specified index.
    /// </summary>
    /// <param name="index">The zero-based card index.</param>
    /// <param name="image">The image to assign to the card slot.</param>
    public void SetCardImage(int index, Image? image)
    {
        if (index < 0 || index >= _cardPictureBoxes.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        _cardPictureBoxes[index].Image = image;
    }

    /// <summary>
    /// Sets all card images in the hand from the provided list.
    /// </summary>
    /// <param name="images">The ordered card images to display.</param>
    public void SetCardImages(IReadOnlyList<Image?> images)
    {
        if (images is null)
        {
            throw new ArgumentNullException(nameof(images));
        }

        CardCount = images.Count;

        for (var i = 0; i < images.Count; i++)
        {
            _cardPictureBoxes[i].Image = images[i];
        }
    }

    /// <summary>
    /// Updates card layout whenever the control performs layout.
    /// </summary>
    /// <param name="levent">The layout event data.</param>
    protected override void OnLayout(LayoutEventArgs levent)
    {
        base.OnLayout(levent);
        LayoutCards();
    }

    /// <summary>
    /// Calculates and applies bounds for each card picture box within the control.
    /// </summary>
    private void LayoutCards()
    {
        if (_cardPictureBoxes.Count == 0)
        {
            return;
        }

        var availableWidth = ClientSize.Width;
        var availableHeight = ClientSize.Height;

        if (availableWidth <= 0 || availableHeight <= 0)
        {
            return;
        }

        var totalSpacing = Math.Max(0, _cardPictureBoxes.Count - 1) * CardSpacing;
        var maxCardWidthByRow = (availableWidth - totalSpacing) / _cardPictureBoxes.Count;
        var maxCardHeightByContainer = availableHeight;

        var widthFromHeight = maxCardHeightByContainer * CardAspectRatio;
        var cardWidth = (int)Math.Floor(Math.Min(maxCardWidthByRow, widthFromHeight));

        if (cardWidth < 1)
        {
            cardWidth = 1;
        }

        var cardHeight = (int)Math.Floor(cardWidth / CardAspectRatio);

        if (cardHeight > availableHeight)
        {
            cardHeight = availableHeight;
            cardWidth = (int)Math.Floor(cardHeight * CardAspectRatio);
        }

        if (cardHeight < 1)
        {
            cardHeight = 1;
        }

        var usedWidth = (_cardPictureBoxes.Count * cardWidth) + totalSpacing;
        var startX = Math.Max(0, (availableWidth - usedWidth) / 2);
        var startY = Math.Max(0, (availableHeight - cardHeight) / 2);

        for (var i = 0; i < _cardPictureBoxes.Count; i++)
        {
            var x = startX + (i * (cardWidth + CardSpacing));
            _cardPictureBoxes[i].Bounds = new Rectangle(x, startY, cardWidth, cardHeight);
        }
    }
}
