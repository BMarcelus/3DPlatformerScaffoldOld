using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

  public float jumpForce;
  public Colliding groundCollider;
  private Rigidbody rb;
  private Vector3 lastVelocity;
  private bool grounded;
  public Vector3 accel;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
    grounded = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Joystick1Button16)) {
      if(Grounded()) {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
      }
    }
	}

  void FixedUpdate() {
    accel = rb.velocity - lastVelocity;
    if(accel.y < float.Epsilon) accel.y = 0;
    lastVelocity = rb.velocity;
  }

  public void Action() {
    if(Grounded()) {
      rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
    }
  }

  private bool Grounded() {
    return groundCollider.getColliding();
  }
}
