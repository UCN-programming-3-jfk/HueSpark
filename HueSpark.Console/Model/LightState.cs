using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HueSpark.Console.Model;

public class LightState
{
    public bool on { get; set; }
    public int bri { get; set; }
    public int hue { get; set; }
    public int sat { get; set; }
    public double[] xy { get; set; }
    public int ct { get; set; }
}
