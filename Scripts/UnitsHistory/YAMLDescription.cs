using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using YamlDotNet.RepresentationModel;
public class YAMLDescription : MonoBehaviour
{
    void Start()
    {
        var type = gameObject.GetComponent<Character>().unitType;
        var reader = new StreamReader("/Assets/Data/Resources/UnitDescription/unitinfo.yaml");
        var yaml = new YamlStream();
        yaml.Load(reader);

        var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

        var name = mapping[new YamlScalarNode($"{type}: name")].ToString();
        var desc = mapping[new YamlScalarNode($"{type}: desc")].ToString();
        var flag = mapping[new YamlScalarNode($"{type}: flag")].ToString();

        var fullscreen = bool.Parse(mapping[new YamlScalarNode("fullscreen")].ToString());

        Debug.Log($"Name: {type}");

        // Apply additional settings as needed
        reader.Close();
    }
}