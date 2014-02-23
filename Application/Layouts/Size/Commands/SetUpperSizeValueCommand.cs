﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Layouts.Size.Commands
{
    public class SetUpperSizeValueCommand : ICommand
    {
        private readonly double _value;

        public SetUpperSizeValueCommand(double value)
        {
            _value = value;
        }

        public double Value
        {
            get { return _value; }
        }
    }
}
