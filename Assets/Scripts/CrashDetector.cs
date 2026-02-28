using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float Delay=0.5f;
    [SerializeField] ParticleSystem crashParticle; 
    PlayerCOntroller playerController;
    void  Start()
    {
        playerController = FindFirstObjectByType<PlayerCOntroller>();
    }




    void  OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex= LayerMask.NameToLayer("Floor");
        int layerIndex1= LayerMask.NameToLayer("Pit");
        if(other.gameObject.layer==layerIndex  )
        {
            playerController.DisableControl();

            crashParticle.Play();
            Invoke("ReloadScene", Delay);
            
        }
        else if(other.gameObject.layer==layerIndex1)
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
