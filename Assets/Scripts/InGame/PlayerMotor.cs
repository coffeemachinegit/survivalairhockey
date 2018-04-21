using System.Collections;
using System.Collections.Generic;
using CerfGames.Utils;
using UnityEngine;
public class PlayerMotor : MonoBehaviour {
    public float velocity = 2f;
    private float oldVelocity;
    private float movX, movY;

    private Rigidbody2D playerBody;
    private void Awake () {
        oldVelocity = velocity;
        playerBody = GetComponent<Rigidbody2D> ();
    }
    private void Update () {
        movX = Input.GetAxis ("Horizontal");
        movY = Input.GetAxis ("Vertical");
        transform.Translate (movX * velocity * Time.deltaTime, movY * velocity * Time.deltaTime, 0);
        if (Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.Joystick1Button1)) {
            velocity *= 2f;
        }
        if (Input.GetKeyUp (KeyCode.LeftShift) || Input.GetKeyUp (KeyCode.Joystick1Button1)) {
            velocity = oldVelocity;
        }
    }
}