using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] Button exitBtn;

    void Start()
    {
        startBtn.onClick.AddListener(start);

        exitBtn.onClick.AddListener(exit);
    }

    void start()
    {
        SceneManager.LoadScene(1);
    }

    void exit()
    {
        Application.Quit();
    }
}
