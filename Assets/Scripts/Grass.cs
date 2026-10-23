using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] private ParticleSystem fxHit;
    private bool isCut;
    
    private void GetHit(int amount)
    {
        transform.localScale = new Vector3(1, 1, 1);
        fxHit.Emit(10);
        isCut = true;
    }

}
