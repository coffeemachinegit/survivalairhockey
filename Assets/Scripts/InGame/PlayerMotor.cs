using System.Collections;
using System.Collections.Generic;
using CerfGames.Utils;
using UnityEngine;
public class PlayerMotor : MonoBehaviour {
    public PlayerStats playerStats;
    private float velocity = 6f;
    private float oldVelocity, fatigueSpeedPerCent,totalStats;
    private float movX, movY;
    
    private Animator playerMove;

    private Rigidbody2D playerBody;
    private void Awake () {
        oldVelocity = velocity;
        playerBody = GetComponent<Rigidbody2D> ();
        playerMove = GetComponent<Animator>();
    }
    private void Start () {
        playerStats = PlayerManager.Instance.playerStats;
        totalStats = playerStats.Thirst + playerStats.Hungry;

    }
    private void Update () {
        Debug.Log (velocity);
        playerMove.SetFloat("walkingVelocity",2);
        playerMove.speed = velocity/10;
        //Fatigue Influence -> Bigger => Good (speed % influenced by fatigue)
        fatigueSpeedPerCent = (float) ((playerStats.Thirst + playerStats.Hungry)) / totalStats;

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
        Debug.Log(movX);
        if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.Joystick1Button1)) {
            velocity *= 2f;
        }
         
         transform.Translate (movX * velocity * Time.deltaTime, movY * velocity * Time.deltaTime, 0);
    }
}