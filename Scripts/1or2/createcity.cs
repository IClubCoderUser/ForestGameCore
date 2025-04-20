using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEditor;

public class createcity : MonoBehaviour
{
    public GameObject prefab_city;              //префаб города
    public static Transform terrain;                 //террэйн на котором создается город
    private GameObject city;                // создаваемый город
    private Vector2 position_city = terrain.transform.position;
    //даёт нам информацию о месте постройки города


    void CreateCity() //метод который создаёт город
    {
        city = Instantiate(prefab_city, position_city, Quaternion.identity) as GameObject;
    }


}
