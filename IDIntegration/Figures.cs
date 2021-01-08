using System;
using System.Collections.Generic;
using System.Drawing;

namespace InterfaceDesigner
{
    [Serializable]
    public class Figures
    {
        public List<Point[]> Points;
        public List<int[]> Rectangles;
        public List<int[]> Ellipses;
        public List<Point[]> Polygons;
    }
}
