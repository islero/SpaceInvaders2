using UnityEngine;
using System.Collections;

public class Enemy_near_player : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.tag == "Enemy"){
			Score.Instance.LoseAllLife();
		}
	}
}
