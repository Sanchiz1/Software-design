using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton;
public class Authenticator
{
    public Guid Id { get; set; }

    private static readonly Lazy<Authenticator> lazy =
        new Lazy<Authenticator>(() => new Authenticator());

    public static Authenticator Instance { get { return lazy.Value; } }

    private Authenticator()
    {
        this.Id = Guid.NewGuid();
    }

    public override string ToString()
    {
        return $"Authenticator {this.Id}";
    }
}
