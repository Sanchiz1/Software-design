using Observer.LightNode;
using Strategy.ImageProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy;
public class LightImageNode : LightElementNode
{
    public IImageProvider ImageProvider { get; set; }
    public string Href { get; set; }
    public string Alt { get; set; }

    public LightImageNode(string href, string alt, TagDisplayType displayType, TagClosingType closingType, List<string> classes, IImageProvider imageProvider)
        : base("img", displayType, closingType, classes, [])
    {
        this.ImageProvider = imageProvider;
        this.Href = href;
        this.Alt = alt;
    }
    public void SetStrategy(IImageProvider provider)
    {
        this.ImageProvider = provider;
    }

    protected override string OpeningPart
        => ClosingType == TagClosingType.Single ? $"<{Name}{ClassesPart} href=\"{Href}\" alt=\"{Alt}\"" : $"<{Name}{ClassesPart}  href=\"{Href}\" alt=\"{Alt}\">";

    public byte[] GetImageBytes()
    {
        return this.ImageProvider.GetImage(this.Href).Result;
    }

    public async Task<byte[]> GetImageBytesAsync()
    {
        return await this.ImageProvider.GetImage(this.Href);
    }
}
