using UnityEngine;

public class SnowTrail : MonoBehaviour
{

    [SerializeField] ParticleSystem slideParticle;
    
    
    void  OnCollisionEnter2D(Collision2D Collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if(Collision.gameObject.layer == layerIndex)
        {
            slideParticle.Play();
        }
    }

    void OnCollisionExit2D(Collision2D Collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if(Collision.gameObject.layer == layerIndex)
        {
            slideParticle.Stop();
        }
    }
}
