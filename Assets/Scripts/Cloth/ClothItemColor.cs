using UnityEngine;

namespace Cloth
{
    public class ClothItemColor : ClothItemBase
    {
        public override void Collect()
        {
            Debug.Log("@@@ Coletou item de cor: " + clothType);

            if (ClothManager.Instance != null)
            {
                ClothManager.Instance.ChangeCloth(clothType);
            }

            base.Collect();
        }
    }
}