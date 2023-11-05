using Nito.AsyncEx.Synchronous;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tailed.Common;

namespace Tailed.Console
{
    /// <summary>
    /// Writes ANSI-formatted strings to a SignalR hub.
    /// </summary>
    internal class ConsoleWriter : TextWriter
    {
        private readonly TailedClient _client;
        private readonly bool _ansiColorsOnly;
        private readonly StringBuilder _sb = new StringBuilder();
        private ConsoleColor _consoleForeground = System.Console.ForegroundColor;
        private ConsoleColor _consoleBackground = System.Console.BackgroundColor;

        public override Encoding Encoding => Encoding.UTF8;

        public ConsoleWriter(TailedClient client, bool ansiColorsOnly)
        {
            _client = client;
            _ansiColorsOnly = ansiColorsOnly;
        }
        
        private void PrintAnsiColorCodes()
        {
            _sb.Append(AnsiCodes.ColorToAnsi(AnsiCodes.ColorPosition.Foreground, System.Console.ForegroundColor));
            _sb.Append(AnsiCodes.ColorToAnsi(AnsiCodes.ColorPosition.Background, System.Console.BackgroundColor));

            _consoleForeground = System.Console.ForegroundColor;
            _consoleBackground = System.Console.BackgroundColor;
        }

        private bool ColorsChanged()
        {
            if (_ansiColorsOnly) return false;
            return System.Console.ForegroundColor != _consoleForeground || System.Console.BackgroundColor != _consoleBackground;
        }

        private void AddText(string text)
        {
            if (ColorsChanged())
                PrintAnsiColorCodes();

            _sb.Append(text.Replace("\r", string.Empty));
        }

        private void CompleteLine()
        {
            _sb.Append("\n");
            Flush();
        }

        
        #region WriteLine
        public override void WriteLine()
        {
            AddText(string.Empty);
            CompleteLine();
        }

        public override void WriteLine(bool value)
        {
            AddText(value.ToString());
            CompleteLine();
        }

        public override void WriteLine(char value)
        {
            AddText(value.ToString());
            CompleteLine();
        }

        public override void WriteLine(char[] buffer)
        {
            AddText(new string(buffer));
            CompleteLine();
        }

        public override void WriteLine(char[] buffer, int index, int count)
        {
            AddText(new string(buffer.Skip(index).Take(count).ToArray()));
            CompleteLine();
        }

        public override void WriteLine(decimal value)
        {
            AddText(value.ToString(CultureInfo.CurrentCulture));
            CompleteLine();
        }

        public override void WriteLine(double value)
        {
            AddText(value.ToString(CultureInfo.CurrentCulture));
            CompleteLine();
        }

        public override void WriteLine(int value)
        {
            AddText(value.ToString());
            CompleteLine();
        }

        public override void WriteLine(long value)
        {
            AddText(value.ToString());
            CompleteLine();
        }

        public override void WriteLine(object value)
        {
            AddText(value.ToString());
            CompleteLine();
        }

        public override void WriteLine(ReadOnlySpan<char> buffer)
        {
            AddText(new string(buffer));
            CompleteLine();
        }

        public override void WriteLine(float value)
        {
            AddText(value.ToString(CultureInfo.CurrentCulture));
            CompleteLine();
        }

        public override void WriteLine(string value)
        {
            AddText(value);
            CompleteLine();
        }

        public override void WriteLine(string format, object arg0)
        {
            AddText(string.Format(format, arg0));
            CompleteLine();
        }

        public override void WriteLine(string format, object arg0, object arg1)
        {
            AddText(string.Format(format, arg0, arg1));
            CompleteLine();
        }

        public override void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            AddText(string.Format(format, arg0, arg1, arg2));
            CompleteLine();
        }

        public override void WriteLine(string format, params object[] arg)
        {
            AddText(string.Format(format, arg));
            CompleteLine();
        }

