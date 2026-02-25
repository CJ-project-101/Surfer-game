using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float Delay=0.5f;
    [SerializeField] ParticleSystem crashParticle; 
    void  OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex= LayerMask.NameToLayer("Floor");
        if(other.gameObject.layer==layerIndex  )
        {
            crashParticle.Play();
            Invoke("ReloadScene", Delay);
        }
    }   

    void ReloadScene()
    {
        SceneManager.LoadScene(0);

    }
}
