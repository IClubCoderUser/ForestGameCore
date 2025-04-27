
using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEditor;


public class NewBehaviourScript : MonoBehaviour
{
    public GameObject soldger;
    public static Vector2 position_soldger;
    public static Vector2 position_terrain;
    private bool BeUnitInCityOrNotBe;
    public bool city1;
    private bool soldger1;
    private float Distance = Vector2.Distance(position_soldger, position_terrain);

    GameObject[] units = GameObject.FindGameObjectsWithTag("units");
    float distance = Mathf.Infinity;


    private void NextStep()
    {

        foreach (var element in units)
        {
            //float Distance = Vector2.Distance(element, position_terrain);
            //if (Distance < distance) distance = Distance;

        }


        if (distance < 1)
        {
            BeUnitInCityOrNotBe = true;
        }

        else
        {
            BeUnitInCityOrNotBe = false;
        }
        if (BeUnitInCityOrNotBe == true)
        {
            soldger1 = city1;

        }
    }

}

