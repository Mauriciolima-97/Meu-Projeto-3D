using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public class ClothChanger : MonoBehaviour
    {
        public SkinnedMeshRenderer mesh;

        public Texture2D texture;
        public string shaderIdName = "_EmissionMap";

        private Texture _defaultTexture;

        private void Awake()
        {
            if (mesh == null)
            {
                Debug.LogError("Mesh não atribuída no ClothChanger!");
                return;
            }

            var mat = mesh.sharedMaterials[0];

            _defaultTexture = mat.GetTexture(shaderIdName);

            mat.EnableKeyword("_EMISSION");
        }

        [NaughtyAttributes.Button]
        private void ChangeTexture()
        {
            mesh.sharedMaterials[0].SetTexture(shaderIdName, texture);
        }

        public void ChangeTexture(ClothSetup setup)
        {
            if (setup == null || setup.texture == null)
            {
                Debug.LogError("Setup ou Texture null!");
                return;
            }

            mesh.sharedMaterials[0].SetTexture(shaderIdName, setup.texture);
        }

        public void ResetTexture()
        {
            mesh.sharedMaterials[0].SetTexture(shaderIdName, _defaultTexture);
        }
    }
}