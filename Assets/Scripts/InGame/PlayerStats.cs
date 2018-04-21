using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	
	//All the stats that ll be used for the player
	[SerializeField]private int hp;
	[SerializeField]private float hungry;
	[SerializeField]private float thirst;

	public int Hp{
		get{
			return hp;
		}
		set{
			hp = value;
		}
	}
	public float Hungry{
		get{
			return hungry;
		}
		set{
			hungry = value;
		}
	}
	public float Thirst{
		get{
			return thirst;
		}
		set{
			thirst = value;
		}
	}
}
