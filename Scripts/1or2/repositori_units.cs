using System.Collections.Generic;
using Tools.Framework.Repository;
using UnityEngine;

public class Boostraper : MonoBehaviour
{
	public repositori_units Repositori_Units { get; private set; }

    private void Awake()
    {
        Repositori_Units = new repositori_units();
        Repositori_Units.InitOrReload();
    }
}

public class repositori_units : BaseRepository<UnitSelectHelper>
{
    public override void InitOrReload()
    {
		var units = Object.FindObjectsOfType<UnitSelectHelper>();

		foreach(var unit in units)
		{
			TryAdd(unit);
		}

        base.InitOrReload();
    }

	public IEnumerable<UnitSelectHelper> GetMyTeam(int country)
	{
		var filter = new filtr_units()
		{ 
			Country = country,
		};

		return this.GetByFilter(filter);
	}
}

public class filtr_units : IEntityFilter<UnitSelectHelper>
{
	public int? Country { get; set; }
	public HexHelper Position { get; set; }

	public bool Check(UnitSelectHelper entity)
	{
		if(Country == entity.Character.Country)
		{
			return true;
		}
		if(Position == entity.HexHelper)
		{
			return true;
		}
		return false;
	}
}
