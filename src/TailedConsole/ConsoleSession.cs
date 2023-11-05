using Nito.AsyncEx.Synchronous;
using System;
using System.IO;
using System.Threading.Tasks;
using Tailed.Common;

namespace Tailed.Console
{
    /// <summary>
    /// Manages a Tailed session.
    /// </summary>
    public class ConsoleSession : SessionBase
    {
        private readonly MultiWriter _writer;
        private readonly ConsoleReader _reader;
        private bool _started;
        private bool _stopped;

        /// <summary>
        /// Prepares a new session.
        /// </summary>
        /// <param name="ansiColorsOnly">Ignore Console.ForegroundColor and Console.BackgroundColor and use only ANSI color codes. Defaults to true.</param>
        /// <param name="hostname">Optional override of the server hostname. Defaults to tailed.live.</param>
        public ConsoleSession(bool ansiColorsOnly = true, string hostname = "tailed.live") : base(hostname)
        {
            var consoleWriter =
                new ConsoleWriter(Client, ansiColorsOnly);

            _writer = new MultiWriter(new TextWriter[]
            {
                // Order is important here. We want it to hit the console window prior to Tailed.
                new StreamWriter(System.Console.OpenStandardOutput()),
                consoleWriter
            });

            _reader = new ConsoleReader(new StreamReader(System.Console.OpenStandardInput()), consoleWriter);
        }

        /// <summary>
        /// Starts the session. Redirects the Console's standard input, output and error via Tailed.
        /// </summary>
        /// <returns></returns>
        public void Start()
        {
            if (_started)
                throw new InvalidOperationException("A session can only be started once.");

            RenderSessionInformation();

            System.Console.SetOut(_writer);
            System.Console.SetError(_writer);
            System.Console.SetIn(_reader);

            _started = true;
        }

        /// <summary>
        /// Stops the session. Resets the Console's standard input, standard output and standard error back
        /// to their defaults.
        /// </summary>
        /// <param name="flushDelayMs">How long to wait for all available text to have been flushed to the Console. Handy
        /// for ILogger implementations that buffer log messages and only flush periodically.</param>
        /// <returns></returns>
        public async Task StopAsync(int flushDelayMs = 2000)
        {
            if (!_started)
                throw new InvalidOperationException("You cannot stop a session that hasn't started.");

            if (_stopped)
                return;

            _stopped = true;

            var standardOutput = new StreamWriter(System.Console.OpenStandardOutput())
            {
                AutoFlush = true
            };

            System.Console.SetOut(standardOutput);

            var standardError = new StreamWriter(System.Console.OpenStandardError())
            {
                AutoFlush = true
            };

            System.Console.SetError(standardError);

            System.Console.SetIn(new StreamReader(System.Console.OpenStandardInput()));

            await Task.Delay(flushDelayMs);

            await _writer.FlushAsync();
        }
     
        public override async ValueTask DisposeAsync()
        {
            if (_started && !_stopped)
                await StopAsync();

            _writer.Close();
            await _writer.DisposeAsync();

            await base.DisposeAsync();
        }

        public override void Dispose()
        {
            DisposeAsync().AsTask().WaitAndUnwrapException();
        }
    }
}
