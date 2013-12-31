﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views;

namespace DataExplorer.Infrastructure.Serializers.Views
{
    public class ViewSetSerializer : IViewSetSerializer
    {
        private static readonly string ViewsTag = "views";

        private readonly IViewSerializer _viewSerializer;

        public ViewSetSerializer(IViewSerializer viewSerializer)
        {
            _viewSerializer = viewSerializer;
        }

        public XElement Serialize(IEnumerable<IView> views)
        {
            var xViews = new XElement(ViewsTag);

            foreach (var view in views)
            {
                var xSource = _viewSerializer.Serialize(view);

                xViews.Add(xSource);
            }

            return xViews;
        }

        public IEnumerable<IView> Deserialize(XElement xViews, IEnumerable<Column> columns)
        {
            var views = new List<IView>();

            foreach (var xView in xViews.Elements())
            {
                var view = _viewSerializer.Deserialize(xView, columns);

                views.Add(view);
            }

            return views;
        }
    }
}
