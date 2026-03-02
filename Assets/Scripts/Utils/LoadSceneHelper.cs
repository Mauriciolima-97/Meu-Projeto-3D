using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    private IEnumerator LoadLevelRoutine(int level)
    {
        SceneManager.LoadScene(level);

        yield return new WaitForSeconds(.2f);

        SaveManager.Instance.LoadGame();

    }
}