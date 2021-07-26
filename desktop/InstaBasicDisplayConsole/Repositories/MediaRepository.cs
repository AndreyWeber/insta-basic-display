using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

using InstaBasicDisplayConsole.Services;

namespace InstaBasicDisplayConsole.Repositories
{
    public class MediaRepository : RepositoryBase
    {
        private const String uriTemplate = "";

        public MediaRepository(InstragramService instragramService) :
            base(instragramService) {}

        public async Task DownloadMedia(IDictionary<String, String> mediaNameAndUrls, String outputPath)
        {
            if (mediaNameAndUrls is null)
            {
                throw new ArgumentNullException(nameof(mediaNameAndUrls), "Argument cannot be null");
            }

            if (outputPath is null)
            {
                throw new ArgumentNullException(nameof(outputPath), "Argument cannot be null");
            }

            outputPath = outputPath.Trim();
            if (!Directory.Exists(outputPath))
            {
                throw new DirectoryNotFoundException($"'{outputPath}' path not found");
            }

            var mediaByteStreams = instragramService.GetMediaAsBytes(mediaNameAndUrls);
            await foreach (var mediaBytes in mediaByteStreams)
            {
                var mediaFilePath = Path.Combine(outputPath, mediaBytes.Key);
                if (File.Exists(mediaFilePath))
                {
                    File.Delete(mediaFilePath);
                }
                await File.WriteAllBytesAsync(mediaFilePath, mediaBytes.Value);
            }
        }
    }
}