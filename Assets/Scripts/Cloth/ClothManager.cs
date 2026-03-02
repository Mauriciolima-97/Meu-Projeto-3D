using Ebac.Core.Singleton;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cloth
{
    public enum ClothType
    {
        PADRAO,
        SPEED,
        STRONG,
        COLOR
    }

    public class ClothManager : Singleton<ClothManager>
    {
        public List<ClothSetup> clothSetups;

        private void Start()
        {
            LoadCloth();
        }

        public void ChangeCloth(ClothType type)
        {
            SetCloth(type);

            SaveManager.Instance.Setup.currentCloth = type;
            SaveManager.Instance.SaveItens();
        }

        public void SetCloth(ClothType type)
        {
            ClothSetup setup = GetSetupByType(type);

            if (setup == null)
            {
                return;
            }

            ApplyTexture(setup);
        }

        private ClothSetup GetSetupByType(ClothType type)
        {
            return clothSetups.Find(i => i.clothType == type);
        }

        private void ApplyTexture(ClothSetup setup)
        {
            // Tenta pegar pela Instance, já que o Player é Singleton
            Player player = Player.Instance;

            if (player == null) player = FindObjectOfType<Player>();
            if (player == null) return;

            ClothChanger changer = player.GetComponentInChildren<ClothChanger>();

            if (changer != null)
            {
                Debug.Log($"@@@ Tentando mudar para a textura: {setup.texture.name}");
                changer.ChangeTexture(setup);
            }
        }

        private void LoadCloth()
        {
            ClothType savedCloth = SaveManager.Instance.Setup.currentCloth;

            SetCloth(savedCloth);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            LoadCloth();
            Invoke(nameof(LoadCloth), 0.2f);
        }
    }

    [System.Serializable]
    public class ClothSetup
    {
        public ClothType clothType;
        public Texture2D texture;
    }
}