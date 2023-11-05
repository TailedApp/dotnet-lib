using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tailed.Console
{
    internal class MultiWriter : TextWriter
    {
        private readonly TextWriter[] _writers;
        public override Encoding Encoding => Encoding.UTF8;

        public MultiWriter(TextWriter[] writers)
        {
            _writers = writers;
        }

        #region WriteLine
        public override void WriteLine()
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine();
                writer.Flush();
            }
        }

        public override void WriteLine(bool value)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public override void WriteLine(char value)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public override void WriteLine(char[] buffer)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(buffer);
                writer.Flush();
            }
        }

        public override void WriteLine(char[] buffer, int index, int count)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(buffer, index, count);
                writer.Flush();
            }
        }

        public override void WriteLine(decimal value)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public override void WriteLine(double value)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public override void WriteLine(int value)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public override void WriteLine(long value)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public override void WriteLine(object value)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public override void WriteLine(ReadOnlySpan<char> buffer)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(buffer);
                writer.Flush();
            }
        }

        public override void WriteLine(float value)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public override void WriteLine(string value)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public override void WriteLine(string format, object arg0)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(format, arg0);
                writer.Flush();
            }
        }

        public override void WriteLine(string format, object arg0, object arg1)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(format, arg0, arg1);
                writer.Flush();
            }
        }

        public override void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(format, arg0, arg1, arg2);
                writer.Flush();
            }
        }

        public override void WriteLine(string format, params object[] arg)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(format, arg);
                writer.Flush();
            }
        }

        public override void WriteLine(uint value)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public override void WriteLine(ulong value)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }
        #endregion

        #region Write
        public override void Write(bool value)
        {
            foreach (var writer in _writers)
            {
                writer.Write(value);
                writer.Flush();
            }
        }

        public override void Write(char value)
        {
            foreach (var writer in _writers)
            {
                writer.Write(value);
                writer.Flush();
            }
        }

        public override void Write(char[] buffer)
        {
            foreach (var writer in _writers)
            {
                writer.Write(buffer);
                writer.Flush();
            }
        }

        public override void Write(char[] buffer, int index, int count)
        {
            foreach (var writer in _writers)
            {
                writer.Write(buffer, index, count);
                writer.Flush();
            }
        }

        public override void Write(decimal value)
        {
            foreach (var writer in _writers)
            {
                writer.Write(value);
                writer.Flush();
            }
        }

        public override void Write(double value)
        {
            foreach (var writer in _writers)
            {
                writer.Write(value);
                writer.Flush();
            }
        }

        public override void Write(int value)
        {
            foreach (var writer in _writers)
            {
                writer.Write(value);
                writer.Flush();
            }
        }

        public override void Write(long value)
        {
            foreach (var writer in _writers)
            {
                writer.Write(value);
                writer.Flush();
            }
        }

        public override void Write(object value)
        {
            foreach (var writer in _writers)
            {
                writer.Write(value);
                writer.Flush();
            }
        }

        public override void Write(ReadOnlySpan<char> buffer)
        {
            foreach (var writer in _writers)
            {
                writer.Write(buffer);
                writer.Flush();
            }
        }

        public override void Write(float value)
        {
            foreach (var writer in _writers)
            {
                writer.Write(value);
                writer.Flush();
            }
        }

        public override void Write(string value)
        {
            foreach (var writer in _writers)
            {
                writer.Write(value);
                writer.Flush();
            }
        }

        public override void Write(string format, object arg0)
        {
            foreach (var writer in _writers)
            {
                writer.Write(format, arg0);
                writer.Flush();
            }
        }

        public override void Write(string format, object arg0, object arg1)
        {
            foreach (var writer in _writers)
            {
                writer.Write(format, arg0, arg1);
                writer.Flush();
            }
        }

        public override void Write(string format, object arg0, object arg1, object arg2)
        {
            foreach (var writer in _writers)
            {
                writer.Write(format, arg0, arg1, arg2);
                writer.Flush();
            }
        }

        public override void Write(string format, params object[] arg)
        {
            foreach (var writer in _writers)
            {
                writer.Write(format, arg);
                writer.Flush();
            }
        }

        public override void Write(uint value)
        {
            foreach (var writer in _writers)
            {
                writer.Write(value);
                writer.Flush();
            }
        }

        public override void Write(ulong value)
        {
            foreach (var writer in _writers)
            {
                writer.Write(value);
                writer.Flush();
            }
        }
        #endregion

        #region WriteLineAsync
        public override async Task WriteLineAsync()
        {
            await ForEachWriter(async writer =>
            {
                await writer.WriteLineAsync();
                await writer.FlushAsync();
            });
        }

        public override async Task WriteLineAsync(char value)
        {
            await ForEachWriter(async writer =>
            {
                await writer.WriteLineAsync(value);
                await writer.FlushAsync();
            });
        }

        public override async Task WriteLineAsync(char[] buffer, int index, int count)
        {
            await ForEachWriter(async writer =>
            {
                await writer.WriteLineAsync(buffer, index, count);
                await writer.FlushAsync();
            });
        }

        public override async Task WriteLineAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = new CancellationToken())
        {
            await ForEachWriter(async writer =>
            {
                await writer.WriteLineAsync(buffer, cancellationToken);
                await writer.FlushAsync();
            });
        }

        public override async Task WriteLineAsync(string value)
        {
            await ForEachWriter(async writer =>
            {
                await writer.WriteLineAsync(value);
                await writer.FlushAsync();
            });
        }
        #endregion

        #region WriteAsync
        public override async Task WriteAsync(char value)
        {
            await ForEachWriter(async writer =>
            {
                await writer.WriteAsync(value);
                await writer.FlushAsync();
            });
        }

        public override async Task WriteAsync(char[] buffer, int index, int count)
        {
            await ForEachWriter(async writer =>
            {
                await writer.WriteAsync(buffer, index, count);
                await writer.FlushAsync();
            });
        }

        public override async Task WriteAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = new CancellationToken())
        {
            await ForEachWriter(async writer =>
            {
                await writer.WriteAsync(buffer, cancellationToken);
                await writer.FlushAsync();
            });
        }

        public override async Task WriteAsync(string value)
        {
            await ForEachWriter(async writer =>
            {
                await writer.WriteAsync(value);
                await writer.FlushAsync();
            });
        }
        #endregion

        #region Other
        private async Task ForEachWriter(Func<TextWriter, Task> action)
        {
            var tasks = new Task[_writers.Length];

            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = action(_writers[i]);
            }

            await Task.WhenAll(tasks);
        }

        public override void Close()
        {
            foreach (var writer in _writers)
            {
                writer.Close();
            }
        }

        public override async ValueTask DisposeAsync()
        {
            await ForEachWriter(async writer =>
            {
                await writer.DisposeAsync();
            });
        }

        protected override void Dispose(bool disposing)
        {
            foreach (var writer in _writers)
            {
                writer.Dispose();
            }
        }

        public override void Flush()
        {
            foreach (var writer in _writers)
            {
                writer.Flush();
            }
        }

        public override async Task FlushAsync()
        {
            await ForEachWriter(async writer =>
            {
                await writer.FlushAsync();
            });
        }

        public override object InitializeLifetimeService()
        {
            foreach (var writer in _writers)
            {
                writer.InitializeLifetimeService();
            }

            return new object();
        }
        #endregion
    }
}
