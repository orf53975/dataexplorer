﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataExplorer.Infrastructure.Serializers.Properties
{
    public interface IPropertySerializer
    {
        XElement Serialize<T>(string name, T value);

        XElement SerializeList<T>(string listName, List<T> value);

        T Deserialize<T>(XElement xProperty);

        List<T> DeserializeList<T>(XElement xProperty);

        object Deserialize(XElement xProperty, Type type);
    }
}
