using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    public PlayerManager player;
    public float sensitivity = 100f;

    private float verticalRotation;
    private float horizontalRotation;

    public void Start() {
        verticalRotation = transform.localEulerAngles.x;
        horizontalRotation = player.transform.eulerAngles.y;
    }

    public void Update() {
        Debug.DrawRay(transform.position, transform.forward * 2, Color.red);
    }
}
