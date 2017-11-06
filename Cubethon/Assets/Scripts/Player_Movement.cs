using UnityEngine;

public class Player_Movement : MonoBehaviour {

	//reference to Rigidbody component 
	public Rigidbody rb;

	public float forwardForce = 2000f;
	public float sidewaysForce = 500f;

	public float speed = 3f;

	public bool IsGrounded;
 
 void OnCollisionStay (Collision collisionInfo)
 {
      IsGrounded = true;
 }
 
 void OnCollisionExit (Collision collisionInfo)
 {
      IsGrounded = false;
 }

	// Update is called once per frame

	//Fixed update since we are messing with phyiscs
	void FixedUpdate () {

		//Adds forward force, see variable forwardForce
		rb.AddForce (0, 0, forwardForce * Time.deltaTime); 

		if (Input.GetKey("d") || Input.GetKey("right") )
		{
			rb.AddForce (sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);	
		}
	

		if (Input.GetKey("a") || Input.GetKey("left"))
		{
			rb.AddForce (-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);	
		}

		if(Input.GetKeyDown(KeyCode.Space) && (IsGrounded = true)){
     GetComponent<Rigidbody>().velocity = Vector3.up * speed;
 }

		if (rb.position.y < -3f){

			FindObjectOfType<Game_Manager>().EndGame();

		}
	
	}
}
