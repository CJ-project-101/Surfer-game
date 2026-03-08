using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] GameObject ScoreCanvas;
    [SerializeField] GameObject dinoSprite;
    [SerializeField] GameObject frogieSprite;
    
    void Start()
    {
        Time.timeScale = 0;
    }

    void BeginGame()
    {
        Time.timeScale = 1f;
        ScoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseDino()
    {
        dinoSprite.SetActive(true);
        BeginGame();
    }

    public void ChooseFrogie()
    {
        frogieSprite.SetActive(true);
        BeginGame();
    }
    
}
