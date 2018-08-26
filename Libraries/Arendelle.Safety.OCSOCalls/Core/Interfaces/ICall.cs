using System;
using System.Collections.Generic;
using System.Text;

namespace Arendelle.Safety.OCSOCalls.Core.Interfaces
{
    public interface ICall
    {
        int ID { get; set; }
        string Description { get; set; }
        string Entry { get; set; }
        string Location { get; set; }
        string Sector { get; set; }
        string Zone { get; set; }
        string RD { get; set; }
    }
}
