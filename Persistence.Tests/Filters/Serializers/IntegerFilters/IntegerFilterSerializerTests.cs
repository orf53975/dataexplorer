﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Persistence.Common.Serializers;
using DataExplorer.Persistence.Filters.Serializers.IntegerFilters;
using DataExplorer.Persistence.Projects;
using DataExplorer.Persistence.Tests.Common.Serializers;
using DataExplorer.Persistence.Tests.Projects;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Filters.Serializers.IntegerFilters
{
    [TestFixture]
    public class IntegerFilterSerializerTests : SerializerTests
    {
        private IntegerFilterSerializer _serializer;
        private IntegerFilter _filter;
        private List<Column> _columns;
        private Column _column;
        private XElement _xFilter;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().WithId(1).Build();
            _columns = new List<Column> { _column };

            _filter = new IntegerFilter(_column, Int32.MinValue, Int32.MaxValue, true);

            _xFilter = new XElement("integer-filter",
                new XElement("column-id", 1),
                new XElement("lower-value", Int32.MinValue),
                new XElement("upper-value", Int32.MaxValue),
                new XElement("include-null", true));

            _serializer = new IntegerFilterSerializer(
                new PropertySerializer(null));
        }

        [Test]
        public void TestSerializeShouldSerializerColumnId()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "column-id", "1");
            AssertValue(result, "lower-value", Int32.MinValue.ToString());
            AssertValue(result, "upper-value", Int32.MaxValue.ToString());
            AssertValue(result, "include-null", "true");
        }
        
        [Test]
        public void TestDeserializeShouldDeserializeColumn()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.Column, Is.EqualTo(_column));
            Assert.That(result.LowerValue, Is.EqualTo(Int32.MinValue));
            Assert.That(result.UpperValue, Is.EqualTo(Int32.MaxValue));
            Assert.That(result.IncludeNull, Is.True);
        }
    }
}
