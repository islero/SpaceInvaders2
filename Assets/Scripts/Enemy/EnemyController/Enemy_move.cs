using UnityEngine;
using System.Collections;
//+---------------------------------------------------------------------------------------------------------------+
//|                                        Движения противников                                                   |
//+---------------------------------------------------------------------------------------------------------------+
public class Enemy_move : MonoBehaviour {

	public static float speed = 1.4f;

	void Update(){
		transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "Right_Collider" && speed > 0){
			speed *= -1;
		}

		if(other.gameObject.name == "Left_Collider" && speed < 0){
			speed *= -1;
		}
	}

}