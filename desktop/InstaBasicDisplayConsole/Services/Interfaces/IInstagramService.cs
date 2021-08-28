using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using InstaBasicDisplayConsole.Data;

namespace InstaBasicDisplayConsole.Services.Interfaces
{
    public interface IInstagramService
    {
        Task<T> GetEntityAsync<T>(String uri) where T : InstagramEntityBase;

        Task<T> GetEntityAsync<T>(
            String uri,
            IDictionary<String, String> content) where T : InstagramEntityBase;

        IAsyncEnumerable<KeyValuePair<String, Byte[]>> GetMediaAsBytesAsync(
            IDictionary<String, String> mediaNameAndUrls);
    }
}