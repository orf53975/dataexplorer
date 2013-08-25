﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Application.Serialization;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Sources;
using DataExplorer.Persistence;
using DataExplorer.Persistence.Columns;
using DataExplorer.Persistence.Rows;
using DataExplorer.Persistence.Views;
using DataExplorer.Presentation.Shell.MainMenu.FileMenu;
using DataExplorer.Presentation.Shell.MainWindow;
using Moq;

namespace DataExplorer.Specs
{
    public class Context
    {
        public MainWindowViewModel MainWindowViewModel;
        public IFileMenuViewModel FileMenuViewModel;
        
        public Mock<IApplicationService> MockApplicationService;
        public Mock<ISerializationService> MockSerializationService;

        public Project Project;
        public CsvFileSource CsvFileSource;
        public Column Column;
        public Row Row;
        public ScatterPlot ScatterPlot;

        public IDataContext DataContext;
    }
}