using UnityEngine;
using System.Collections;

public class MonoRat : MonoBehaviour
{

	private Rat rat;

	public Rat Rat {
		set { 
			rat = value;
		}

		get { 
			return rat;
		}
	}
}
