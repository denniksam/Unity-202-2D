using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    // [SerializeField]
    private float forceFactor = 300f;

    private Rigidbody2D body;  // посилання на компонент "нашого" об'єкту

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            body.AddForce(Vector2.up * forceFactor);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            body.AddTorque(10f);
        }
    }
}
/* Д.З. Реалізувати управління фізичного типу (сила, крутний момент)
 * по координатах (ліво, право, верх) та вісі обертання (за / проти год.стрілки).
 * Підібрати амплітуду зусиль (фактори).
 * Додати обмеження ігрового поля з усіх боків з урахуванням фіксованого
 * аспекту камери.
 */
