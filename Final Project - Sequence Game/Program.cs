namespace Final_Project___Sequence_Game;

internal static class Program
{
    /// <summary>
    /// The entry point for the Sequence Game application.
    /// Initializes the Windows Forms application framework and launches the main menu form.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainMenu());
    }
}