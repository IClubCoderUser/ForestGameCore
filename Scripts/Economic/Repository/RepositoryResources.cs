using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IResources
{
	int Output { get; }

	GameObject Reference { get; }
}


public class RepositoryResources : MonoBehaviour
{
	List<ItemResources> valut = new List<ItemResources>();

	public void Create(ItemResources item) { valut.Add(item); }

	public void Remove(ItemResources item) { valut.Remove(item); }

	public IEnumerable<ItemResources> Fetch(
		long? resourceId = null, 
		long? comandId = null)
	{
		IEnumerable<ItemResources> query = valut;
		if (resourceId.HasValue)
		{
			query = valut.Where(x => x.ResourceId == resourceId.Value);
		}
		if (comandId.HasValue)
		{
			query = valut.Where(x => x.CommandId == comandId.Value);
		}

		return query;
	}

	// Start is called before the first frame update
	void Start()
	{
		valut = FindObjectsOfType<ItemResources>().ToList();
	}
}


internal class Valut
{
}