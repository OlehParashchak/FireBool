using Game;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    //���������� ��� ������� �� ������ ������ ����
    [UsedImplicitly]
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(GlobalConstants.GAME_SCENE);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}