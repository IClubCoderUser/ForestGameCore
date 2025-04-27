
using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;


public class NewBehaviourScript : MonoBehaviour
{
  
    public static Vector2 position_soldger;
    public static Vector2 position_terrain;
    public byte Allians;
    public GameObject city2;
 
   
    Boostraper _units = Object.FindObjectOfType<Boostraper>();
   


    private void NextStep()
    {
        var SOLDATI = _units.Repositori_Units.GetByFilter(new filtr_units()
        {
            IsBuild = false,
        });

        var BUILDS = _units.Repositori_Units.GetByFilter(new filtr_units() 
        { 
            IsBuild = true
        });

        foreach (var build in BUILDS) 
        {
            var distance_of_build_and_unit = SOLDATI.Min(x => Vector2.Distance(x.transform.position, build.transform.position));
            var soldat = SOLDATI.FirstOrDefault(x => Vector2.Distance(x.transform.position, build.transform.position) == distance_of_build_and_unit);

            if (soldat != null && distance_of_build_and_unit < 2)
            {
                foreach (var item in city2.GetComponentsInChildren<Renderer>())
                {
                    item.material.color = soldat.colour;
                }
            }
        }
    }

}

