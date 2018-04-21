using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	
	[SerializeField]private int hp;
	[SerializeField]private int hungry;
	[SerializeField]private int thirst;

	public int Hp{
		get{
			return hp;
		}
		set{
			hp = value;
		}
	}
	public int Hungry{
		get{
			return hungry;
		}
		set{
			hungry = value;
		}
	}
	public int Thirst{
		get{
			return thirst;
		}
		set{
			thirst = value;
		}
	}
}
