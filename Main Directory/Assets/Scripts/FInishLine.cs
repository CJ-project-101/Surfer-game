using UnityEngine;

public class FInishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex= LayerMask.NameToLayer("Player");
        if(other.gameObject.layer==layerIndex)
        {
            Debug.Log("You win!");
        }
    }
}

