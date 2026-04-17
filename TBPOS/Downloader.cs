using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TBPOS
{
    public static class Downloader
    {
        /// <summary>
        /// Download file secara async dan simpan ke destFilePath.
        /// Return true jika sukses.
        /// </summary>
        public static async Task<bool> DownloadPos05EnDllAsync(string url, string destFilePath, IProgress<int> progress = null, CancellationToken cancellationToken = default)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destFilePath) ?? ".");
            using (var http = new HttpClient())
            using (var response = await http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                    return false;

                var contentLength = response.Content.Headers.ContentLength;
                using (var source = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (var destination = new FileStream(destFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
                {
                    var buffer = new byte[81920];
                    long totalRead = 0;
                    int read;
                    while ((read = await source.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)) > 0)
                    {
                        await destination.WriteAsync(buffer, 0, read, cancellationToken).ConfigureAwait(false);
                        totalRead += read;
                        if (contentLength.HasValue && progress != null)
                        {
                            progress.Report((int)(totalRead * 100 / contentLength.Value));
                        }
                    }
                }
            }
            return true;
        }
    }
}
