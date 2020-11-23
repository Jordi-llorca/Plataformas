using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject loader;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (EnemyCounter.isTheLevelComplete())
        {
            if (collision.tag == "Player") loader.GetComponent<levelLoder>().LoadNextLevel();
        }
    }
}
