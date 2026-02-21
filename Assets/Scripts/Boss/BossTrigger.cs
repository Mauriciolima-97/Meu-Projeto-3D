using UnityEngine;
using Boss;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private BossBase boss;

    private bool _activated = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ACIONADO");

        if (_activated)
            return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER ENTROU NO TRIGGER");

            _activated = true;
            boss.SwitchState(BossAction.INIT);
            gameObject.SetActive(false);
        }
    }
}