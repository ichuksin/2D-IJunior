using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    public void OnClickExitButton()
    {
        Application.Quit();
    }
    public void OnClickStartButton()
    {
        SceneManager.LoadScene(0);
    }
    public void OnClickAboutButton()
    {
        _panel.SetActive(true);
    }
    public void OnClickCloseButton()
    {
        _panel.SetActive(false);
    }

}
