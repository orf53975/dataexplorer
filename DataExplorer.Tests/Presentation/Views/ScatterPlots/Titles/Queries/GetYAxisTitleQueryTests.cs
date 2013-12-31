﻿using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Titles.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Titles.Renderers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Titles.Queries
{
    [TestFixture]
    public class GetYAxisTitleQueryTests
    {
        private GetYAxisTitleQuery _query;
        private Mock<IScatterPlotLayoutService> _mockService;
        private Mock<IYAxisTitleRenderer> _mockRenderer;
        private Size _controlSize;
        private ColumnDto _column;
        private CanvasLabel _item;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _column = new ColumnDto() { Name = "Test" };
            _item = new CanvasLabel();

            _mockService = new Mock<IScatterPlotLayoutService>();
            _mockService.Setup(p => p.GetYColumn()).Returns(_column);

            _mockRenderer = new Mock<IYAxisTitleRenderer>();
            _mockRenderer.Setup(p => p.Render(_controlSize, _column.Name)).Returns(_item);

            _query = new GetYAxisTitleQuery(
                _mockService.Object,
                _mockRenderer.Object);
        }

        [Test]
        public void TestExecuteShouldReturnXAxisTitle()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results, Is.EqualTo(_item));
        }

        [Test]
        public void TestExecuteShouldReturnEmptyXAxisTitleIfColumnIsNull()
        {
            _mockService.Setup(p => p.GetYColumn()).Returns((ColumnDto) null);
            _mockRenderer.Setup(p => p.Render(_controlSize, string.Empty)).Returns(_item);
            var result = (CanvasLabel)_query.Execute(_controlSize);
            Assert.That(result, Is.EqualTo(_item));
        }
    }
}
