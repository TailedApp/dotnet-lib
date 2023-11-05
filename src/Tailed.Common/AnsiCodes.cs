using System;
using System.Text.Json.Serialization;

namespace Tailed.Common
{
    /// <summary>
    /// Code that defines ANSI codes for different colors, and translates between
    /// ANSI colors and standard .NET ConsoleColor values.
    /// </summary>
    public static class AnsiCodes
    {
        /// <summary>
        /// Defines whether a color is being used in the foreground or background.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ColorPosition
        {
            Foreground,
            Background
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Colors
        {
            Default,
            Black,
            Red,
            Green,
            Yellow,
            Blue,
            Magenta,
            Cyan,
            White,
            BrightBlack,
            BrightRed,
            BrightGreen,
            BrightYellow,
            BrightBlue,
            BrightMagenta,
            BrightCyan,
            BrightWhite
        }

        public static string DefaultForeground = "\x1b[39m";
        public static string DefaultBackground = "\x1b[49m";
        
        public static string BlackForeground = "\x1b[30m";
        public static string RedForeground = "\x1b[31m";
        public static string GreenForeground = "\x1b[32m";
        public static string YellowForeground = "\x1b[33m";
        public static string BlueForeground = "\x1b[34m";
        public static string MagentaForeground = "\x1b[35m";
        public static string CyanForeground = "\x1b[36m";
        public static string WhiteForeground = "\x1b[37m";

        public static string BlackBackground = "\x1b[40m";
        public static string RedBackground = "\x1b[41m";
        public static string GreenBackground = "\x1b[42m";
        public static string YellowBackground = "\x1b[43m";
        public static string BlueBackground = "\x1b[44m";
        public static string MagentaBackground = "\x1b[45m";
        public static string CyanBackground = "\x1b[46m";
        public static string WhiteBackground = "\x1b[47m";

        public static string BrightBlackForeground = "\x1b[90m";
        public static string BrightRedForeground = "\x1b[91m";
        public static string BrightGreenForeground = "\x1b[92m";
        public static string BrightYellowForeground = "\x1b[93m";
        public static string BrightBlueForeground = "\x1b[94m";
        public static string BrightMagentaForeground = "\x1b[95m";
        public static string BrightCyanForeground = "\x1b[96m";
        public static string BrightWhiteForeground = "\x1b[97m";

        public static string BrightBlackBackground = "\x1b[100m";
        public static string BrightRedBackground = "\x1b[101m";
        public static string BrightGreenBackground = "\x1b[102m";
        public static string BrightYellowBackground = "\x1b[103m";
        public static string BrightBlueBackground = "\x1b[104m";
        public static string BrightMagentaBackground = "\x1b[105m";
        public static string BrightCyanBackground = "\x1b[106m";
        public static string BrightWhiteBackground = "\x1b[107m";

        /// <summary>
        /// Translates a ConsoleColor value to an ANSI code.
        /// </summary>
        /// <param name="position">Whether the color is being used in the foreground or background.</param>
        /// <param name="color">The color.</param>
        /// <returns>The ANSI control codes.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static string ColorToAnsi(ColorPosition position, ConsoleColor color)
        {
            if (position == ColorPosition.Foreground)
            {
                if ((int) color == -1)
                {
                    return DefaultForeground;
                }
                
                switch (color)
                {
                    case ConsoleColor.Black:
                        return BlackForeground;
                    case ConsoleColor.DarkRed:
                        return RedForeground;
                    case ConsoleColor.DarkGreen:
                        return GreenForeground;
                    case ConsoleColor.DarkYellow:
                        return YellowForeground;
                    case ConsoleColor.DarkBlue:
                        return BlueForeground;
                    case ConsoleColor.DarkMagenta:
                        return MagentaForeground;
                    case ConsoleColor.DarkCyan:
                        return CyanForeground;
                    case ConsoleColor.DarkGray:
                        return BrightBlackForeground;
                    case ConsoleColor.Gray:
                        return WhiteForeground;
                    case ConsoleColor.Red:
                        return BrightRedForeground;
                    case ConsoleColor.Green:
                        return BrightGreenForeground;
                    case ConsoleColor.Yellow:
                        return BrightYellowForeground;
                    case ConsoleColor.Blue:
                        return BrightBlueForeground;
                    case ConsoleColor.Magenta:
                        return BrightMagentaForeground;
                    case ConsoleColor.Cyan:
                        return BrightCyanForeground;
                    case ConsoleColor.White: 
                        return BrightWhiteForeground;
                }
            }
            else
            {
                if ((int) color == -1)
                {
                    return DefaultBackground;
                }
                
                switch (color)
                {
                    case ConsoleColor.Black:
                        return BlackBackground;
                    case ConsoleColor.DarkRed:
                        return RedBackground;
                    case ConsoleColor.DarkGreen:
                        return GreenBackground;
                    case ConsoleColor.DarkYellow:
                        return YellowBackground;
                    case ConsoleColor.DarkBlue:
                        return BlueBackground;
                    case ConsoleColor.DarkMagenta:
                        return MagentaBackground;
                    case ConsoleColor.DarkCyan:
                        return CyanBackground;
                    case ConsoleColor.DarkGray:
                        return BrightBlackBackground;
                    case ConsoleColor.Gray:
                        return WhiteBackground;
                    case ConsoleColor.Red:
                        return BrightRedBackground;
                    case ConsoleColor.Green:
                        return BrightGreenBackground;
                    case ConsoleColor.Yellow:
                        return BrightYellowBackground;
                    case ConsoleColor.Blue:
                        return BrightBlueBackground;
                    case ConsoleColor.Magenta:
                        return BrightMagentaBackground;
                    case ConsoleColor.Cyan:
                        return BrightCyanBackground;
                    case ConsoleColor.White:
                        return BrightWhiteBackground;
                }
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Translates a Colors value to an ANSI code.
        /// </summary>
        /// <param name="position">Whether the color is being used in the foreground or background.</param>
        /// <param name="color">The color.</param>
        /// <returns>The ANSI control codes.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static string ColorToAnsi(ColorPosition position, Colors color)
        {
            if (position == ColorPosition.Foreground)
            {
                switch (color)
                {
                    case Colors.Default:
                        return DefaultForeground;
                    case Colors.Black:
                        return BlackForeground;
                    case Colors.Red:
                        return RedForeground;
                    case Colors.Green:
                        return GreenForeground;
                    case Colors.Yellow:
                        return YellowForeground;
                    case Colors.Blue:
                        return BlueForeground;
                    case Colors.Magenta:
                        return MagentaForeground;
                    case Colors.Cyan:
                        return CyanForeground;
                    case Colors.BrightBlack:
                        return BrightBlackForeground;
                    case Colors.White:
                        return WhiteForeground;
                    case Colors.BrightRed:
                        return BrightRedForeground;
                    case Colors.BrightGreen:
                        return BrightGreenForeground;
                    case Colors.BrightYellow:
                        return BrightYellowForeground;
                    case Colors.BrightBlue:
                        return BrightBlueForeground;
                    case Colors.BrightMagenta:
                        return BrightMagentaForeground;
                    case Colors.BrightCyan:
                        return BrightCyanForeground;
                    case Colors.BrightWhite:
                        return BrightWhiteForeground;
                }
            }
            else
            {
                switch (color)
                {
                    case Colors.Default:
                        return DefaultBackground;
                    case Colors.Black:
                        return BlackBackground;
                    case Colors.Red:
                        return RedBackground;
                    case Colors.Green:
                        return GreenBackground;
                    case Colors.Yellow:
                        return YellowBackground;
                    case Colors.Blue:
                        return BlueBackground;
                    case Colors.Magenta:
                        return MagentaBackground;
                    case Colors.Cyan:
                        return CyanBackground;
                    case Colors.BrightBlack:
                        return BrightBlackBackground;
                    case Colors.White:
                        return WhiteBackground;
                    case Colors.BrightRed:
                        return BrightRedBackground;
                    case Colors.BrightGreen:
                        return BrightGreenBackground;
                    case Colors.BrightYellow:
                        return BrightYellowBackground;
                    case Colors.BrightBlue:
                        return BrightBlueBackground;
                    case Colors.BrightMagenta:
                        return BrightMagentaBackground;
                    case Colors.BrightCyan:
                        return BrightCyanBackground;
                    case Colors.BrightWhite:
                        return BrightWhiteBackground;
                }
            }

            throw new InvalidOperationException();
        }
    }
}
