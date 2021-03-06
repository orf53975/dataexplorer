﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Persistence.Filters.Serializers.NullFilters
{
    public interface INullFilterSerializer
    {
        XElement Serialize(NullFilter filter);

        NullFilter Deserialize(XElement xFilter, List<Column> columns);
    }
}
