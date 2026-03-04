using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    private bool _activated;

    private void OnTriggerEnter(Collider other)
    {
        if (_activated) return;

        if (!other.CompareTag("Player")) return;

        _activated = true;

        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
}