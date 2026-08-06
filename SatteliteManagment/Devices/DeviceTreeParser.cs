using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SatteliteManagment
{
    internal static class DeviceTreeParser
    {
        public static List<DeviceNode> ParseFromFile(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);
            XElement root = doc.Root ?? throw new InvalidOperationException("XML root is missing.");

            IEnumerable<XElement> nodeElements = IsSupportedNodeElement(root)
                ? new[] { root }
                : root.Elements().Where(IsSupportedNodeElement);

            return nodeElements.Select(ParseNodeElement).ToList();
        }

        private static bool IsSupportedNodeElement(XElement element)
        {
            string localName = element.Name.LocalName;
            return localName.Equals("device", StringComparison.OrdinalIgnoreCase)
                   || localName.Equals("attribute", StringComparison.OrdinalIgnoreCase);
        }

        private static DeviceNode ParseNodeElement(XElement element)
        {
            string elementType = element.Name.LocalName.ToLowerInvariant();

            DeviceNode node = new DeviceNode
            {
                Id = (string)element.Attribute("id") ?? string.Empty,
                Name = (string)element.Attribute("name") ?? (elementType == "attribute" ? "Unnamed attribute" : "Unnamed device"),
                Type = elementType == "device"
                    ? ((string)element.Attribute("type") ?? "generic")
                    : "attribute"
            };

            foreach (XElement metaElement in element.Elements().Where(e => e.Name.LocalName.Equals("meta", StringComparison.OrdinalIgnoreCase)))
            {
                string key = (string)metaElement.Attribute("key") ?? string.Empty;
                if (string.IsNullOrWhiteSpace(key))
                {
                    continue;
                }

                string valueFromAttribute = (string)metaElement.Attribute("value");
                string value = valueFromAttribute ?? (metaElement.Value ?? string.Empty).Trim();
                node.Meta[key] = value;
            }

            foreach (XElement childElement in element.Elements().Where(IsSupportedNodeElement))
            {
                node.Children.Add(ParseNodeElement(childElement));
            }

            DeviceNode statusAttributeNode = node.Children.FirstOrDefault(
                c => c.Type.Equals("attribute", StringComparison.OrdinalIgnoreCase)
                     && c.Id.Equals("status", StringComparison.OrdinalIgnoreCase));
            if (statusAttributeNode != null)
            {
                node.Status = statusAttributeNode.Name;
            }

            return node;
        }
    }
}
