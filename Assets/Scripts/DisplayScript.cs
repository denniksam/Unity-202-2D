using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI pipesPassedTMP;
    [SerializeField]
    private Image vitalityIndicator;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        pipesPassedTMP.text = GameState.pipesPassed.ToString();
        vitalityIndicator.fillAmount = GameState.vitality;
        vitalityIndicator.color = new Color(
            1 - GameState.vitality,
            GameState.vitality,
            0.3f);
    }
}
/* Д.З. Реалізувати ігровий таймер - відображення часу 00:03:15,
 * що пройшов від початку гри
 */
