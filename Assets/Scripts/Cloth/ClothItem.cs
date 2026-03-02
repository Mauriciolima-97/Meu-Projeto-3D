using UnityEngine;
using Cloth;

public class ClothItem : MonoBehaviour
{
    public ClothType clothType; // Escolha no Inspector qual roupa este item dá

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Chama o Manager para trocar a roupa e SALVAR
            ClothManager.Instance.ChangeCloth(clothType);

            // Destroi o item da cena ou desativa
            Destroy(gameObject);
        }
    }
}