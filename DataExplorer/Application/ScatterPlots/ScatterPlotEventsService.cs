﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Events;
using DataExplorer.Application.Importers;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots
{
    public class ScatterPlotEventsService : 
        IDomainHandler<ProjectOpenedEvent>,
        IDomainHandler<ProjectClosedEvent>,
        IDomainHandler<ScatterPlotLayoutChangedEvent>,
        IAppHandler<CsvFileImportedEvent>
    {
        private readonly IRowRepository _rowRepository;
        private readonly IViewRepository _viewRepository;
        private readonly IScatterPlotRenderer _renderer;

        public ScatterPlotEventsService(
            IRowRepository rowRepository,
            IViewRepository viewRepository,
            IScatterPlotRenderer renderer)
        {
            _rowRepository = rowRepository;
            _viewRepository = viewRepository;
            _renderer = renderer;
        }

        public void Handle(ProjectOpenedEvent args)
        {
            UpdatePlots();
        }

        public void Handle(ProjectClosedEvent args)
        {
            UpdatePlots();
        }

        public void Handle(ScatterPlotLayoutChangedEvent args)
        {
            UpdatePlots();
        }

        public void Handle(CsvFileImportedEvent args)
        {
            UpdatePlots();
        }

        private void UpdatePlots()
        {
            var rows = _rowRepository.GetAll();

            var scatterPlot = _viewRepository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var plots = _renderer.RenderPlots(rows, layout);

            scatterPlot.SetPlots(plots);
        }
    }
}