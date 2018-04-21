using System.Collections;
using System.Collections.Generic;
using CerfGames.Utils;
using UnityEngine;
public class PlayerMotor : MonoBehaviour {
    public PlayerStats playerStats;
    private float velocity = 6f;
    private float oldVelocity, fatigueSpeedPerCent;
    private float movX, movY;

    private Rigidbody2D playerBody;
    private void Awake () {
        oldVelocity = velocity;
        playerBody = GetComponent<Rigidbody2D> ();
    }
    private void Start () {
        playerStats = PlayerManager.Instance.playerStats;
    }
    private void Update () {
        Debug.Log (velocity);
        //Fatigue Influence -> Bigger => Good (speed % influenced by fatigue)
        fatigueSpeedPerCent = (float) ((playerStats.Thirst + playerStats.Hungry)) / 200;

        //60% of fatigue => 60% of Total Speed
        if (fatigueSpeedPerCent < 0.8f) {
            Debug.Log ("Fadigue: " + fatigueSpeedPerCent.ToString ());
            velocity = oldVelocity * (fatigueSpeedPerCent);
        } else {
            if (!Input.GetKey (KeyCode.LeftShift) || !Input.GetKey (KeyCode.Joystick1Button1))
                velocity = oldVelocity;
        }
        movX = Input.GetAxis ("Horizontal");
        movY = Input.GetAxis ("Vertical");
        transform.Translate (movX * velocity * Time.deltaTime, movY * velocity * Time.deltaTime, 0);
        if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.Joystick1Button1)) {
            velocity *= 2f;
        }
    }
}