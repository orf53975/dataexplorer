﻿using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.General.Commands
{
    public class ClearLayoutCommandHandler 
        : ICommandHandler<ClearLayoutCommand>
    {
        private readonly IViewRepository _repository;
        private readonly IEventBus _eventBus;

        public ClearLayoutCommandHandler(
            IViewRepository repository, 
            IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public void Execute(ClearLayoutCommand command)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.Clear();

            _eventBus.Raise(new LayoutChangedEvent());
        }
    }
}
