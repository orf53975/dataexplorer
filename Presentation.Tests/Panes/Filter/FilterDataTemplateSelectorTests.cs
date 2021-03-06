﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Panes.Filter;
using DataExplorer.Presentation.Panes.Filter.BooleanFilters;
using DataExplorer.Presentation.Panes.Filter.DateTimeFilters;
using DataExplorer.Presentation.Panes.Filter.FloatFilters;
using DataExplorer.Presentation.Panes.Filter.ImageFilters;
using DataExplorer.Presentation.Panes.Filter.IntegerFilters;
using DataExplorer.Presentation.Panes.Filter.NullFilters;
using DataExplorer.Presentation.Panes.Filter.StringFilters;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter
{
    [TestFixture]
    public class FilterDataTemplateSelectorTests
    {
        private FilterDataTemplateSelector _selector;
        private DataTemplate _dataTemplate;

        [SetUp]
        public void SetUp()
        {
            _dataTemplate = new DataTemplate();

            _selector = new FilterDataTemplateSelector();
        }

        [Test]
        public void TestSelectTemplateShouldReturnBooleanFilterDataTemplate()
        {
            _selector.BooleanFilterDataTemplate = _dataTemplate;
            var result = _selector.SelectTemplate(new BooleanFilterViewModel(null, null), null);
            Assert.That(result, Is.EqualTo(_dataTemplate));
        }

        [Test]
        public void TestSelectTemplateShouldReturnDateRangeFilterDataTemplate()
        {
            _selector.DateRangeFilterDataTemplate = _dataTemplate;
            var result = _selector.SelectTemplate(new DateRangeFilterViewModel(null, null), null);
            Assert.That(result, Is.EqualTo(_dataTemplate));
        }

        [Test]
        public void TestSelectTemplateShouldReturnFloatRangeFilterDataTemplate()
        {
            _selector.FloatRangeFilterDataTemplate = _dataTemplate;
            var result = _selector.SelectTemplate(new FloatRangeFilterViewModel(null, null), null);
            Assert.That(result, Is.EqualTo(_dataTemplate));
        }

        [Test]
        public void TestSelectTemplateShouldReturnIntegerRangeFilterDataTemplate()
        {
            _selector.IntegerRangeFilterDataTemplate = _dataTemplate;
            var result = _selector.SelectTemplate(new IntegerRangeFilterViewModel(null, null), null);
            Assert.That(result, Is.EqualTo(_dataTemplate));
        }

        [Test]
        public void TestSelectTemplateShouldReturnNullFilterDataTemplate()
        {
            _selector.NullFilterDataTemplate = _dataTemplate;
            var result = _selector.SelectTemplate(new NullFilterViewModel(null, null), null);
            Assert.That(result, Is.EqualTo(_dataTemplate));
        }

        [Test]
        public void TestSelectTemplateShouldReturnStringFilterDataTemplate()
        {
            _selector.StringFilterDataTemplate = _dataTemplate;
            var result = _selector.SelectTemplate(new StringFilterViewModel(null, null), null);
            Assert.That(result, Is.EqualTo(_dataTemplate));
        }

        [Test]
        public void TestSelectTemplateShouldReturnImageFilterDataTemplate()
        {
            _selector.ImageFilterDataTemplate = _dataTemplate;
            var result = _selector.SelectTemplate(new ImageFilterViewModel(null, null), null);
            Assert.That(result, Is.EqualTo(_dataTemplate));
        }
    }
}
