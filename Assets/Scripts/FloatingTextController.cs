using UnityEngine;

public class FloatingTextController : MonoBehaviour
{

    private static FloatingText prefab;
	private static GameObject canvas;
	

	public static void Initilize(){
		canvas = GameObject.Find("Canvas");
		prefab = Resources.Load<FloatingText>("Prefabs/PopupTextParent");
	}

    public static void CreateFloatingText(string text, Transform location)
    {
		FloatingText instance = Instantiate(prefab);
		instance.transform.SetParent(canvas.transform, false);
		instance.SetText(text);
    }
}
