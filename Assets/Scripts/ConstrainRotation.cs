using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainRotation : MonoBehaviour {

  public float minX;
  public float maxX;
  public float minY;
  public float maxY;
  public float minZ;
  public float maxZ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 euler = transform.localEulerAngles;
    if(euler.x > 180) euler.x -= 360;
    if(euler.x < minX) euler.x = minX;
    if(euler.x > maxX) euler.x = maxX;
    if(euler.y > 180) euler.y -= 360;
    if(euler.y < minY) euler.y = minY;
    if(euler.y > maxY) euler.y = maxY;
    if(euler.z > 180) euler.z -= 360;
    if(euler.z < minZ) euler.z = minZ;
    if(euler.z > maxZ) euler.z = maxZ;
    transform.localEulerAngles = euler;
	}
}
