using UnityEngine;

public class FloatingTextController : MonoBehaviour
{
	private static FloatingText popupTextParent;
    private static FloatingText popupTextParent2;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        popupTextParent = Resources.Load<FloatingText>("Prefabs/PopupTextParent");
        popupTextParent2 = Resources.Load<FloatingText>("Prefabs/PopupTextParent2");
    }

    public static void CreateFloatingText(string text, Transform location)
    {
        FloatingText instance = Instantiate(popupTextParent);
        instance.transform.SetParent(canvas.transform, false);
        instance.SetText("-" + text);
    }

    public static void CreateFloatingText2(string text, Transform location)
    {
        FloatingText instance = Instantiate(popupTextParent2);
        instance.transform.SetParent(canvas.transform, false);
        instance.SetText(text);
    }
}
