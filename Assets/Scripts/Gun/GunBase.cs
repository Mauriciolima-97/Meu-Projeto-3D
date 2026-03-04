using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float timeBetweenShoot = .2f;
    public float speed = 50f;

    private Coroutine _currentCoroutine;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootClip;

    protected virtual void Awake()
    {

    }
    protected virtual void OnDisable()
    {
        StopShoot();
    }

    protected void PlayShootSound()
    {
        if (audioSource != null && shootClip != null)
        {
            audioSource.pitch = 1f;
            audioSource.volume = 1f;
            audioSource.PlayOneShot(shootClip, 1f);
        }
    }

    protected virtual IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public virtual void Shoot()
    {
        if (prefabProjectile == null || positionToShoot == null) return;

        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
        projectile.speed = speed;

        PlayShootSound();
    }

    public void StartShoot()
    {
        StopShoot();
        // --- TRAVA DE SEGURANÇA 2: Check de Ativação ---
        // Só começa a atirar se o objeto estiver ativo na cena.
        if (gameObject.activeInHierarchy)
        {
            _currentCoroutine = StartCoroutine(ShootCoroutine());
        }
    }

    public void StopShoot()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
    }
}