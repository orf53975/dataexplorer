﻿using System;
using System.Collections.Generic;
using DataExplorer.Presentation.Core.Layout;

namespace DataExplorer.Presentation.Panes.Layout.Location
{
    public interface IXAxisLayoutViewModel
    {
        string Label { get; }

        List<LayoutItemViewModel> Columns { get; }

        LayoutItemViewModel SelectedColumn { get; }
    }
}
