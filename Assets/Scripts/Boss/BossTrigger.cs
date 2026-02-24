using UnityEngine;
using Boss;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private BossBase boss;

    private bool _activated = false;

    private void OnTriggerEnter(Collider other)
    {

        if (_activated)
            return;

        if (other.CompareTag("Player"))
        {

            _activated = true;
            boss.SwitchState(BossAction.INIT);
            gameObject.SetActive(false);
        }
    }
}