using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static int   pipesPassed     { get; set; }
    public static float vitality        { get; set; }
    public static bool  isWkeyEnabled   { get; set; }
    public static float pipeSpawnPeriod { get; set; }
    public static float vitalityPeriod  { get; set; }
}

[Serializable]
class SavedState
{

}