using Assets.UI.Flags;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using YamlDotNet.Serialization;

public class Tank
{
    public string Name { get; set; }
    public string Decs { get; set; }
    public string Flag { get; set; }

}

public class Character : MonoBehaviour
{
	/// <summary>Ёто макс хп персонажа.</summary>
	public float Hp = 150;
	/// <summary>Ёто брон€ персонажа.</summary>
	public float Defense = 120;
	/// <summary>Ёто атака персонажа.</summary>
	public float Attack = 60;
	/// <summary>Ёто насколько персонаж может двинутьс€ за раз.</summary>
	public float MoveCirclesMany = 3;
	/// <summary>Ёто максимальна€ дальность персонажа.</summary>
	public float AttackCircles = 8;
	public float Crit = 90;
	public float hpCurrernt;
	public float defCurrent;

	public int Country;

	public int Speed = 2;

	public SpriteRenderer hpbar;
	public SpriteRenderer defbar;
	public FlagObject FlagsObject;

	public string objectname;
	public string description;

	public FlagsEnum Flags;

	/// <summary>“ип юнита.</summary>
	public string unitType; 

	// Start is called before the first frame update
	void Start()
	{
		hpCurrernt = Hp;
		defCurrent = Defense;

		if(FlagsObject != null)
		{
			FlagsObject.Country = Flags;
		}
	}


	// Update is called once per frame
	void Update()
	{
        var yamlFilePath = "Assets/Data/Resources/UnitDescription/unitinfo.yaml";
        var yamlContent = File.ReadAllText(yamlFilePath);

        var desirializer = new DeserializerBuilder().Build();
        var tanks = desirializer.Deserialize<Dictionary<string, Tank>>(yamlContent);

        if (tanks.TryGetValue(unitType, out Tank tank))
        {
            objectname = tank.Name;
			description = tank.Decs;
        }
    }

	[UnityEngine.ContextMenu("damagetest")]
	private void damagetest()
	{
	  Damage(50);
	}

	[UnityEngine.ContextMenu("healtest")]
	private void heal()
	{
		 heal(50);
	}

	private void heal(float value)
	{

	}

	public void Damage(float Damage)
	{
		if (defCurrent > 1)
		{
			defCurrent -= Damage;
		}
		else 
		{
			hpCurrernt -= Damage;
		}

		if(hpCurrernt < 1)
		{
			Destroy(gameObject);
		}
		if(defCurrent < 0)
		{
			defCurrent = 0;
		}

		if (hpbar != null)
		{
			var x = hpCurrernt / Hp;
			hpbar.size = new Vector2(x, 0.98f);
		}
		if (defbar != null)
		{
			var x = defCurrent / Defense;
			defbar.size = new Vector2(x, 0.98f);
		}
	}
}
