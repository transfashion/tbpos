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
        //public static async Task<bool> xDownloadPos05EnDllAsync(string url, string destFilePath, IProgress<int> progress = null, CancellationToken cancellationToken = default)
        //{

        //    Directory.CreateDirectory(Path.GetDirectoryName(destFilePath) ?? ".");
        //    using (var http = new HttpClient())
        //    using (var response = await http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
        //    {
        //        if (!response.IsSuccessStatusCode)
        //            return false;

        //        var contentLength = response.Content.Headers.ContentLength;
        //        using (var source = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
        //        using (var destination = new FileStream(destFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
        //        {
        //            var buffer = new byte[81920];
        //            long totalRead = 0;
        //            int read;
        //            while ((read = await source.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)) > 0)
        //            {
        //                await destination.WriteAsync(buffer, 0, read, cancellationToken).ConfigureAwait(false);
        //                totalRead += read;
        //                if (contentLength.HasValue && progress != null)
        //                {
        //                    progress.Report((int)(totalRead * 100 / contentLength.Value));
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}


        public static async Task<bool> DownloadPos05EnDllAsync(string url, string destFilePath, IProgress<int> progress = null, CancellationToken cancellationToken = default)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destFilePath) ?? ".");
            try
            {
                using (var http = new HttpClient())
                using (var response = await http.GetAsync(
                        url,
                    HttpCompletionOption.ResponseHeadersRead,
                    cancellationToken
                ).ConfigureAwait(false))


                {
                    if (!response.IsSuccessStatusCode)
                    {
                        switch ((int)response.StatusCode)
                        {
                            case 404:
                                // Not found
                                Console.WriteLine("File tidak ditemukan (404)");
                                break;

                            case 500:
                                Console.WriteLine("Server error (500)");
                                break;

                            default:
                                Console.WriteLine($"HTTP Error: {(int)response.StatusCode}");
                                break;
                        }

                        return false;
                    }

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
            catch (TaskCanceledException)
            {
                Console.WriteLine("Request timeout / dibatalkan");
                return false;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return false;
            }

        }
    }
}
