using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoadButton : MonoBehaviour
{
    public void LoadGame()
    {
        SaveManager.Instance.LoadGame();

        int levelToLoad = SaveManager.Instance.lastLevel;

        SceneManager.LoadScene(levelToLoad);
    }
}