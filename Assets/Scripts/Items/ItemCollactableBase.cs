using Itens;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itens
{
    public class ItemCollactableBase : MonoBehaviour
    {
        public ItemType itemType;

        public string compareTag = "Player";
        public ParticleSystem _particleSystem;
        public float timeToHide = 3;
        public GameObject graphicItem;

        public Collider _collider;
        private bool _collected;

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
                _collected = true;
                Collect();
            }
        }

        protected virtual void Collect()
        {
            if (_collider != null) _collider.enabled = false;
            if (graphicItem != null) graphicItem.SetActive(false);
            Invoke("HideObject", timeToHide);
            OnCollect();
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnCollect()
        {
            if (_particleSystem != null) _particleSystem.Play();
            if (audioSource != null) audioSource.Play();
            ItemManager.Instance.AddByType(itemType);
            //Destroy(gameObject);

        }
    }


    //public class ItemCollactableCoin : ItemCollactableBase
}