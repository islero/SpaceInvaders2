using UnityEngine;
using System.Collections;

public class Bottom_destroy : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		Destroy (other.gameObject);
	}
}
