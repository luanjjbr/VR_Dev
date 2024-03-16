using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.UI;

public class Extintor : MonoBehaviour
{
    public GameObject objeto2;
    public Fogo scriptA;
    public int ideX;

    //public TextMeshProUGUI textMeshProComponent;
    public float TempoOBS;

    //public Renderer objectRenderer;

    private float tempo;
    private bool isGazing = false;

    public void Start()
    {
    }

    public void OnPointerEnter()
    {
        isGazing = true;
    }

    public void OnPointerExit()
    {
        isGazing = false;
        tempo = 0.0f;
    }

    public void OnPointerClick()
    {
    }

    private void Update()
    {
        if (isGazing)
        {
            tempo += Time.deltaTime;

            if (tempo >= TempoOBS)
            {
                isGazing = false;
                TrocarPosicaoERotacao();
            }
        }
    }
    void TrocarPosicaoERotacao()
    {
        // Encontrar objetos pela tag
        GameObject objeto1 = GameObject.FindGameObjectWithTag("mao");

        // Verificar se os objetos foram encontrados
        if (objeto1 != null && objeto2 != null)
        {
            // Salvar as informa��es do objeto 1 antes da troca
            Vector3 posicaoObjeto1 = objeto1.transform.position;
            Quaternion rotacaoObjeto1 = objeto1.transform.rotation;
            Transform paiObjeto1 = objeto1.transform.parent;
            string tagObjeto1 = objeto1.tag;

            // Salvar as informa��es do objeto 2 antes da troca
            Vector3 posicaoObjeto2 = objeto2.transform.position;
            Quaternion rotacaoObjeto2 = objeto2.transform.rotation;
            Transform paiObjeto2 = objeto2.transform.parent;
            string tagObjeto2 = objeto2.tag;

            // Trocar a posi��o dos objetos
            objeto1.transform.position = posicaoObjeto2;
            objeto2.transform.position = posicaoObjeto1;

            // Trocar a rota��o dos objetos
            objeto1.transform.rotation = rotacaoObjeto2;
            objeto2.transform.rotation = rotacaoObjeto1;

            // Trocar o parentesco dos objetos
            objeto1.transform.SetParent(paiObjeto2);
            objeto2.transform.SetParent(paiObjeto1);

            // Trocar as tags dos objetos
            objeto1.tag = tagObjeto2;
            objeto2.tag = tagObjeto1;
        }
        else
        {
            Debug.LogError("Objetos nao encontrados com as tags especificadas.");
        }
    }
}
