using System;
using System.IO;
// using System.Net;
// using System.Text;
// using System.Net.Sockets;
using System.Linq;
using System.Net.Http;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

using InstaBasicDisplayConsole.Data;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InstaBasicDisplayConsole
{
    #region Soket sample
    // Byte[] input = BitConverter.GetBytes(1);
    // Byte[] buffer = new Byte[4096];
    // Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
    // s.Bind(new IPEndPoint(IPAddress.Parse("192.168.31.22"), 0));
    // s.IOControl(IOControlCode.ReceiveAll, input, null);

    // int bytes = 0;
    // do
    // {
    //     bytes = s.Receive(buffer);
    //     if (bytes > 0)
    //     {
    //         Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytes));
    //     }
    // } while (bytes > 0);
    #endregion Soket sample

    class Program
    {
        public static async Task Main(string[] args)
        {
            const String InstagramAppId = "";
            const String InstagramAppSecret = "";
            const String RedirectUrl = "https://andreyweber.github.io/insta-basic-display/";
            const Int16 MediaRequestLimit = 100;

            Console.WriteLine("Starting browser...");

            // Open browser to request Instagram authorization code
            Process process;
            try
            {
                var url = "https://api.instagram.com/oauth/authorize" +
                    $"?client_id={InstagramAppId}" +
                    $"&redirect_uri={RedirectUrl}" +
                    "&scope=user_profile,user_media" +
                    "&response_type=code";
                process = Process.Start(new ProcessStartInfo(url)
                {
                    UseShellExecute = true
                });

                Console.WriteLine("Browser started");
            }
            catch (Win32Exception ex)
            {
                Console.WriteLine($"Failed to start browser {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception during browser start: {ex.Message}");
            }

            Console.WriteLine("Provide authorization code:");
            var authCode = Console.ReadLine();

            using (var client = new HttpClient())
            {
                // Get short-lived Instagram access token
                var values = new Dictionary<String, String>
                {
                    { "client_id", InstagramAppId },
                    { "client_secret", InstagramAppSecret },
                    { "grant_type", "authorization_code" },
                    { "redirect_uri", RedirectUrl },
                    { "code", authCode }
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("https://api.instagram.com/oauth/access_token", content);

                var responseString = await response.Content.ReadAsStringAsync();

                var accessToken = JsonConvert.DeserializeObject<AccessToken>(responseString);

                // Get user info using access token
                var userInfoResponseString = await client.GetStringAsync($"https://graph.instagram.com/{accessToken.UserId}?" +
                    $"fields=id,username,media_count&access_token={accessToken.Token}");

                var user = JsonConvert.DeserializeObject<User>(userInfoResponseString);

                // Get user media edge
                // ! &limit= argument max value seems to be equal to 100
                var userMediaCollectionResponseString = await client.GetStringAsync($"https://graph.instagram.com/me/media?" +
                    $"fields=id,media_type,media_url&limit={MediaRequestLimit}&access_token={accessToken.Token}");

                var userMediaCollection = JsonConvert.DeserializeObject<MediaCollection>(userMediaCollectionResponseString);

                var carouselAlbums = userMediaCollection
                    .Data
                    .Where(i => i.MediaType == MediaType.CAROUSEL_ALBUM)
                    .ToList();

                var reqUrl = $"https://graph.instagram.com/{carouselAlbums.First().Id}/children?" +
                    $"fields=id,media_url,permalink,media_type,thumbnail_url,timestamp,username&access_token={accessToken.Token}";
                var carouselAlbumResponseString = await client.GetStringAsync(reqUrl);

                var carouselAlbumMediaCollection = JsonConvert.DeserializeObject<MediaCollection>(carouselAlbumResponseString);

                // Test paging in media collection (get second page)
                var mediaCollectionSecondPageResponseString = await client.GetStringAsync(userMediaCollection.Paging.Next);

                var mediaCollectionSecondPage = JsonConvert.DeserializeObject<MediaCollection>(mediaCollectionSecondPageResponseString);

                // TODO: Test download image / video
                var firstImageUrl = userMediaCollection.Data.First(i => i.MediaType == MediaType.IMAGE).MediaUrl;

                var firstImageStream = await client.GetStreamAsync(firstImageUrl);
                using (var fileStream = new FileStream("fileFromStream.png", FileMode.Create))
                {
                    firstImageStream.CopyTo(fileStream);
                }

                var firstImageByteArray = await client.GetByteArrayAsync(firstImageUrl);
                await File.WriteAllBytesAsync("fileFromByteArray.png", firstImageByteArray);

                // TODO: Add classes (repos) for getting different entities
                // TODO: Add exchange of short-lived access token on long-lived one
                // TODO: Test paging till the media collection end
                // TODO: Add low-level class for sending requests to Instagram API
                // TODO: Add ASCII progress bars for media download
                // TODO: Check how "before" and "after" works
            }

            Console.ReadKey(false);
        }
    }
}
