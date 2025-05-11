using System;
using UnityEngine;
using UnityEngine.UI;

public class CityVievModel : MonoBehaviour
{
   public Text CityName;
   public Text TerrainName;

    [Obsolete("надо починить, что-бы не из инспектора")]
    public createcity Createcity;
    
    public void SetLocation(Transform location)
    {
        gameObject.SetActive(true);
        if (Createcity != null)
        { 
            Createcity.Location = location;
        }
    }

    public void ResetImpl() 
    {
        gameObject.SetActive(false);
    }
}
