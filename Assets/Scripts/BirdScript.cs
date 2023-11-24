using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private float discreteForceFactor  = 300f;     // дискретне управління - багаторазовим натисненням
    private float continualForceFactor = 10f;      // неперервне - утримуючи клавішу натисненою
    // private float vitalityTime = 20f;  // 20 секунд на життя
    private Rigidbody2D body;

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        GameState.pipesPassed = 0;
        GameState.vitality = 0.85f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(discreteForceFactor * Time.timeScale * Vector2.up);
        }
        if (GameState.isWkeyEnabled && Input.GetKey(KeyCode.W))
        {
            body.AddForce(continualForceFactor * Time.timeScale * Vector2.up);
        }

        this.transform.eulerAngles = new Vector3(0, 0, 3f * body.velocity.y);

        GameState.vitality -= Time.deltaTime / GameState.vitalityPeriod;
        if(GameState.vitality <= 0)
        {
            GameState.vitality = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Collision: " + collision.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Transform parent = other.gameObject.transform.parent;
        if(parent != null && parent.gameObject.CompareTag("Pipe"))
        {
            // Це труба
        }
        if (other.gameObject.CompareTag("Food"))
        {
            // Це їжа
            GameState.vitality = 1f;
            GameObject.Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            GameState.pipesPassed += 1;
        }
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
