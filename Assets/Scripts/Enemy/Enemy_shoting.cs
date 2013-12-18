using UnityEngine;
using System.Collections;
//+---------------------------------------------------------------------------------------------------------------+
//|                                 Выстрелы противников                                                          |
//+---------------------------------------------------------------------------------------------------------------+
public class Enemy_shoting : MonoBehaviour {

	public Rigidbody enemy_bullet;
	private int timerToShot;

	// Use this for initialization
	void Start () {
		timerToShot = 100;
	}
	
	// Update is called once per frame
	void Update () {
		timerToShot--;

		if (timerToShot < 1) {
			int rand_shot = Random.Range(0, 10);

			if (rand_shot == 1 && Time.timeScale != 0){
				Rigidbody bulletToFire = Instantiate(enemy_bullet, transform.position, transform.rotation) as Rigidbody;
				bulletToFire.AddForce(Vector3.down * 300f);
			}

			timerToShot = 200;
		}
	}
}



