using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEditor;

public class createcity : MonoBehaviour
{
    public GameObject prefab_city;              //������ ������
    public static Transform terrain;                 //������� �� ������� ��������� �����
    private GameObject city;                // ����������� �����
    private Vector2 position_city = terrain.transform.position;
    //��� ��� ���������� � ����� ��������� ������


    void CreateCity() //����� ������� ������ �����
    {
        city = Instantiate(prefab_city, position_city, Quaternion.identity) as GameObject;
    }


}
