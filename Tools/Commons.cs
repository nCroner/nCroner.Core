using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nCroner.Common.Tools
{
    public static class Commons
    {
        private static HttpClient _httpClient;
        private static readonly HttpClient _httpClient2;

        static Commons()
        {
            _httpClient = new HttpClient();
            _httpClient2 = new HttpClient();
        }

        public static void SetRequestUrlProxy(string url, int port, string userName = "",
            string password = "")
        {
            var httpHandler = new HttpClientHandler()
            {
                Proxy = new WebProxy($"{url}:{port}", false),
                PreAuthenticate = true,
                UseDefaultCredentials = false,
            };

            if (!string.IsNullOrWhiteSpace(userName))
            {
                httpHandler.Credentials = new NetworkCredential(userName, password);
            }

            _httpClient = new HttpClient(httpHandler);
        }

        public static Task<string> RequestUrl(string path, HttpMethod method, object postData = null,
            Dictionary<string, string> headers = null, int timeout = 10_000, bool withProxy = false)
        {
            return SendRequestUrl(withProxy ? _httpClient : _httpClient2, path,
                method, postData, headers, timeout);
        }

        public static async Task<T> RequestUrl<T>(string path, HttpMethod method, object postData = null,
            Dictionary<string, string> headers = null, int timeout = 10_000, bool withProxy = false)
        {
            var res = await RequestUrl(path, method, postData, headers, timeout, withProxy);
            return !string.IsNullOrWhiteSpace(res)
                ? JsonConvert.DeserializeObject<T>(res)
                : default;
        }

        private static async Task<string> SendRequestUrl(HttpClient httpClient, string path,
            HttpMethod method, object postData = null, Dictionary<string, string> headers = null, int timeout = 10_000)
        {
            var retValue = string.Empty;
            try
            {
                if (!path.StartsWith("http://") && !path.StartsWith("https://"))
                    path = $"http://{path}";

                var message = new HttpRequestMessage(method, new Uri(path));

                if (postData != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(postData),
                        Encoding.UTF8, "application/json");
                }

                if (headers != null && headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        message.Headers.Add(header.Key, header.Value);
                    }
                }

                var cancellationToken = new CancellationTokenSource();
                cancellationToken.CancelAfter(timeout);

                var res = await httpClient.SendAsync(message, cancellationToken.Token);

                if (res?.Content != null)
                    retValue = await res.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                Debugger.Log(1, "F4ST.Common", e.Message);
            }

            return retValue;
        }

        public static DateTime GetDateByTimeZone(string timeZone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
                TimeZoneInfo.FindSystemTimeZoneById(timeZone));
        }

        public static DateTime GetDateByTimeZone(DateTime time, string timeZone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(time.ToUniversalTime(),
                TimeZoneInfo.FindSystemTimeZoneById(timeZone));
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static DateTime ByTimeZone(this DateTime time, string timeZone)
        {
            return string.IsNullOrWhiteSpace(timeZone)
                ? time
                : TimeZoneInfo.ConvertTimeFromUtc(time.ToUniversalTime(),
                    TimeZoneInfo.FindSystemTimeZoneById(timeZone));
        }
    }
}