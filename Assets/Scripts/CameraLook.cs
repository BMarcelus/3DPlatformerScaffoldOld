using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

  public float horizontalSensitivity;
  public float verticalSensitivity;
  public Transform CameraPivotX;
  public Transform CameraPivotY;

  public float minY;
  public float maxY;
	void Start () {		
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
	}
	
	void Update () {
    if (Input.GetMouseButtonDown(0)) {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }
    if(Input.GetKeyDown(KeyCode.Escape)) {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible=true;
    }
    float xAxis = Input.GetAxisRaw("Mouse X") * horizontalSensitivity;
    float yAxis = Input.GetAxisRaw("Mouse Y") * verticalSensitivity;
    // xAxis += Input.GetAxisRaw("Joystick2H") * horizontalSensitivity;
    // yAxis += -Input.GetAxisRaw("Joystick2V") * verticalSensitivity;
    CameraPivotX.Rotate(new Vector3(0, xAxis, 0));
    Vector3 rot = CameraPivotY.rotation.eulerAngles;
    rot.x -= verticalSensitivity*yAxis;
    float minAngle = maxY;
    float maxAngle = minY;
    if(rot.x > 180) rot.x -= 360;
    if(rot.x < maxAngle) rot.x = maxAngle;
    if(rot.x > minAngle) rot.x = minAngle;
    CameraPivotY.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);
	}
}
