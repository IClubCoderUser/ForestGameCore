using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HexHelper))]
public class HexagonSelectHelper : MonoBehaviour
{
	void Start()
	{
		if(SelectObjects.terrainunit != null)
		{
			SelectObjects.terrainunit.Add(this);
		}
		else
		{
			Debug.LogError($"��������� ����������: {nameof(SelectObjects)}. �������� ��� �� �����.");
		}
	}
}