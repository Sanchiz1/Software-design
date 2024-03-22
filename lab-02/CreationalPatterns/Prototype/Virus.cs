using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype;
public class Virus : ICloneable<Virus>
{

    public decimal Weight { get; set; }
    public int Age { get; set; }
    public string Name {  get; set; }
    public string Type {  get; set; }
    public IList<Virus> ChildViruses { get; set; }

    public Virus(decimal weight, int age, string name, string type, IList<Virus> childViruses)
    {
        Weight = weight;
        Age = age;
        Name = name;
        Type = type;
        ChildViruses = childViruses;
    }

    public Virus Clone()
    {
        List<Virus> childViruses = ChildViruses
            .Select(v => v.Clone())
            .ToList();

        return new Virus(Weight, Age, Name, Type, childViruses);
    }

    private string GetDetails(StringBuilder stringBuilder, int gen = 0)
    {
        stringBuilder.Append(new string('\t', gen))
            .Append($"Virus {Name}, Type - {Type}, Weight - {Weight}, Age - {Age}, Children: ");

        if(!ChildViruses.Any())
        {
            stringBuilder.Append("None");
        }

        stringBuilder.AppendLine();

        foreach (var virus in ChildViruses)
        {
            virus.GetDetails(stringBuilder, gen + 1);
        }

        return stringBuilder.ToString();
    }

    public override string ToString()
    {
        return this.GetDetails(new StringBuilder());
    }
}