        public override void WriteLine(uint value)
        {
            AddText(value.ToString());
            CompleteLine();
        }

        public override void WriteLine(ulong value)
        {
            AddText(value.ToString());
            CompleteLine();
        }
        #endregion

        #region Write
        public override void Write(bool value)
        {
            AddText(value.ToString());
        }

        public override void Write(char value)
        {
            AddText(value.ToString());
        }

        public override void Write(char[] buffer)
        {
            AddText(new string(buffer));
        }

        public override void Write(char[] buffer, int index, int count)
        {
            AddText(new string(buffer.Skip(index).Take(count).ToArray()));
        }

        public override void Write(decimal value)
        {
            AddText(value.ToString(CultureInfo.CurrentCulture));
        }

        public override void Write(double value)
        {
            AddText(value.ToString(CultureInfo.CurrentCulture));
        }

        public override void Write(int value)
        {
            AddText(value.ToString());
        }

        public override void Write(long value)
        {
            AddText(value.ToString());
        }

        public override void Write(object value)
        {
            AddText(value.ToString());
        }

        public override void Write(ReadOnlySpan<char> buffer)
        {
            AddText(new string(buffer));
        }

        public override void Write(float value)
        {
            AddText(value.ToString(CultureInfo.CurrentCulture));
        }

        public override void Write(string value)
        {
            AddText(value);
        }

        public override void Write(string format, object arg0)
        {
            AddText(string.Format(format, arg0));
        }

        public override void Write(string format, object arg0, object arg1)
        {
            AddText(string.Format(format, arg0, arg1));
        }

        public override void Write(string format, object arg0, object arg1, object arg2)
        {
            AddText(string.Format(format, arg0, arg1, arg2));
        }

        public override void Write(string format, params object[] arg)
        {
            AddText(string.Format(format, arg));
        }

        public override void Write(uint value)
        {
            AddText(value.ToString());
        }

        public override void Write(ulong value)
        {
            AddText(value.ToString());
        }
        #endregion

        #region WriteLineAsync
        public override Task WriteLineAsync()
        {
            AddText(string.Empty);
            CompleteLine();
            return Task.CompletedTask;
        }

        public override Task WriteLineAsync(char value)
        {
            AddText(value.ToString());
            CompleteLine();
            return Task.CompletedTask;
        }

        public override Task WriteLineAsync(char[] buffer, int index, int count)
        {
            AddText(new string(buffer.Skip(index).Take(count).ToArray()));
            CompleteLine();
            return Task.CompletedTask;
        }

        public override Task WriteLineAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = new CancellationToken())
        {
            AddText(new string(buffer.ToArray()));
            CompleteLine();
            return Task.CompletedTask;
        }

        public override Task WriteLineAsync(string value)
        {
            AddText(value);
            CompleteLine();
            return Task.CompletedTask;
        }
        #endregion

        #region WriteAsync
        public override Task WriteAsync(char value)
        {
            AddText(value.ToString());
            return Task.CompletedTask;
        }

        public override Task WriteAsync(char[] buffer, int index, int count)
        {
            AddText(new string(buffer.Skip(index).Take(count).ToArray()));
            return Task.CompletedTask;
        }

        public override Task WriteAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = new CancellationToken())
        {
            AddText(new string(buffer.ToArray()));
            return Task.CompletedTask;
        }

        public override Task WriteAsync(string value)
        {
            AddText(value);
            return Task.CompletedTask;
        }
        #endregion

        #region Other

        public override ValueTask DisposeAsync()
        {
            return _client.DisposeAsync();
        }

        protected override void Dispose(bool disposing)
        {
            _client.DisposeAsync()
                .AsTask()
                .WaitAndUnwrapException();
        }

        public override void Flush()
        {
            FlushAsync().WaitAndUnwrapException();
        }

        public override async Task FlushAsync()
        {
            await _client.SendLineAsync( _sb.ToString());
            _sb.Clear();
        }
        #endregion
    }
}
