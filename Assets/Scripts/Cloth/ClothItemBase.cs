using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public class ClothItemBase : MonoBehaviour
    {
        public ClothType clothType;
        public float duration = 2f;

        public string compareTag = "Player";

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }

        public virtual void Collect()
        {
            if (ClothManager.Instance != null)
            {
                ClothManager.Instance.ChangeCloth(clothType);
            }

            HideObject();
        }

        private void HideObject()
        {
            gameObject.SetActive(false);

        }

    }
}

