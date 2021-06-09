using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text mazesCompletedUI;
    [SerializeField] GameObject victoryPanel;
    [SerializeField] Maze maze;
    [SerializeField] int mazeSize = 25;

    private void Start()
    {
        EventBroker.onWin.AddListener(Win);
        mazesCompletedUI.text = PlayerPrefs.GetInt("completed").ToString();
        MakeMaze();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            MakeMaze();
    }

    void Win()
    {
        int completed = PlayerPrefs.GetInt("completed");
        PlayerPrefs.SetInt("completed", ++completed);
        mazesCompletedUI.text = completed.ToString();
        victoryPanel.SetActive(true);
    }

    public void MakeMaze()
    {
        victoryPanel.SetActive(false);
        maze.Delete();
        maze.Make(mazeSize);
    }
}
