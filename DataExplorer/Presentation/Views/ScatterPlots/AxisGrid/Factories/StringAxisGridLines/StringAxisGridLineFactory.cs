﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Factories.StringAxisGridLines
{
    public class StringAxisGridLineFactory : IStringAxisGridLineFactory
    {
        private const int AlphaGroupMin = 10;
        private const char StartChar = (char) 32;
        private const char EndChar = (char) 96;

        public IEnumerable<AxisGridLine> Create(IAxisMap map, List<object> values,  double lower, double upper)
        {
            var count = values
                .Select(map.Map)
                .Count(p => p >= lower 
                    && p <= upper);

            return (count <= AlphaGroupMin)
                ? CreateValueGridLines(map, values, lower, upper)
                : CreateAlphaGridLines(map, values.Cast<string>().ToList(), lower, upper);
        }

        private IEnumerable<AxisGridLine> CreateValueGridLines(IAxisMap map, List<object> values, double lower, double upper)
        {
            foreach (var value in values)
            {
                var location = map.Map(value).GetValueOrDefault();

                if (location >= lower && location <= upper)
                    yield return CreateAxisGridLine(location, value.ToString());
            }
        }

        private IEnumerable<AxisGridLine> CreateAlphaGridLines(IAxisMap map, List<string> values, double lower, double upper)
        {
            var lowerString = (string) map.MapInverse(lower);

            var upperString = (string) map.MapInverse(upper);

            var lowerChar = IsFirstCharacterValid(lowerString) 
                ? lowerString[0]
                : StartChar;

            var upperChar = IsFirstCharacterValid(upperString)
                ? upperString[0]
                : EndChar;

            for (var c = lowerChar; c <= upperChar; c++)
            {
                var first = values.Where(p => p != string.Empty)
                    .FirstOrDefault(p => p[0].ToString().ToUpper() == c.ToString().ToUpper());

                if (first != null)
                    yield return CreateAxisGridLine(map.Map(first).GetValueOrDefault(), c.ToString().ToUpper());
            }
        }

        private static bool IsFirstCharacterValid(string lowerString)
        {
            return lowerString != string.Empty 
                && Char.IsLetter(lowerString[0]);
        }

        private AxisGridLine CreateAxisGridLine(double position, string label)
        {
            return new AxisGridLine()
            {
                Position = position,
                LabelName = label
            };
        }
    }
}