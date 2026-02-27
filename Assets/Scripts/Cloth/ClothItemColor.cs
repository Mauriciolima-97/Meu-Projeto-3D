using UnityEngine;

namespace Cloth
{
    public class ClothItemColor : ClothItemBase
    {
        public override void Collect()
        {
            base.Collect();

            var setup = ClothManager.Instance.GetSetupByType(clothType);

            if (setup == null)
            {
            }

            Player.Instance.ChangeTexture(setup, duration);
        }
    }
}