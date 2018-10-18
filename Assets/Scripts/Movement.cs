using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

  public float speed;
  public float gravity;
  public GameObject model;
  private Vector3 movement = Vector3.zero;
  private Vector3 velocity = Vector3.zero;
  private Rigidbody rb;
  private Quaternion targetAngle;
  private Quaternion modelAngle;
  private float velocityY;
  private Colliding colliding;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
    colliding = GetComponent<Colliding>();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");
    Vector3 inputMovement = new Vector3(horizontalInput, 0, verticalInput);
    bool moving = inputMovement != Vector3.zero;
    if(moving) inputMovement.Normalize();
    movement += (inputMovement - movement)/3;
    if(movement.sqrMagnitude < float.Epsilon) movement = Vector3.zero;    
    if(moving) {
      targetAngle = Quaternion.LookRotation(inputMovement) * transform.rotation;          
      modelAngle = Quaternion.Lerp(model.transform.rotation, targetAngle, 0.2f);          
    }
    model.transform.rotation = modelAngle;
    
    if(colliding.getColliding()&&movement != Vector3.zero) {
      transform.Translate(Vector3.up * rb.velocity.y * Time.deltaTime);
    }
    rb.velocity+= Vector3.up * -gravity*Time.deltaTime;
    // transform.Translate(Vector3.up * velocityY * Time.deltaTime);
    // velocityY += -40 * Time.deltaTime;
    // if(colliding.getColliding()) {
      // velocityY = 0;
      // rb.velocity = Vector3.zero;
    // }
	}

  void FixedUpdate() {
    Vector3 delta = movement * speed;
    transform.Translate(delta / 100);
  }
}
