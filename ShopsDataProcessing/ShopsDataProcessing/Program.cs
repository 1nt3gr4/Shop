﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsDataProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            IProcess processData = new Processing();
            processData.Process();
        }
    }
}
