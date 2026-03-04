using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

namespace Cloth
{
    public class ClothItemStrong : ClothItemBase
    {
        public float damageMultiply = 2f;

        public SFXType sfxType;

        private void PlaySFX()
        {
            SFXPool.Instance.Play(sfxType);
        }
        public override void Collect()
        {
            PlaySFX();
            base.Collect();
            Player.Instance.healthBase.ChangeDamageMultiply(damageMultiply, duration);
        }
    }
}
