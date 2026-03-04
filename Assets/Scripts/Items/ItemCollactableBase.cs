using Itens;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

namespace Itens
{
    public class ItemCollactableBase : MonoBehaviour
    {
        public SFXType sfxType;
        public ItemType itemType;

        public string compareTag = "Player";
        public ParticleSystem _particleSystem;
        public float timeToHide = 3;
        public GameObject graphicItem;

        public Collider _collider;
        private bool _collected;
        public string itemID;

        [Header("Sounds")]
        public AudioSource audioSource;

        private void Awake()
        {
            //if (particleSystem != null) particleSystem.transform.SetParent(null);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (_collected) return;

            if (collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }

        private void PlaySFX()
        {
            SFXPool.Instance.Play(sfxType);
        }

        protected virtual void Collect()
        {
            if (_collected) return;
            _collected = true;

            PlaySFX();
            if (_collider != null) _collider.enabled = false;
            if (graphicItem != null) graphicItem.SetActive(false);
            Invoke("HideObject", timeToHide);
            OnCollect();
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }
        private void Start()
        {
            if (SaveManager.Instance.Setup.collectedItems.Contains(itemID))
            {
                gameObject.SetActive(false);
            }
        }

        protected void OnCollect()
        {
            if (!SaveManager.Instance.Setup.collectedItems.Contains(itemID))
            {
                SaveManager.Instance.Setup.collectedItems.Add(itemID);
                SaveManager.Instance.SaveItens();
            }

            if (_particleSystem != null) _particleSystem.Play();
            if (audioSource != null) audioSource.Play();

            ItemManager.Instance.AddByType(itemType);
        }
    }


    //public class ItemCollactableCoin : ItemCollactableBase
}