namespace Strategy.ImageProvider;
public class FileImageProvider : IImageProvider
{
    public async Task<byte[]> GetImage(string path)
    {
        return await File.ReadAllBytesAsync(path);
    }
}
