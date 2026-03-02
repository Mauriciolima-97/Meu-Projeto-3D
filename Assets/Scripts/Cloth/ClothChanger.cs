using UnityEngine;
using System.Collections.Generic;

namespace Cloth
{
    public class ClothChanger : MonoBehaviour
    {
        public List<SkinnedMeshRenderer> meshParts;

        [Header("Configuração do Shader")]
        public string shaderIdName = "_MainTex";

        private Dictionary<SkinnedMeshRenderer, Texture> _defaultTextures = new Dictionary<SkinnedMeshRenderer, Texture>();

        private void Awake()
        {
            if (meshParts == null || meshParts.Count == 0)
            {
                meshParts = new List<SkinnedMeshRenderer>(GetComponentsInChildren<SkinnedMeshRenderer>());
            }

            foreach (var mesh in meshParts)
            {
                if (mesh != null && mesh.sharedMaterial != null)
                {

                    if (mesh.sharedMaterial.HasProperty(shaderIdName))
                    {
                        _defaultTextures[mesh] = mesh.sharedMaterial.GetTexture(shaderIdName);
                    }
                }
            }
        }

        public void ChangeTexture(ClothSetup setup)
        {
            if (setup == null || setup.texture == null) return;

            foreach (var mesh in meshParts)
            {
                Apply(mesh, setup.texture);
            }
        }

        public void ResetTexture()
        {
            foreach (var mesh in meshParts)
            {
                if (_defaultTextures.ContainsKey(mesh))
                {
                    Apply(mesh, _defaultTextures[mesh]);
                }
            }
        }

        private void Apply(SkinnedMeshRenderer mesh, Texture tex)
        {
            if (mesh == null || tex == null) return;

            MaterialPropertyBlock block = new MaterialPropertyBlock();
            mesh.GetPropertyBlock(block);
            block.SetTexture(shaderIdName, tex);
            mesh.SetPropertyBlock(block);
        }
    }
}