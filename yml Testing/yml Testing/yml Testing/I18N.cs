using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YamlDotNet.RepresentationModel;

namespace yml_Testing
{
    class I18N : Dictionary<string, string>
    {
        public static I18N Load(string language)
        {
            using (TextReader input = File.OpenText(Path.Combine(@"Localization/" + language.ToLower() + ".yml")))
            {
                var yaml = new YamlStream();
                yaml.Load(input);
                var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
                var items = (YamlMappingNode)mapping.Children[new YamlScalarNode(language.ToLower())];



                //var itemList = new I18N();
                //var itemList = ParseNode(string.Empty, new I18N(), items);
                //foreach (var entry in itemList)
                //{
                //    Console.Out.WriteLine(entry.Key + "   -   " + entry.Value);
                //}

                //Console.In.Read();

                return ParseNode(string.Empty, new I18N(), items);
            }
        }


        public static I18N ParseNode(string lastKey, I18N itemList, YamlMappingNode items)
        {
            foreach (var entry in items)
            {
                if (entry.Value.NodeType == YamlNodeType.Mapping)
                {
                    if (!string.IsNullOrEmpty(lastKey) && lastKey.Substring(lastKey.Length-1) != ".")
                        lastKey += ".";

                    itemList = ParseNode(lastKey + ((YamlScalarNode)entry.Key).Value, itemList, (YamlMappingNode)entry.Value);
                }
                else
                {
                    if(!string.IsNullOrEmpty(lastKey))
                        itemList.Add(lastKey + "." + ((YamlScalarNode)entry.Key).Value, ((YamlScalarNode)entry.Value).Value);
                    else
                        itemList.Add(((YamlScalarNode)entry.Key).Value, ((YamlScalarNode)entry.Value).Value);
                }
            }
            return itemList;
        }

    }
}
