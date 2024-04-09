namespace Strategy.ImageProvider;
public class UrlImageProvider : IImageProvider
{
    public async Task<byte[]> GetImage(string path)
    {
        using var httpClient = new HttpClient();
        return await httpClient.GetByteArrayAsync(path);
    }
}
