﻿using Assets.Economic;
using UnityEngine;

namespace Assets.UI.CanvasComponents
{
	public class UnitStepController : IController
	{
		public override int Order => OrderUpdateController.CurrentUpdate;

		public override bool Init()
		{
			return true;
		}

		public override void StateUpdate()
		{
			//FixME: добавить глобальный список всех юнитов
			var units = GameObject.FindObjectsOfType<UnitSelectHelper>();

			foreach(var unit in units)
			{
				unit.StepInStep = 0;

				Debug.Log($"as");
			}
		}
	}
}
