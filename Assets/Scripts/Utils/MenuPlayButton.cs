using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlayButton : MonoBehaviour
{
    public int firstLevelIndex = 1;

    public void PlayNewGame()
    {
        SaveManager.Instance.ResetSave();
        SceneManager.LoadScene(firstLevelIndex);
    }
}