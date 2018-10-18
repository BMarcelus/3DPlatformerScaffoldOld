using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
  void OnTriggerEnter(Collider col) {
    GameManager.score += 1;
    Destroy(gameObject);
  }
}
