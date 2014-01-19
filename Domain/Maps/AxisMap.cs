﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps
{
    public abstract class AxisMap
    {
        public abstract double? Map(object value);

        public abstract object MapInverse(double? value);
    }
}