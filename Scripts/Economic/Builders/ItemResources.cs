using UnityEngine;

public abstract class ItemResources : MonoBehaviour, IResources
{
	public abstract int Output { get; }

	public abstract GameObject Reference { get; }

	public abstract long ResourceId { get; }
	
	public virtual long CommandId { get; }
}
