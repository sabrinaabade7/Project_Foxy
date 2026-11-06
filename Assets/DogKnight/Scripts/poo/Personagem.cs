using UnityEngine;

public class Personagem : MonoBehaviour
{
  [SerializeField]protected string nome;
  [SerializeField]protected int vida;
  [SerializeField]protected int velocidade;
  [SerializeField]protected int forca;
  [SerializeField]protected int tec;
  [SerializeField]protected int mana;
  
  public virtual void Attack()
  {
     Debug.Log("Realizou um ataque");
  }
  
  
  

}
