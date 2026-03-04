using UnityEngine;
using static SoundManager;

namespace Cloth
{
    public class ClothItemColor : ClothItemBase
    {
        public SFXType sfxType;

        private void PlaySFX()
        {
            SFXPool.Instance.Play(sfxType);
        }
        public override void Collect()
        {
            Debug.Log("@@@ Coletou item de cor: " + clothType);

            if (ClothManager.Instance != null)
            {
                ClothManager.Instance.ChangeCloth(clothType);
            }

            PlaySFX();
            base.Collect();
        }
    }
}