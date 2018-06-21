using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Sitecore.Support.ContentSearch.SolrProvider
{
  [Serializable]
  public class SolrSearchFieldConfiguration : Sitecore.ContentSearch.SolrProvider.SolrSearchFieldConfiguration
  {
    public SolrSearchFieldConfiguration() : base() { }

    public SolrSearchFieldConfiguration(SolrSearchFieldConfiguration configuration) : base(configuration) { }

    public SolrSearchFieldConfiguration(string typeName, IDictionary<string, string> attributes, XmlNode configNode) : base(typeName, attributes, configNode) { }

    public override object FormatForReading(object valueFromIndex)
    {
      if (valueFromIndex == null) return null;

      if (valueFromIndex is IEnumerable)
      {
        foreach (string str in (IEnumerable)valueFromIndex)
        {
          if (str == this.NullValue)
          {
            return null;
          }
        }
      }

      var stringValue = valueFromIndex as string;
      if (stringValue != null)
      {
        if (stringValue == this.NullValue) return null;

        if (stringValue == string.Empty || stringValue == this.EmptyString) return string.Empty;
      }

      return valueFromIndex;
    }
  }
}