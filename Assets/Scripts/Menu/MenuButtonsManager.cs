using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuButtonsManager : MonoBehaviour
{
    public List<GameObject> buttons;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    [Header("Scene")]
    public string gameSceneName = "Game";

    [Header("Sound Sprites")]
    public Image soundButtonImage; // Arraste a imagem do botão aqui
    public Sprite soundOnSprite;   // Arraste a sprite de som ligado
    public Sprite soundOffSprite;  // Arraste a sprite de som desligado

    public void ToggleSound()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.ToggleMute();
            UpdateSoundIcon();
        }
    }

    private void UpdateSoundIcon()
    {
        // O "if" abaixo checa se você realmente arrastou as coisas no Inspector
        if (soundButtonImage != null && soundOnSprite != null && soundOffSprite != null)
        {
            bool isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
            soundButtonImage.sprite = isMuted ? soundOffSprite : soundOnSprite;
        }
        else
        {
            Debug.LogWarning("MenuButtonsManager: Faltam referências de Sprites ou Image no Inspector!");
        }
    }

    // Chame o UpdateSoundIcon no Start para o botão começar com o ícone certo
    private void Start()
    {
        UpdateSoundIcon();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartLevel()
    {
        if (CheckpointManager.Instance != null)
        {
            CheckpointManager.Instance.useCheckpointOnStart = false;

            PlayerPrefs.DeleteKey("CheckpointKey");
        }

        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.LoadGame();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadGameFromSave()
    {
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.LoadGame();
            SaveManager.Instance.ReloadItemsFromSave();
        }

        if (CheckpointManager.Instance != null)
        {
            CheckpointManager.Instance.useCheckpointOnStart = true;
        }

        SceneManager.LoadScene(gameSceneName);
    }

    public void ResetCheckpoint()
    {
        PlayerPrefs.DeleteKey("CheckpointKey");
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void Awake()
    {
        HideAllButtons();
        ShowButtons(); 
    }

    private void HideAllButtons()
    {
        foreach (var b  in buttons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }

    private void ShowButtons()
    {

        //foreach (var b in buttons)
        for (int i = 0; i < buttons.Count; i++)
        {
            var b = buttons[i];
            b.SetActive(true);
            b.transform.DOScale(0.5f, duration).SetDelay(i*delay).SetEase(ease);
        }
    }
}