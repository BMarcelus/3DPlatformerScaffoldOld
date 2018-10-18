using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementTester : MonoBehaviour {

  public float speed;
  public GameObject model;
  private Vector3 movement = Vector3.zero;
  private Vector3 velocity = Vector3.zero;
  private Rigidbody rb;
  private Quaternion targetAngle;
  private Quaternion modelAngle;

  enum MovementType {
    position, translate, movePoistion, velocity, force,
  }
  [SerializeField]
  private MovementType movementType;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");
    Vector3 inputMovement = new Vector3(horizontalInput, 0, verticalInput);
    bool moving = inputMovement != Vector3.zero;
    if(moving) inputMovement.Normalize();
    movement += (inputMovement - movement)/3;    
    if(moving) {
      targetAngle = Quaternion.LookRotation(inputMovement) * transform.rotation;          
      modelAngle = Quaternion.Lerp(model.transform.rotation, targetAngle, 0.2f);          
    }
    model.transform.rotation = modelAngle;
    if(movementType == MovementType.velocity) {
      Vector3 delta = transform.rotation * (movement * speed);      
      delta.y = rb.velocity.y;
      rb.velocity = delta;
    }
	}

  void FixedUpdate() {
    // transform.Translate(movement * speed / 100);
    Vector3 delta = (movement * speed);
    switch(movementType) {
      case MovementType.position:
        transform.position += transform.rotation * delta / 100;
        break;
      case MovementType.translate:
        transform.Translate(delta / 100);
        break;
      case MovementType.movePoistion:
        rb.MovePosition(rb.position + transform.rotation * delta / 100);
        break;
      case MovementType.velocity:
        delta.y = rb.velocity.y;
        rb.velocity = delta;
        break;
      case MovementType.force:
        rb.AddForce(transform.rotation * delta*5, ForceMode.Force);
        break;
      default:
        break;
    }
  }
}
