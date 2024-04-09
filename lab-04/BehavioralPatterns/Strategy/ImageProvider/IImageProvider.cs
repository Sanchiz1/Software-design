namespace Strategy.ImageProvider;
public interface IImageProvider
{
    Task<byte[]> GetImage(string path);
}
