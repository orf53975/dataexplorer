﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Rows
{
    public interface IRowRepository
    {
        List<Row> GetAll();
        void Add(Row row);
    }
}