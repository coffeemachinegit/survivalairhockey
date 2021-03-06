﻿using System.Collections;
using System.Collections.Generic;
using CerfGames.Utils;
using UnityEngine;
public class PlayerMotor : MonoBehaviour {
    public PlayerStats playerStats;

    [SerializeField]
    private float velocity = 6f;
    private float oldVelocity, fatigueSpeedPerCent, totalStats;
    private float movX, movY;
    Vector2 limitador;
    float startThirstMult;

    Rigidbody2D playerBody;

    private PlayerAnimation playerMove;

    [SerializeField]
    private float minVelocity = 2f;
    private void Awake () {
        playerBody = GetComponent<Rigidbody2D> ();
        limitador = new Vector3 ();
        oldVelocity = velocity;

    }
    private void Start () {

        playerStats = PlayerManager.Instance.playerStats;
        totalStats = playerStats.Thirst + playerStats.Hungry;
        playerMove = GetComponentInChildren<PlayerAnimation> ();

    }
    void FixedUpdate () {

        if (!GameManager.Instance.canPlay){
            playerBody.velocity = Vector2.zero;
            return;
        }
        //float posX = Mathf.Clamp (transform.position.x + movX * velocity * Time.deltaTime, CameraUtil.Xmin, CameraUtil.Xmax);
        //float posY = Mathf.Clamp (transform.position.y + movY * velocity * Time.deltaTime, CameraUtil.Ymin, CameraUtil.Ymax);
        //limitador.Set (posX, posY);
        //playerBody.position = limitador;
        playerBody.velocity = new Vector3 (movX*velocity,movY*velocity,0f);
        float posX = Mathf.Clamp (playerBody.position.x, CameraUtil.Xmin, CameraUtil.Xmax);
        float posY = Mathf.Clamp (playerBody.position.y, CameraUtil.Ymin, CameraUtil.Ymax);
        limitador.Set (posX, posY);
        playerBody.position = limitador;
    }
    private void Update () {
        if (!GameManager.Instance.canPlay)
            return;
        //Fatigue Influence -> Bigger => Good (speed % influenced by fatigue)
        fatigueSpeedPerCent = (float) ((playerStats.Thirst + playerStats.Hungry)) / totalStats;

        //80% of fatigue => 80% of Total Speed
        if (fatigueSpeedPerCent < 0.8f && velocity > minVelocity) {
            velocity = oldVelocity * (fatigueSpeedPerCent);
            SurvivalManager.Instance.ChangeMultiplier (false);
        } else {
            if ((!Input.GetKey (KeyCode.LeftShift) || !Input.GetKey (KeyCode.Joystick1Button1)))
                if (fatigueSpeedPerCent < 0.35f) {
                    GameManager.Instance.isFadigated = true;
                    velocity = minVelocity;
                    SurvivalManager.Instance.ChangeMultiplier (false);
                }
            else {
                GameManager.Instance.isFadigated = false;
                velocity = oldVelocity;
                SurvivalManager.Instance.ChangeMultiplier (false);
            }
        }
        movX = Input.GetAxis ("Horizontal");
        movY = Input.GetAxis ("Vertical");

        if ((Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.Joystick1Button1)) &&
            velocity > minVelocity) {
            velocity *= 1.3f;
            SurvivalManager.Instance.ChangeMultiplier (true);
        }

        playerMove.MovimentAnimation (movX, movY, velocity);
        // transform.Translate (movX * velocity * Time.deltaTime, movY * velocity * Time.deltaTime, 0);
        // float posX = Mathf.Clamp(transform.position.x,CameraUtil.Xmin,CameraUtil.Xmax);
        // float posY = Mathf.Clamp(transform.position.y,CameraUtil.Ymin,CameraUtil.Ymax);
        // limitador.Set(posX,posY,0);
        // transform.position = limitador;
        // lookToBall.UpdateRotation();
    }
}