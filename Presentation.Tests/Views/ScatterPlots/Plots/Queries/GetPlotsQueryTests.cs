﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Plots.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Plots.Renderers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Plots.Queries
{
    [TestFixture]
    public class GetPlotsQueryTests
    {
        private GetPlotsQuery _query;
        private Mock<IScatterPlotService> _mockService;
        private Mock<IPlotRenderer> _mockRenderer;
        private Size _controlSize;
        private Rect _viewExtent;
        private List<PlotDto> _plotDtos;
        private PlotDto _plotDto;
        private List<CanvasItem> _items;
        private CanvasItem _item;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _viewExtent = new Rect();
            _plotDtos = new List<PlotDto> { _plotDto };
            _plotDto = new PlotDto();
            _item = new CanvasCircle();
            _items = new List<CanvasItem> { _item };

            _mockService = new Mock<IScatterPlotService>();
            _mockService.Setup(p => p.GetViewExtent()).Returns(_viewExtent);
            _mockService.Setup(p => p.GetPlots()).Returns(_plotDtos);

            _mockRenderer = new Mock<IPlotRenderer>();
            _mockRenderer.Setup(p => p.RenderPlots(_controlSize, _viewExtent, _plotDtos)).Returns(_items);

            _query = new GetPlotsQuery(
                _mockService.Object,
                _mockRenderer.Object);
        }

        [Test]
        public void TestExecuteShouldReturnPlots()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_item));
        }
    }
}