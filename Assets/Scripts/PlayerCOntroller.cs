using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCOntroller : MonoBehaviour
{
    [SerializeField] float torqueAmount = 10f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;
    
    Rigidbody2D myRigidbody2D;
    InputAction moveAction;
    SurfaceEffector2D surfaceEffector2D;
    Vector2 moveVector;
    ScoreManager scoreManager;


    bool canControlPlayer = true; 
    float previousRotation;
    float totalRotation;
    float flipCount;
    void Start()
    {

        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        scoreManager = FindFirstObjectByType<ScoreManager>();

    }

    void Update()
    {
        if(canControlPlayer)
        {
            RoatatePlayer();
            BoostPlayer();
            CalculateFlip();
        }
    }

    void RoatatePlayer()
    {
        
        moveVector= moveAction.ReadValue<Vector2>();
        if(moveVector.x > 0)
        {
            myRigidbody2D.AddTorque(-torqueAmount);
        }
        else if(moveVector.x < 0)
        {
            myRigidbody2D.AddTorque(torqueAmount);
        }
    }

    void BoostPlayer()
    {
        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if(moveVector.y <= 0){
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    public void DisableControl()
    {
        canControlPlayer = false;
    }

    void CalculateFlip()
    {
        float CurrentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, CurrentRotation);

        if(totalRotation >340 || totalRotation < -340)
        {
            flipCount += 1;
            totalRotation = 0;
            scoreManager.AddScore(1);
        } 
        previousRotation = CurrentRotation;

    }
}
