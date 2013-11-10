﻿using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Factories.FloatAxisGridLines
{
    public class FloatAxisGridLineFactory : IFloatAxisGridLineFactory
    {
        public IEnumerable<AxisGridLine> Create(IAxisMap map, double lower, double upper)
        {
            var lowerFloat = (double) map.MapInverse(lower) / 2;

            var upperFloat = (double) map.MapInverse(upper) / 2;

            if (lowerFloat <=  double.MinValue / 2)
                yield return CreateAxisGridLine(map, double.MinValue);

            if (upperFloat >= double.MaxValue / 2)
                yield return CreateAxisGridLine(map, double.MaxValue);
            
            var width = (double)upperFloat - lowerFloat;
            var step = 0d;
            var start = double.MinValue;

            for (var i = 0.0000000001; i < double.MaxValue; i *= 10)
            {
                double i2 = i / 2;

                if (width >= i2 && width < i2 * 20)
                {
                    step = i2;
                    start = lowerFloat - (lowerFloat % i2);
                    break;
                }
            }

            if (step == 0d)
                yield break;

            for (var i = start; i <= upperFloat; i += step)
                yield return CreateAxisGridLine(map, i * 2);
        }

        private AxisGridLine CreateAxisGridLine(IAxisMap map,  double value)
        {
            var line = new AxisGridLine()
            {
                Position = GetPosition(map, value),
                LabelName = GetLabelName(value)
            };

            return line;
        }

        private double GetPosition(IAxisMap map, double value)
        {
            return map.Map(value).GetValueOrDefault();
        }

        private string GetLabelName(double value)
        {
            if (value <= -1000000d || value >= 1000000d 
                || (value >= -0.001d && value <= 0.001d && value != 0d))
                return value.ToString("E2");

            return value.ToString("N2");
        }
    }
}
