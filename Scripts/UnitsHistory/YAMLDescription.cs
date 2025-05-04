using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using YamlDotNet.Serialization;

public class Tan
{
    public string Name { get; set; }
    public string Decs { get; set; }
    public string Flag { get; set; }

}
public class YAMLDescription : MonoBehaviour
{
    void Start()
    {
        //var _target = GetComponent<SelectObjects>().SelectedObject.gameObject;
        var _unittype = GetComponent<SelectObjects>().SelectedObject.gameObject.GetComponent<Character>().unitType; // О боже, что это за нечто....
        //Deserialize();

    }

    private void Update()
    {
        var _unittype = GetComponent<SelectObjects>().SelectedObject.gameObject.GetComponent<Character>().unitType; // О боже, что это за нечто....

        var yamlFilePath = "Assets/Data/Resources/UnitDescription/unitinfo.yaml";
        var yamlContent = File.ReadAllText(yamlFilePath);

        var desirializer = new DeserializerBuilder().Build();
        var tanks = desirializer.Deserialize<Dictionary<string, Tank>>(yamlContent);

        if (tanks.TryGetValue(_unittype, out Tank tank))
        {

        }
    }

}