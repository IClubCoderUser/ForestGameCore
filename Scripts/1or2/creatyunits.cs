using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEditor;

public class creatyunits : MonoBehaviour
{

    private static Transform City;
    private GameObject unit;
    private Vector2 position_unit = City.transform.position;
    public void Creat_unit(GameObject gameObject ) { unit = Instantiate(gameObject, position_unit, Quaternion.identity) as GameObject; }
}
