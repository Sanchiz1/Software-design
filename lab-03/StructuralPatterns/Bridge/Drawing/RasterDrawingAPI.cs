﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Drawing;
public class RasterDrawingAPI : IDrawingAPI
{
    public void DrawShape(string shapeType)
    {
        Console.WriteLine($"Drawing {shapeType} with raster graphics");
    }
}
