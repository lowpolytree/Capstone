using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [HideInInspector] public int matchcount = 0;
    public int objectCount;
    public Text scoreText;

    private void Start()
    {
        scoreText.text = matchcount.ToString();
    }

    void Update()
    {
        if (matchcount > objectCount)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void IncrementMatchCount()
    {
        matchcount++;
        scoreText.text = matchcount.ToString();
    }
}
