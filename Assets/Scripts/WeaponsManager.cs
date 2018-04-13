using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour {

	public GameObject defaultWeapon;
	public List<GameObject> weapons = new List<GameObject>();

	void Start () {

		GameObject defaultW = Instantiate(defaultWeapon,transform.position,transform.rotation) as GameObject;
		weapons.Add (defaultW);
		defaultW.transform.parent = transform;
		
	}

}
