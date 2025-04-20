using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEditor;

public class creatyunits : MonoBehaviour
{
    public GameObject unit_prefab_pexota1;
    public GameObject unit_prefab_pexota2;
    public GameObject unit_prefab_tank1;
    public GameObject unit_prefab_tank2;
    public GameObject unit_prefab_artillery1;
    public GameObject unit_prefab_artillery2;
    private static Transform City;
    private GameObject unit;
    private Vector2 position_unit = City.transform.position;

    void Create_pexota1() { unit = Instantiate(unit_prefab_pexota1, position_unit, Quaternion.identity) as GameObject; }
    void Create_pexota2() { unit = Instantiate(unit_prefab_pexota2, position_unit, Quaternion.identity) as GameObject; }
    void Create_tank1() { unit = Instantiate(unit_prefab_tank1, position_unit, Quaternion.identity) as GameObject; }
    void Create_tank2() { unit = Instantiate(unit_prefab_tank2, position_unit, Quaternion.identity) as GameObject; }
    void Create_artillery1() { unit = Instantiate(unit_prefab_artillery1, position_unit, Quaternion.identity) as GameObject; }
    void Create_artillery2() { unit = Instantiate(unit_prefab_artillery2, position_unit, Quaternion.identity) as GameObject; }


}
