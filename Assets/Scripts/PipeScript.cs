using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    // [SerializeField]
    private float pipeVelocity = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        this                         // this - як відсилання на даний ГО
            .transform               // transform - компонент, який є завжди, - для нього закладене поле
            .Translate(              // Translate - переміщення (на заданий вектор)
                pipeVelocity         //  масштаб - швидкість
                * Time.deltaTime     //  корекція на час - FPS незалежність
                * Vector2.left);     //  напрям - вліво

    }
}
