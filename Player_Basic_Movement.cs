using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Basic_Movement : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	Rigidbody2D setrigid;
	Vector3 movement;
	bool isJumping = false;

	// Use this for initialization
	void Start () {
		setrigid = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump")){
			isJumping = true;
		}//stop jumping infinitive
	}

	void FixedUpdate(){
		Move ();//mulli script mullihak 
		Jump ();
	}

	void Move(){//move right, left script
		Vector3 moveVelocity = Vector3.zero;
		if (Input.GetAxisRaw ("Horizontal") < 0) {
			moveVelocity = Vector3.left;
		}
		if(Input.GetAxisRaw("Horizontal") > 0){
			moveVelocity = Vector3.right;
		}
		transform.position = transform.position + moveVelocity * moveSpeed* Time.deltaTime;
		//to match the frame, so i used time.deltatime
	}

	void Jump(){//jumping script
		if (isJumping != false) {
			realjump ();
		}

		//isJumping == false ? isJumping = false : realjump ();
	}

	void realjump(){
		setrigid.velocity = Vector2.zero;
		Vector2 jumpVelocity = new Vector2 (0, jumpForce);
		setrigid.AddForce (jumpVelocity, ForceMode2D.Impulse);
		isJumping = false;
	}
}
