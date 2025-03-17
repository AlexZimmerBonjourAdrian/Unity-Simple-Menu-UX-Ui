using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour, IMenuUi
{

    public void OnBackMenu(int Str)
    {
        SceneManager.LoadScene(Str);
    }
}
