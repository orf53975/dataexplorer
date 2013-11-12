﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Maps;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Factories;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Labels.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Labels.Renderers;
using DataExplorer.Tests.Application.Maps;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.AxisGrid.Labels.Queries
{
    [TestFixture]
    public class GetScatterPlotXAxisGridLineLabelsQueryTests
    {
        private GetScatterPlotXAxisGridLabelsQuery _query;
        private Mock<IScatterPlotService> _mockScatterPlotService;
        private Mock<IScatterPlotLayoutService> _mockLayoutService;
        private Mock<IMapService> _mockMapService;
        private Mock<IColumnService> _mockColumnService;
        private Mock<IScatterPlotAxisGridLineFactory> _mockFactory;
        private Mock<IXAxisGridLabelRenderer> _mockRenderer;
        private Size _controlSize;
        private Rect _viewExtent;
        private ColumnDto _columnDto;
        private List<string> _values;
        private IAxisMap _axisMap;
        private List<AxisGridLine> _axisLines;
        private AxisGridLine _axisGridLine;
        private List<CanvasLabel> _canvasLabels;
        private CanvasLabel _canvasLabel;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _viewExtent = new Rect();
            _columnDto = new ColumnDto() { Type = typeof(object) };
            _values = new List<string>();
            _axisMap = new FakeAxisMap();
            _axisGridLine = new AxisGridLine();
            _axisLines = new List<AxisGridLine> { _axisGridLine };
            _canvasLabel = new CanvasLabel();
            _canvasLabels = new List<CanvasLabel> { _canvasLabel };

            _mockScatterPlotService = new Mock<IScatterPlotService>();
            _mockScatterPlotService.Setup(p => p.GetViewExtent()).Returns(_viewExtent);

            _mockLayoutService = new Mock<IScatterPlotLayoutService>();
            _mockLayoutService.Setup(p => p.GetXColumn()).Returns(_columnDto);

            _mockColumnService = new Mock<IColumnService>();
            _mockColumnService.Setup(p => p.GetDistinctColumnValues(_columnDto.Id)).Returns(_values);

            _mockMapService = new Mock<IMapService>();
            _mockMapService.Setup(p => p.GetAxisMap(_columnDto, 0d, 1d)).Returns(_axisMap);

            _mockFactory = new Mock<IScatterPlotAxisGridLineFactory>();
            _mockFactory.Setup(p => p.Create(typeof(object), _axisMap, _values, _viewExtent.Left, _viewExtent.Right)).Returns(_axisLines);

            _mockRenderer = new Mock<IXAxisGridLabelRenderer>();
            _mockRenderer.Setup(p => p.Render(_axisLines, _viewExtent, _controlSize)).Returns(_canvasLabels);

            _query = new GetScatterPlotXAxisGridLabelsQuery(
                _mockScatterPlotService.Object,
                _mockLayoutService.Object,
                _mockMapService.Object,
                _mockColumnService.Object,
                _mockFactory.Object,
                _mockRenderer.Object);
        }

        [Test]
        public void TestExecuteShouldReturnEmptyListIfColumnDtoIsNull()
        {
            _mockLayoutService.Setup(p => p.GetXColumn()).Returns((ColumnDto)null);
            var results = _query.Execute(_controlSize);
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void TestExecuteShouldReturnGridLineLabels()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_canvasLabel));
        }
    }
}