using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        EventBroker.onWin.AddListener(Win);
    }

    void Win()
    {
        int completed = PlayerPrefs.GetInt("completed");
        PlayerPrefs.SetInt("completed", ++completed);
        Debug.Log("Mazes completed: " + PlayerPrefs.GetInt("completed"));
    }
}
