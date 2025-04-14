using Assets.Economic;

using UnityEngine;


public class EconomyViewModel : IController
{

	[SerializeField] private EconomyViewModeItem[] Items;

	public EconomicRepository _repository;

	public override int Order => OrderUpdateController.CurrentUpdate;

	public override bool Init()
	{
		if(_repository != null)
		{
			StateUpdate();
			return true;
		}
		return false;
	}

	public override void StateUpdate()
	{
		foreach(var item in Items)
		{
			item.Value = _repository.GetMetaDataById(item.Index).Value;
		}
	}
}
