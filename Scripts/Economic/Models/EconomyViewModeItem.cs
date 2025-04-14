using UnityEngine.UI;

[System.Serializable]
public class EconomyViewModeItem
{
	public Text _text;
	public long Index;

	public long Value
	{
		get => long.Parse(_text.text);
		set => _text.text = value.ToString();
	}
}
