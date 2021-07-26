using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

using InstaBasicDisplayConsole.Data;

namespace InstaBasicDisplayConsole.Services
{
    public class InstragramService
    {
        public async Task<T> GetEntity<T>(String uri) where T : InstagramEntityBase
        {
            if (String.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentNullException(nameof(uri), "Argument cannot be null or empty");
            }

            using var httpClient = new HttpClient();

            var responseString = await httpClient.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public async Task<T> GetEntity<T>(
            String uri,
            IDictionary<String, String> content) where T : InstagramEntityBase
        {
            if (String.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentNullException(nameof(uri), "Argument cannot be null or empty");
            }

            if (content is null)
            {
                throw new ArgumentNullException(nameof(uri), "Argument cannot be null");
            }

            using var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(uri, new FormUrlEncodedContent(content));

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseString);
        }

        // public async Task<Byte[]> GetMediaAsBytes(String uri)
        // {
        //     if (String.IsNullOrWhiteSpace(uri))
        //     {
        //         throw new ArgumentNullException(nameof(uri), "Argument cannot be null or empty");
        //     }

        //     using var httpClient = new HttpClient();

        //     return await httpClient.GetByteArrayAsync(uri);
        // }

        public async IAsyncEnumerable<KeyValuePair<String, Byte[]>> GetMediaAsBytes(
            IDictionary<String, String> mediaNameAndUrls)
        {
            if (mediaNameAndUrls is null)
            {
                throw new ArgumentNullException(nameof(mediaNameAndUrls), "Argument cannot be null");
            }

            using var httpClient = new HttpClient();

            foreach (var nameAndUrl in mediaNameAndUrls)
            {
                var mediaBytes = await httpClient.GetByteArrayAsync(nameAndUrl.Value);

                yield return new KeyValuePair<String, Byte[]>(nameAndUrl.Key, mediaBytes);
            }
        }
    }
}