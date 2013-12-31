﻿using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Views.ScatterPlots.Events;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Commands;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Queries;

namespace DataExplorer.Application.Views.ScatterPlots
{
    public class ScatterPlotLayoutService : 
        IScatterPlotLayoutService, 
        IEventHandler<ProjectOpenedEvent>,
        IEventHandler<ProjectClosedEvent>,
        IEventHandler<CsvFileImportedEvent>
    {
        private readonly IGetXColumnQuery _getXColumnQuery;
        private readonly ISetXColumnCommand _setXColumnCommand;
        private readonly IGetYColumnQuery _getYColumnQuery;
        private readonly ISetYColumnCommand _setYColumnCommand;
        private readonly IClearLayoutCommand _clearLayoutCommand;
        private readonly IEventBus _eventBus;

        public ScatterPlotLayoutService(
            IGetXColumnQuery getXColumnQuery,
            ISetXColumnCommand setXColumnCommand,
            IGetYColumnQuery getYColumnQuery,
            ISetYColumnCommand setYColumnCommand,
            IClearLayoutCommand clearLayoutCommand,
            IEventBus eventBus)
        {
            _getXColumnQuery = getXColumnQuery;
            _setXColumnCommand = setXColumnCommand;
            _getYColumnQuery = getYColumnQuery;
            _setYColumnCommand = setYColumnCommand;
            _clearLayoutCommand = clearLayoutCommand;
            _eventBus = eventBus;
        }

        public ColumnDto GetXColumn()
        {
            return _getXColumnQuery.Query();
        }

        public void SetXColumn(ColumnDto columnDto)
        {
            _setXColumnCommand.Execute(columnDto);
        }

        public ColumnDto GetYColumn()
        {
            return _getYColumnQuery.Query();
        }

        public void SetYColumn(ColumnDto columnDto)
        {
            _setYColumnCommand.Execute(columnDto);
        }

        public void ClearLayout()
        {
            _clearLayoutCommand.Execute();
        }

        public void Handle(ProjectOpenedEvent args)
        {
            _eventBus.Raise(new ScatterPlotLayoutChangedEvent());
        }

        public void Handle(ProjectClosedEvent args)
        {
            _eventBus.Raise(new ScatterPlotLayoutChangedEvent());
        }

        public void Handle(CsvFileImportedEvent args)
        {
            _eventBus.Raise(new ScatterPlotLayoutChangedEvent());
        }
    }
}