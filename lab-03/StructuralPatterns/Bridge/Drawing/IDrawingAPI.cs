using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Drawing;
public interface IDrawingAPI
{
    void DrawShape(string shapeType);
}