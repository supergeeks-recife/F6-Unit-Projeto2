using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_Animations : NetworkBehaviour
{
    Animator anim;
    //as variáveis abaixo são usadas para saber qual direção o Player está olhando
    float horizontal;
    float vertical;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    //função que recebe o input do script Player para trocar para as animações de Walk
    public void ChangeWalkAnimation(float inputX, float inputY)
    {
        if(inputX != 0 || inputY != 0)
        {
            /*InputHolded é usado para sabermos se o jogador está segurando o botão de mover,
            pois no Animator as animações de Idle estão programadas para serem executadas quando 
            esse valor for falso*/
            anim.SetBool("InputHolded", true);
            
            if (inputX != 0)
            {
                anim.Play("Player_WalkHorizontal");
                //faz o "flip" do Player alterando sua escala em X
                //(para que ele olhe para a esquerda ou direita)
                transform.localScale = new Vector3(-inputX, 1, 1);
                horizontal = inputX;
                vertical = 0;
            }
            else if (inputY > 0)
            {
                anim.Play("Player_WalkUp");
                vertical = inputY;
                horizontal = 0;
            }
            else if (inputY < 0)
            {
                anim.Play("Player_WalkDown");
                vertical = inputY;
                horizontal = 0;
            }
        }
        else
        {
            anim.SetBool("InputHolded", false);
        }

    }


    public void ChangeAttackAnimation(bool inputAttack)
    {
        /*A animação de ataque só poderá ser executada se o jogador apertou 
          o botão de ataque e se ele está parado */

        if (inputAttack && anim.GetBool("InputHolded") == false)
        {
            if (horizontal != 0)
                anim.Play("Player_AttackHorizontal");
            if (vertical < 0)
                anim.Play("Player_AttackDown");
            if (vertical > 0)
                anim.Play("Player_AttackUp");
        }
    }
}
