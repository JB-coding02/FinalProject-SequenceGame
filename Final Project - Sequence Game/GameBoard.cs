using Final_Project___Sequence_Game.Classes;

namespace Final_Project___Sequence_Game;

/// <summary>
/// Represents the main game board form where players interact with the sequence game interface.
/// Manages the game grid, card array, and glow effect interactions for an interactive gaming experience.
/// </summary>
public partial class GameBoard : Form
{
    public GameBoard(string? PlayerUsername)
    {
        InitializeComponent();
        InitializeGlowEffect();
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
    }
}
