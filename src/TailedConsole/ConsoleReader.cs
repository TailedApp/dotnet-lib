using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tailed.Console
{
    /// <summary>
    /// Wraps the standard TextReader used for keyboard input and passes read
    /// characters to the ConsoleWriter.
    /// </summary>
    internal class ConsoleReader : TextReader
    {
        private readonly TextReader _defaultReader;
        private readonly ConsoleWriter _writer;

        public ConsoleReader(TextReader defaultReader, ConsoleWriter writer)
        {
            _defaultReader = defaultReader;
            _writer = writer;
        }

        public override int Read()
        {
            var result = _defaultReader.Read();
            _writer.Write((char) result);
            return result;
        }

        public override int Read(char[] buffer, int index, int count)
        {
            var result = _defaultReader.Read(buffer, index, count);
            _writer.Write(buffer.Skip(index).Take(result).ToArray());
            return result;
        }

        public override int Read(Span<char> buffer)
        {
            var result = _defaultReader.Read(buffer);
            _writer.Write(buffer.ToArray().Take(result).ToArray());
            return result;
        }

        public override async Task<int> ReadAsync(char[] buffer, int index, int count)
        {
            var result = await _defaultReader.ReadAsync(buffer, index, count);
            await _writer.WriteAsync(buffer.Skip(index).Take(result).ToArray());
            return result;
        }

        public override async ValueTask<int> ReadAsync(Memory<char> buffer, CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await _defaultReader.ReadAsync(buffer, cancellationToken);
            await _writer.WriteAsync(buffer.ToArray().Take(result).ToArray());
            return result;
        }

        public override int ReadBlock(char[] buffer, int index, int count)
        {
            var result = _defaultReader.ReadBlock(buffer, index, count);
            _writer.Write(buffer.Skip(index).Take(result).ToArray());
            return result;
        }

        public override int ReadBlock(Span<char> buffer)
        {
            var result = _defaultReader.ReadBlock(buffer);
            _writer.Write(buffer);
            return result;
        }

        public override async Task<int> ReadBlockAsync(char[] buffer, int index, int count)
        {
            var result = await _defaultReader.ReadBlockAsync(buffer, index, count);
            await _writer.WriteAsync(buffer.Skip(index).Take(result).ToArray());
            return result;
        }

        public override async ValueTask<int> ReadBlockAsync(Memory<char> buffer, CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await _defaultReader.ReadBlockAsync(buffer, cancellationToken);
            await _writer.WriteAsync(buffer.ToArray().Take(result).ToArray());
            return result;
        }

        public override string ReadLine()
        {
            var result = _defaultReader.ReadLine();
            _writer.WriteLine(result ?? string.Empty);
            return result!;
        }

        public override async Task<string> ReadLineAsync()
        {
            var result = await _defaultReader.ReadLineAsync();
            await _writer.WriteLineAsync(result ?? string.Empty);
            return result!;
        }

        public override string ReadToEnd()
        {
            var result = _defaultReader.ReadToEnd();
            _writer.Write(result);
            return result;
        }

        public override async Task<string> ReadToEndAsync()
        {
            var result = await _defaultReader.ReadToEndAsync();
            await _writer.WriteAsync(result);
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            _defaultReader.Dispose();
        }

        public override void Close()
        {
            _defaultReader.Close();
        }

        public override object InitializeLifetimeService()
        {
            return _defaultReader.InitializeLifetimeService()!;
        }

        public override int Peek()
        {
            return _defaultReader.Peek();
        }
    }
}
