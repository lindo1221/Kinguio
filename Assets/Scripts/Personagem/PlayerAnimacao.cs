using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimacao : MonoBehaviour
{
   public Animator animator;
    public float Speed;
    public bool IsJumping;
   public void Animacao(string aniName)
   {
        animator.Play(aniName);
   }
}
