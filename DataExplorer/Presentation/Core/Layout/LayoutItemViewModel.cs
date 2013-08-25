﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;

namespace DataExplorer.Presentation.Core.Layout
{
    public class LayoutItemViewModel
    {
        private readonly ColumnDto _column;

        public string Name
        {
            get { return _column.Name; }
        }

        public ColumnDto Column
        {
            get { return _column; }
        }

        public LayoutItemViewModel(ColumnDto column)
        {
            _column = column;
        }
    }
}