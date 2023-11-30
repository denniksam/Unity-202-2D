using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.gameObject.name);
        if (other.gameObject.transform.parent?.gameObject != null)
        {
            GameObject.Destroy(   // Потрібно видалити батьківській об'єкт - трубу
                other             // other - Collider2D (Box Collider)
                .gameObject       // gameObject - Square
                .transform        // батька знаходимо через transform
                .parent           // parent - це теж transform
                .gameObject       // gameObject - це його ГО
            );                    // 
        }
        else
        {
            GameObject.Destroy( other.gameObject );
        }
    }
}
