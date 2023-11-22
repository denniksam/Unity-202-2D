using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private float discreteForceFactor  = 300f;     // дискретне управління - багаторазовим натисненням
    private float continualForceFactor = 10f;      // неперервне - утримуючи клавішу натисненою
    private Rigidbody2D body;

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector2.up * discreteForceFactor);
        }
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(Vector2.up * continualForceFactor);
        }

        this.transform.eulerAngles = new Vector3(0, 0, 3f * body.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Collision: " + collision.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Trigger: " + other.gameObject.name);
    }
}
/* Взаємодія об'єктів
 * Колізії (перетин об'єктів) вираховуються у фізичному циклі.
 * Участь у фізичному циклі беруть ЛИШЕ ті ГО, які мають Rigidbody(2D)
 * Відповідно, хоча б один з учасників колізії повинен мати Rigidbody,
 *   інакше колізія не детектується
 *  
 * Границі об'єктів визначаються їх колайдерами.
 * Колайдери поділяються на два типи: фізичні та тригери.
 * Фізичні колайдери обробляються Юніті, при колізії генерується 
 *   програмна подія OnCollisionEnter2D
 * Тригери лише створюють програмну подію, 
 *   на рух об'єктів впливу немає
 *   
 */
