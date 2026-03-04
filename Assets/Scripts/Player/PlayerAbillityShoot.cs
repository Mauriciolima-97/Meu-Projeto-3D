using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbillityShoot : PlayerAbillityBase
{
    public GunBase gun1;
    public GunBase gun2;

    public Transform gunPosition;

    private GunBase _currentGun;
    private GunBase _spawnedGun1;
    private GunBase _spawnedGun2;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootClip;

    public FlashColor _flashColor;



    protected override void Init()
    {
        base.Init();

        CreateGuns();

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();

        inputs.Gameplay.Weapon1.performed += ctx => SwitchWeapon(1);
        inputs.Gameplay.Weapon2.performed += ctx => SwitchWeapon(2);
    }

    private void CreateGuns()
    {
        _spawnedGun1 = Instantiate(gun1, gunPosition);
        _spawnedGun2 = Instantiate(gun2, gunPosition);

        _spawnedGun1.transform.localPosition = Vector3.zero;
        _spawnedGun2.transform.localPosition = Vector3.zero;

        _spawnedGun2.gameObject.SetActive(false);

        _currentGun = _spawnedGun1;
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
        _flashColor?.Flash();

        if (audioSource != null && shootClip != null)
        {
            audioSource.pitch = Random.Range(0.95f, 1.05f);
            audioSource.PlayOneShot(shootClip);
        }
    }

    private void OnDisable()
    {
        // Se o script for desativado por qualquer motivo (morte, pause, etc)
        if (_currentGun != null) _currentGun.StopShoot();
    }

    private void CancelShoot()
    {
        _currentGun.StopShoot();
    }

    private void SwitchWeapon(int index)
    {
        // SEGURANÇA: Para o tiro da arma atual antes de trocá-la
        if (_currentGun != null) _currentGun.StopShoot();

        _spawnedGun1.gameObject.SetActive(index == 1);
        _spawnedGun2.gameObject.SetActive(index == 2);

        _currentGun = (index == 1) ? _spawnedGun1 : _spawnedGun2;
    }
}
