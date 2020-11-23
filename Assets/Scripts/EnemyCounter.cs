using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public int totalEnemys;
    static int currentEnemys;
    static Text score;

    private void Start()
    {
        currentEnemys = totalEnemys;
        score = GetComponent<Text>();
        score.text = "" + currentEnemys;
    }

    public static void decreaseEnemys() { 
        currentEnemys--;
        score.text = "" + currentEnemys;
    }

    public static bool isTheLevelComplete()
    {
        if (currentEnemys <= 0) return true;
        return false;
    }
}
