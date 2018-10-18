using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliding : MonoBehaviour {

  private int colliding = 0;
  private Vector3 lastDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    Debug.DrawRay(transform.position, lastDirection * 2);
	}

  void OnCollisionEnter(Collision col) {
    lastDirection = col.contacts[0].normal;
    Debug.Log(lastDirection.y);
    colliding += 1;
  }
  void OnCollisionExit(Collision col) {
    Debug.Log(col.transform.name);
    colliding -= 1;
  }

  public bool getColliding() {
    return colliding > 0;
  }
}
