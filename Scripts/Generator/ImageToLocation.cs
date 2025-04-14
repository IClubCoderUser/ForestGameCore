using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ImageToLocation : MonoBehaviour
{
	[SerializeField]
	[Header("Путь")]
	public string _imageName;

	[SerializeField]
	[Header("Ширина")]
	public int _width;

	[SerializeField]
	[Header("Высота")]
	public int _height;

	public GameObject Parent;

	public List<GameObject> list_hex;

	public GameObject[] _presets;

	[ContextMenu("Remove")]
	public void Remove()
	{
		foreach(var item in list_hex)
		{
			GameObject.DestroyImmediate(item);
		}
	}

	[ContextMenu("generate")]
	public void generate()
	{
		if (string.IsNullOrEmpty(_imageName))
		{
			Debug.LogError("нет ссылки на каритинку");
			return;
		}
		if (!File.Exists(_imageName))
		{
			Debug.LogError("не верный путь до изображения");
			return;
		}

		if (_width <= 0 || _height <= 0)
		{
			Debug.LogError("ты чё, офигел");
			return;
		}

		using (var stream = File.Open(_imageName, FileMode.Open, FileAccess.Read))
		using (var mem = new MemoryStream())
		{
			stream.CopyTo(mem);

			var texture = new Texture2D(_width, _height);
			texture.LoadImage(mem.ToArray());

			Generate(texture);
		}
	}

			 
	private void Generate(Texture2D texture)
	{
		var presets = _presets.Select(x => x.GetComponent<HexHelper>());
		var list = new List<GameObject>();

		for (int i = 0; i < texture.width; i++)
		{
			for (int j = 0; j < texture.height; j++)
			{
				var pixel = texture.GetPixel(i, j);

				float min = float.MaxValue;
				HexHelper item = null;

				foreach (var preset in presets)
				{
					if(preset == null) continue;

					var currentMin = Mathf.Sqrt(
						Mathf.Pow(preset._color.r - pixel.r, 2) + 
						Mathf.Pow(preset._color.g - pixel.g, 2) + 
						Mathf.Pow(preset._color.b - pixel.b, 2));

					if(currentMin < min) 
					{ 
						min = currentMin; 
						item = preset;
					}
				}

				var obj = _presets.FirstOrDefault(x => x.GetComponent<HexHelper>() == item);

				var g = GameObject.Instantiate(obj) as GameObject;
				g.name = $"{i} : {j}";

				list.Add(g);


				HexHelper.SetPosition(g, i, j, 2, 3);
				g.transform.parent = Parent.transform;
			}
		}

		list.ForEach(x => x.GetComponent<HexHelper>().Connect());

		list_hex = list;
	}

	private void CreateOnScene(Texture2D texture)
	{
		var sprite = Sprite.Create(texture, new Rect(0, 0, _width, _height), Vector2.one);
		sprite.name = Path.GetFileName(_imageName);

		var obj = new GameObject("-----");
		obj.transform.position = new Vector2(0, 0);

		var q = obj.AddComponent<SpriteRenderer>();
		q.name = Path.GetFileName(_imageName);
		q.sprite = sprite;
	}
}
