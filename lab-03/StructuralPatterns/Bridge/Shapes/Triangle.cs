using Bridge.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Shapes;
public class Triangle : Shape
{
    public Triangle(IDrawingAPI drawingAPI) : base(drawingAPI) { }

    public override void Draw()
    {
        this.DrawingAPI.DrawShape("Triangle");
    }
}
