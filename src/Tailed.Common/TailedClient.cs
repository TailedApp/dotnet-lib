using System;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading;
using System.Threading.Tasks;

namespace Tailed.Common
{
    /// <summary>
    /// Responsible for sending data to the API server.
    /// </summary>
    public class TailedClient : IAsyncDisposable
    {
        private readonly string _tailId;
        private readonly HubConnection _connection;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private bool _connected;

        public TailedClient(string hostname, string tailId)
        {
            _tailId = tailId;
            _connection = new HubConnectionBuilder()
                .WithUrl($"https://{hostname}/api/tail")
                .Build();
        }

        /// <summary>
        /// Sends a single line of text.
        /// </summary>
        /// <param name="line">The text to be sent.</param>
        /// <returns></returns>
        public async Task SendLineAsync(string line)
        {
            if (!_connected)
            {
                await _semaphore.WaitAsync();

                // Something may have made its way through the semaphore
                // first and changed the value of _connected in the meantime.
                if (!_connected)
                {
                    await _connection.StartAsync();
                    _connected = true;
                }

                _semaphore.Release();
            }

            await _connection.SendAsync("SendData", _tailId, line);
        }

        public async ValueTask DisposeAsync()
        {
            try
            {
                await _connection.StopAsync();
                await _connection.DisposeAsync();
            }
            catch (Exception)
            {
                // Ignore
            }
        }
    }
}
