using UnityEngine;
using UnityEngine.SceneManagement;

public class FInishLine : MonoBehaviour
{
    [SerializeField] float Delay = 0.5f;
    [SerializeField] ParticleSystem finishParticles;
    void OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex= LayerMask.NameToLayer("Player");
        if(other.gameObject.layer==layerIndex)
        {
            finishParticles.Play();
            Invoke("ReloadScene", Delay);
        } 
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    
} 

