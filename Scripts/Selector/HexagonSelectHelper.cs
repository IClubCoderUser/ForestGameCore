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
			Debug.LogError($"Нехватает компонента: {nameof(SelectObjects)}. Добавьте его на сцену.");
		}
	}
}