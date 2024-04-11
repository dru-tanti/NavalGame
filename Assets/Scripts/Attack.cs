using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	private int guns;
	private int ammunition;
	[SerializeField]
	private List<Transform> gunLocation;
	[SerializeField]
	private GameObject PF_Projectile;
	
	public void SetValue(int shipGuns, int startingAmmunition) {
		guns = shipGuns;
		ammunition = startingAmmunition;
		// TODO: Dynamically set up gun locations.
	}

	public void SetGuns() {
		switch(guns) {
			case 1:
			break;
			case 2:
			break;
			case 3:
			break;
			default:
			break;
		}
	}

	public void Fire(GunPosition gunPosition) {
		Debug.Log("Firing: "+gunPosition);
	}
}
