using UnityEngine;
using System.Collections;
//+---------------------------------------------------------------------------------------------------------------+
//|                                Движения игрока                                                                |
//+---------------------------------------------------------------------------------------------------------------+
public class Ship_move : MonoBehaviour {

	private Vector3 movement;
	private CharacterController controller;
	public float speed = 9f;
	public float bullet_speed = 400f;
	public Rigidbody bullet;

	// Use this for initialization
	void Start () {
		movement = Vector3.zero;
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		movement = new Vector3(/*Input.GetAxis("Horizontal")*/-Input.acceleration.y, 0, 0);

		movement = transform.TransformDirection(movement);

		movement *= speed;

		controller.Move(movement * Time.deltaTime);

		//if (Input.GetKeyDown(KeyCode.UpArrow)){
		Touch touch = Input.GetTouch(0);
		if(touch.phase == TouchPhase.Began){
			audio.Play();
		
			Rigidbody bullet_clone = Instantiate(bullet, transform.position + new Vector3(0, 1f, 0), 
			                                     transform.rotation) as Rigidbody;

			bullet_clone.AddForce(Vector3.up * bullet_speed);
		}
	}
}