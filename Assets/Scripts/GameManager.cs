using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int lastRoadPositionZ = -100;
    public static int backRoadPositionZ = -100;
    public static int maxCollisions = 5;
    public static int currCollisions = 0;
    public static string finalScore = "";
    public static float highScore = 0f;
}
