using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    [SerializeField] Button backBtn;

    void Start()
    {
        backBtn.onClick.AddListener(back);
    }

    void back()
    {
        SceneManager.LoadScene(0);
    }
}
