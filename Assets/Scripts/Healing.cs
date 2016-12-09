using UnityEngine;

[RequireComponent(typeof(Player))]
public class Healing : MonoBehaviour {

	public float startTime = 1f;
	public float repeatRate = 1f;
	public float healFactor = 0.01f;
	
	private Player player;

    void Awake()
    {
        player = GetComponent<Player>();
    }
	
	void Start () {
		InvokeRepeating ("Heal", startTime, repeatRate);	
	}
	
	public void Heal ()
	{
		if(isActiveAndEnabled)
			player.Heal (healFactor);
	}

}
