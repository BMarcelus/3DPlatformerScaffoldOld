using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColliding : MonoBehaviour {

  public int colliding = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

  void OnTriggerEnter(Collider col) {
    colliding += 1;
  }
  void OnTriggerExit(Collider col) {
    colliding -= 1;
  }

  public bool getColliding() {
    return colliding > 0;
  }
}
