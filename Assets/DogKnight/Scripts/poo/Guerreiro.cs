using System;
using UnityEngine;

public class Guerreiro : Personagem
{
  private void Start()
  {
    nome = "Guerreiro";
    vida = 100;
    forca = 5;
    tec = 3;
    velocidade = 20;
    
    Attack();
    
  }

  
  
  public override void Attack()
  {
    base.Attack();
    Debug.Log("Ateque com espada");
    //polimofirsmo ou varias formas
    //instams = existe no jogo
  }

  
  
}
