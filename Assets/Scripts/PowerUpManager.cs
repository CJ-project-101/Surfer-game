using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] PowerUpSO powerUp;
    SpriteRenderer spriteRenderer;
    PlayerCOntroller player;
    float timeLeft;
    
    void Start()
    {
        player = FindFirstObjectByType<PlayerCOntroller>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeLeft = powerUp.GetTime();
    }

    void Update()
    {
        
        CountDownTimer();
    }

    void CountDownTimer()
    {
        if(spriteRenderer.enabled == false)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                if(timeLeft <= 0)
                {
                    print("times up nigga");
                    player.DeactivatePowerUp(powerUp);
                }
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        if (collision.gameObject.layer == layerIndex && spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
            player.ActivatePowerUp(powerUp);
            
        }
    }
}
