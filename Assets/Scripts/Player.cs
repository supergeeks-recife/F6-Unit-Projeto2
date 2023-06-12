using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Events;
using System;


public class Player : NetworkBehaviour
{

    Rigidbody2D rb;
    float inputX;
    float inputY;
    bool inputAttack;
    public float speed;

    //eventos que ser�o disparados quando o jogador mover o Player e quiser atacar
    public InputEvent OnDirectionChanged;
    public BoolEvent OnAttack;
    public GameObject myCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(isLocalPlayer == false)
        {
            //myCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
    }

    void Update()
    {

        if (isLocalPlayer)
        {
            inputX = Input.GetAxisRaw("Horizontal");
            inputY = Input.GetAxisRaw("Vertical");
            OnDirectionChanged?.Invoke(inputX, inputY);

            //por enquanto o ataque est� desabilitado, vamos programar ele em aula!

            //inputAttack = Input.GetKeyDown(KeyCode.Space);
            //OnAttack?.Invoke(inputAttack);

            rb.velocity = new Vector2(inputX, inputY) * speed;
        }
        
    }

}
