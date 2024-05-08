﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkService.Model
{

    /// <summary>
    /// Linije koje se iscrtavaju na drag and dropu
    /// </summary>
    public class LineModel
    {
        public List<Point> PointList { get; set; }

       
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}
