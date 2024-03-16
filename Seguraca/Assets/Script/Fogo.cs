using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.UI;

public class Fogo : MonoBehaviour
{
    //public TextMeshProUGUI textMeshProComponent;
    public float TempoOBS;
    public GameObject id;
    public GameObject id2;
    public string nome = "agua(Clone)";

    //public Renderer objectRenderer;

    private float tempo;
    private bool isGazing = false;
    public ParticleSystem fogo;
    public ParticleSystem extintor;

    void Start()
    {
    }
    /*
    public void Start()
    {
    }*/

    public void OnPointerEnter()
    {
        isGazing = true;
        AtivarParticula(extintor);
    }

    public void OnPointerExit()
    {
        isGazing = false;
        tempo = 0.0f;
        DesativarParticula(extintor);
    }

    public void OnPointerClick()
    {
    }

    private void Update()
    {
        if (isGazing)
        {
            tempo += Time.deltaTime;

            if (tempo >= TempoOBS && Verificar())
            {
                tempo = 0;
                isGazing = false;
                DesativarParticula(fogo);
                DesativarCollider();
                Invoke("DesativarObjeto", 1);
            }
        }
    }
    void DesativarObjeto()
    {
        // Desativa o objeto
        gameObject.SetActive(false);
    }
    void DesativarCollider()
    {
        // Obtém o Collider associado ao objeto
        Collider colliderDoObjeto = GetComponent<Collider>();

        // Verifica se o Collider existe antes de tentar desativá-lo
        if (colliderDoObjeto != null)
        {
            // Desativa o collider
            colliderDoObjeto.enabled = false;
        }
        else
        {
            Debug.LogWarning("Collider não encontrado no objeto.");
        }
    }
    void DesativarParticula(ParticleSystem sistemaDeParticulas)
    {
        // Verifica se o sistema de part�culas n�o � nulo antes de tentar desativ�-lo
        if (sistemaDeParticulas != null)
        {
            // Desativa o sistema de part�culas
            sistemaDeParticulas.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Sistema de part�culas � nulo. Certifique-se de ter configurado corretamente.");
        }
    }
    void AtivarParticula(ParticleSystem sistemaDeParticulas)
    {
        GameObject objeto1 = GameObject.FindGameObjectWithTag("mao");
        if (objeto1 != id2)
        {
            // Verifica se o sistema de part�culas n�o � nulo antes de tentar ativ�-lo
            if (sistemaDeParticulas != null)
            {
                // Ativa o sistema de part�culas
                sistemaDeParticulas.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("Sistema de part�culas � nulo. Certifique-se de ter configurado corretamente.");
            }
        }
    }
    bool Verificar()
    {
        // Encontrar objeto pela tag
        GameObject objeto1 = GameObject.FindGameObjectWithTag("mao");

        // Verificar se o objeto foi encontrado e se o nome é "agua(Clone)"
        if (objeto1 != null && objeto1.name == nome)
        {
            return true;
        }
        return false;
    }
}