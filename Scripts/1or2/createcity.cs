using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEditor;

public class createcity : MonoBehaviour
{
    public GameObject prefab_city;              //префаб города
    private GameObject city;                // создаваемый город
    private Transform position_city;
    //даёт нам информацию о месте постройки города

    public Transform Location { get => position_city; set => position_city = value; }

    public void CreateCity() //метод который создаёт город
    {
        city = Instantiate(prefab_city, Vector3.zero, Quaternion.identity) as GameObject;
        city.transform.parent = Location;
        city.transform.localPosition = Vector3.zero;

        city.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 100;
    }
}
