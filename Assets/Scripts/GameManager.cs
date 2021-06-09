using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text mazesCompletedUI;

    private void Start()
    {
        EventBroker.onWin.AddListener(Win);
        mazesCompletedUI.text = PlayerPrefs.GetInt("completed").ToString();
    }

    void Win()
    {
        int completed = PlayerPrefs.GetInt("completed");
        PlayerPrefs.SetInt("completed", ++completed);
        mazesCompletedUI.text = completed.ToString();
    }
}
