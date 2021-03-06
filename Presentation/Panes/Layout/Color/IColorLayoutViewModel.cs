﻿using System;
using System.Collections.Generic;
using DataExplorer.Presentation.Core.Layout;

namespace DataExplorer.Presentation.Panes.Layout.Color
{
    public interface IColorLayoutViewModel
    {
        string Label { get; }

        List<LayoutItemViewModel> Columns { get; }

        LayoutItemViewModel SelectedColumn { get; }

        List<ColorPaletteViewModel> ColorPalettes { get; }

        ColorPaletteViewModel SelectedColorPalette { get; }
    }
}
