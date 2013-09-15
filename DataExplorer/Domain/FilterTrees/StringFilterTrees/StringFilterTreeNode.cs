﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.StringFilterTrees
{
    public abstract class StringFilterTreeNode : FilterTreeNode
    {
        protected StringFilterTreeNode(string name, Column column) 
            : base(name, column)
        {
        }
    }
}
