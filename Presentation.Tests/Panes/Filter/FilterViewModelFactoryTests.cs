﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Filters;
using DataExplorer.Presentation.Panes.Filter;
using DataExplorer.Presentation.Panes.Filter.BooleanFilters;
using DataExplorer.Presentation.Panes.Filter.DateTimeFilters;
using DataExplorer.Presentation.Panes.Filter.FloatFilters;
using DataExplorer.Presentation.Panes.Filter.ImageFilters;
using DataExplorer.Presentation.Panes.Filter.IntegerFilters;
using DataExplorer.Presentation.Panes.Filter.NullFilters;
using DataExplorer.Presentation.Panes.Filter.StringFilters;
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
        public void TestCreateShouldCreateBooleanFilter()
        {
            var filter = new BooleanFilter(null, true, true, true);
            var result = _factory.Create(filter);
            Assert.That(result, Is.TypeOf<BooleanFilterViewModel>());
            Assert.That(result.Filter, Is.EqualTo(filter));
        }

        [Test]
        public void TestCreateShouldCreateDateRangeFilter()
        {
            var filter = new DateTimeFilter(null, DateTime.MinValue, DateTime.MaxValue, true);
            var result = _factory.Create(filter);
            Assert.That(result, Is.TypeOf<DateRangeFilterViewModel>());
            Assert.That(result.Filter, Is.EqualTo(filter));
        }

        [Test]
        public void TestCreateShouldCreateFloatRangeFilter()
        {
            var filter = new FloatFilter(null, double.MinValue, double.MaxValue, true);
            var result = _factory.Create(filter);
            Assert.That(result, Is.TypeOf<FloatRangeFilterViewModel>());
            Assert.That(result.Filter, Is.EqualTo(filter));
        }

        [Test]
        public void TestCreateShouldCreateIntegerRangeFilter()
        {
            var filter = new IntegerFilter(null, int.MinValue, int.MaxValue, true);
            var result = _factory.Create(filter);
            Assert.That(result, Is.TypeOf<IntegerRangeFilterViewModel>());
            Assert.That(result.Filter, Is.EqualTo(filter));
        }

        [Test]
        public void TestCreateShouldCreateNullFilter()
        {
            var filter = new NullFilter(null);
            var result = _factory.Create(filter);
            Assert.That(result, Is.TypeOf<NullFilterViewModel>());
            Assert.That(result.Filter, Is.EqualTo(filter));
        }

        [Test]
        public void TestCreateShouldCreateStringFilter()
        {
            var filter = new StringFilter(null, string.Empty, true);
            var result = _factory.Create(filter);
            Assert.That(result, Is.TypeOf<StringFilterViewModel>());
            Assert.That(result.Filter, Is.EqualTo(filter));
        }

        [Test]
        public void TestCreateShouldCreateImageFilter()
        {
            var filter = new ImageFilter(null, true, true);
            var result = _factory.Create(filter);
            Assert.That(result, Is.TypeOf<ImageFilterViewModel>());
            Assert.That(result.Filter, Is.EqualTo(filter));
        }
    }
}
