using Bridge.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Shapes;
public abstract class Shape
{
    protected IDrawingAPI DrawingAPI;

    protected Shape(IDrawingAPI drawingAPI)
    {
        this.DrawingAPI = drawingAPI;
    }

    public abstract void Draw();
}
