﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Filters;
using DataExplorer.Presentation.Panes.Filter;
using DataExplorer.Presentation.Panes.Filter.BooleanFilters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter
{
    [TestFixture]
    public class FilterViewModelFactoryTests
    {
        private FilterViewModelFactory _factory;
        private Mock<ICommandBus> _mockCommandBus;

        [SetUp]
        public void SetUp()
        {
            _mockCommandBus = new Mock<ICommandBus>();

            _factory = new FilterViewModelFactory(
                _mockCommandBus.Object);
        }

        [Test]
        public void TestCreateShouldCreateBooleanFilterFactory()
        {
            var filter = new BooleanFilter(null, true, true, true);
            var result = _factory.Create(filter);
            Assert.That(result, Is.TypeOf<BooleanFilterViewModel>());
            Assert.That(result.Filter, Is.EqualTo(filter));
        }
    }
}