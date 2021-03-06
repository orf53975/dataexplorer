﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Tests.Colors;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Persistence.Common.Serializers;
using DataExplorer.Persistence.Projects;
using DataExplorer.Persistence.Views.Serializers.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Views.Serializers.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotLayoutSerializerTests
    {
        private ScatterPlotLayoutSerializer _serializer;
        private Mock<IColorPaletteFactory> _mockColorPaletteFactory;
        private ScatterPlotLayout _layout;
        private List<Column> _columns; 
        private Column _xAxisColumn;
        private Column _yAxisColumn;
        private Column _colorColumn;
        private ColorPalette _colorPalette;
        private Column _sizeColumn;
        private Column _shapeColumn;
        private Column _labelColumn;
        private Column _linkColumn;
        private XElement _xLayout;

        [SetUp]
        public void SetUp()
        {
            _xAxisColumn = new ColumnBuilder().WithId(1).Build();
            _yAxisColumn = new ColumnBuilder().WithId(2).Build();
            _colorColumn = new ColumnBuilder().WithId(3).Build();
            _colorPalette = new ColorPaletteBuilder().WithName("Pastel 1").Build();
            _sizeColumn = new ColumnBuilder().WithId(4).Build();
            _shapeColumn = new ColumnBuilder().WithId(5).Build();
            _labelColumn = new ColumnBuilder().WithId(6).Build();
            _linkColumn = new ColumnBuilder().WithId(7).Build();

            _columns = new List<Column>
            {
                _xAxisColumn, 
                _yAxisColumn, 
                _colorColumn, 
                _sizeColumn,
                _labelColumn,
                _shapeColumn,
                _linkColumn
            };

            _layout = new ScatterPlotLayout
            {
                XAxisColumn = _xAxisColumn,
                XAxisSortOrder = SortOrder.Descending,
                YAxisColumn = _yAxisColumn,
                YAxisSortOrder = SortOrder.Descending,
                ColorColumn = _colorColumn,
                ColorSortOrder = SortOrder.Descending,
                ColorPalette = _colorPalette,
                SizeColumn = _sizeColumn,
                SizeSortOrder = SortOrder.Descending,
                LowerSize = 0.1d,
                UpperSize = 0.9d,
                ShapeColumn = _shapeColumn,
                LabelColumn = _labelColumn,
                LinkColumn = _linkColumn
            };

            _xLayout = new XElement("layout",
                new XElement("x-axis-column-id", 1),
                new XElement("x-axis-sort-order", "Descending"),
                new XElement("y-axis-column-id", 2),
                new XElement("y-axis-sort-order", "Descending"),
                new XElement("color-column-id", 3),
                new XElement("color-sort-order", "Descending"),
                new XElement("color-palette-name", "Pastel 1"),
                new XElement("size-column-id", 4),
                new XElement("size-sort-order", "Descending"),
                new XElement("lower-size", 0.1d),
                new XElement("upper-size", 0.9d),
                new XElement("shape-column-id", 5),
                new XElement("label-column-id", 6),
                new XElement("link-column-id", 7));
           
            _mockColorPaletteFactory = new Mock<IColorPaletteFactory>();
            _mockColorPaletteFactory.Setup(p => p.GetColorPalette("Pastel 1"))
                .Returns(_colorPalette);

            _serializer = new ScatterPlotLayoutSerializer(
                new PropertySerializer(null),
                _mockColorPaletteFactory.Object);
        }

        [Test]
        public void TestSerializeShouldSerializeLayout()
        {
            var result = _serializer.Serialize(_layout);
            AssertValue(result, "x-axis-column-id", "1");
            AssertValue(result, "x-axis-sort-order", "Descending");
            AssertValue(result, "y-axis-column-id", "2");
            AssertValue(result, "y-axis-sort-order", "Descending");
            AssertValue(result, "color-column-id", "3");
            AssertValue(result, "color-sort-order", "Descending");
            AssertValue(result, "color-palette-name", "Pastel 1");
            AssertValue(result, "size-column-id", "4");
            AssertValue(result, "size-sort-order", "Descending");
            AssertValue(result, "lower-size", "0.1");
            AssertValue(result, "upper-size", "0.9");
            AssertValue(result, "shape-column-id", "5");
            AssertValue(result, "label-column-id", "6");
            AssertValue(result, "link-column-id", "7");
        }

        private void AssertValue(XElement result, string name, object value)
        {
            Assert.That(result.Elements().First(p => p.Name.LocalName == name).Value, 
                Is.EqualTo(value));
        }

        [Test]
        public void TestDeserializeShoulDeserializeLayout()
        {
            var result = _serializer.Deserialize(_xLayout, _columns);
            Assert.That(result.XAxisColumn, Is.EqualTo(_xAxisColumn));
            Assert.That(result.XAxisSortOrder, Is.EqualTo(SortOrder.Descending));
            Assert.That(result.YAxisColumn, Is.EqualTo(_yAxisColumn));
            Assert.That(result.YAxisSortOrder, Is.EqualTo(SortOrder.Descending));
            Assert.That(result.ColorColumn, Is.EqualTo(_colorColumn));
            Assert.That(result.ColorSortOrder, Is.EqualTo(SortOrder.Descending));
            Assert.That(result.ColorPalette, Is.EqualTo(_colorPalette));
            Assert.That(result.SizeColumn, Is.EqualTo(_sizeColumn));
            Assert.That(result.SizeSortOrder, Is.EqualTo(SortOrder.Descending));
            Assert.That(result.LowerSize, Is.EqualTo(0.1d));
            Assert.That(result.UpperSize, Is.EqualTo(0.9d));
            Assert.That(result.ShapeColumn, Is.EqualTo(_shapeColumn));
            Assert.That(result.LabelColumn, Is.EqualTo(_labelColumn));
            Assert.That(result.LinkColumn, Is.EqualTo(_linkColumn));
        }
    }
}
