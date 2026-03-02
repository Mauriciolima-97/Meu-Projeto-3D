using Ebac.Core.Singleton;
using Ebac.StateMachine;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        INTRO,
        GAMEPLAY,
        PAUSE,
        WIN,
        LOSE
    }

    public StateMachine<GameStates> stateMachine;

    private void Start()
    {
        Init();
        ApplyLoadedData();
    }

    public void Init()
    {
        stateMachine = new StateMachine<GameStates>();

        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.INTRO, new GMStateIntro());
        stateMachine.RegisterStates(GameStates.GAMEPLAY, new StateBase());
        stateMachine.RegisterStates(GameStates.PAUSE, new StateBase());
        stateMachine.RegisterStates(GameStates.WIN, new StateBase());
        stateMachine.RegisterStates(GameStates.LOSE, new StateBase());

        stateMachine.SwitchState(GameStates.INTRO);

    }
    private void OnEnable()
    {
        SaveManager.Instance.FileLoaded += OnFileLoaded;
    }

    private void OnDisable()
    {
        SaveManager.Instance.FileLoaded -= OnFileLoaded;
    }
    private void OnFileLoaded(SaveSetup setup)
    {
        var player = Player.Instance;

        if (player == null) return;

        Vector3 loadedPosition = new Vector3(
            setup.playerPosX,
            setup.playerPosY,
            setup.playerPosZ
        );

        player.characterController.enabled = false;
        player.transform.position = loadedPosition;
        player.characterController.enabled = true;
    }
    private void ApplyLoadedData()
    {
        if (SaveManager.Instance.IsNewGame)
            return; // não aplica posição se for novo jogo

        var setup = SaveManager.Instance.Setup;
        var player = Player.Instance;

        if (player == null) return;

        Vector3 loadedPosition = new Vector3(
            setup.playerPosX,
            setup.playerPosY,
            setup.playerPosZ
        );

        player.characterController.enabled = false;
        player.transform.position = loadedPosition;
        player.characterController.enabled = true;
    }
}
