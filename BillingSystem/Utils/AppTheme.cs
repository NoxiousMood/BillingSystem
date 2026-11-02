using System.Drawing;

namespace BillingSystem.Utils
{
    public static class AppTheme
    {
        public static Color PrimaryColor { get; } = Color.FromArgb(24, 144, 255);      // Primary Blue
        public static Color SecondaryColor { get; } = Color.FromArgb(108, 117, 125);  // Dark Gray / Secondary
        public static Color SuccessColor { get; } = Color.FromArgb(40, 167, 69);      // Green
        public static Color DangerColor { get; } = Color.FromArgb(220, 53, 69);       // Red
        public static Color BackgroundColor { get; } = Color.FromArgb(245, 247, 250);  // Light Gray
        public static Color GridRowAlt { get; } = Color.FromArgb(240, 245, 255);        // Light Blue Row Accent
        public static Color InactiveRowColor { get; } = Color.FromArgb(255, 235, 235);  // Light Red
        public static Color ActiveRowColor { get; } = Color.FromArgb(235, 255, 235);    // Light Green
    }
}