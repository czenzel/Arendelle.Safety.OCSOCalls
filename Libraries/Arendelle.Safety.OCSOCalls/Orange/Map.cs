using System;
using System.Collections.Generic;
using System.Text;

namespace Arendelle.Safety.OCSOCalls.Orange
{
    public class Map
    {
        public Map()
        {
            Zones.Add(60, @"Lake Buena Vista");
            Zones.Add(61, @"Bay Lake");
            Zones.Add(62, @"Celebration, Kissimmee, W Islo / 192");
        }

        public Dictionary<int, string> Zones { get; } = new Dictionary<int, string>();
    }
}
