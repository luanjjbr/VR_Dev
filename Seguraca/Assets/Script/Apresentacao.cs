using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Apresentacao : MonoBehaviour
{
    // troca de material
    public GameObject objetoParaTrocar;
    public GameObject[] extintor;
    public Material[] novoMaterial;

    //text
    public TextMeshProUGUI textMeshProComponent;
    public float TempoOBS;
    string[] texto= {
        "Extintor de Água Pressurizada:\r\n" +
            "\r\nMeio de Extinção: Utiliza água pressurizada como agente extintor principal." +
            "\r\nIndicação de Uso: Eficaz em incêndios de Classe A, que envolvem materiais sólidos combustíveis." +
            "\r\nLimitações: Pode ser perigoso em incêndios elétricos ou em presença de líquidos inflamáveis." ,

        "Extintor de Gás Carbônico (CO2):\r\n" +
            "\r\nMeio de Extinção: Utiliza gás carbônico sob pressão como agente extintor." +
            "\r\nindicação de Uso: Eficiente em incêndios de Classe B (líquidos inflamáveis) e Classe C (equipamentos elétricos energizados)." +
            "\r\nRápida Evaporação: O gás carbônico atua rapidamente, removendo o oxigênio do fogo e abafando as chamas.",

        "Extintor de Pó Químico:\r\n" +
            "\r\nMeio de Extinção: Contém um pó químico seco como agente extintor." +
            "\r\nIndicação de Uso: Versátil, adequado para incêndios de Classe A, B e C." +
            "\r\nMecanismo de Ação: O pó químico forma uma camada sobre o material inflamado, interrompendo a reação em cadeia do fogo.",

        "Agora gostaria de compartilhar algumas informações importantes sobre como usar os extintores de incêndio de maneira eficaz e segura. " +
            "Como parte de nossos esforços para promover a segurança em nossos ambientes, é essencial entender como lidar com diferentes tipos de incêndios e qual extintor usar em cada situação. " +
            "Vamos explorar juntos os três tipos principais de extintores. Vamos começar!" ,

            "Passo 1: Determine se é um incêndio de qualquer tipo (sólidos, líquidos inflamáveis ou equipamentos elétricos)." +
            "\r\nPasso 2: Pegue o extintor e remova o pino de segurança." +
            "\r\nPasso 3: Aponte o bico para a base das chamas.Passo " +
            "\r\nPasso 4: Aperte a alavanca para liberar o Material.Passo " +
            "\r\nPasso 5: Cubra as chamas com o Material, movendo o extintor para abranger toda a área em chamas." +
            "\r\nPasso 6: Certifique-se de que o fogo tenha sido totalmente apagado.",

            "Agora vamos para algumas possíveis situações de incêndios. Podemos encontrar-nos diante de diferentes " +
            "cenários que requerem ação rápida e decisiva para garantir a segurança de todos. Vamos analisar algumas " +
            "dessas situações e discutir como devemos proceder em cada uma delas."
    };

    private float tempo;
    private bool isGazing = false;

    public Button button;
    public GameObject buttonGameObject;

    //som
    public AudioClip[] audioSources; // Array de AudioSource
    private AudioSource audioSource; // Referência ao componente AudioSource
    private int currentSourceIndex = 0;

    //var global
    private static int num=0;

    void Start()
    {
        num = 0;
        // Obtém a referência ao componente AudioSource
        audioSource = GetComponent<AudioSource>();
        StopAllSounds();
        PlaySoundOnce(audioSources[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGazing)
        {
            tempo += Time.deltaTime;

            if ((tempo >= TempoOBS))
            {
                switch (num)
                {
                    case 0: TrocarMaterial(objetoParaTrocar, novoMaterial[num]); Aparecer(extintor[0]); Desaparecer(extintor[4]); break;
                    case 1: TrocarMaterial(objetoParaTrocar, novoMaterial[num]); Aparecer(extintor[2]); Desaparecer(extintor[0]); break;
                    case 2: TrocarMaterial(objetoParaTrocar, novoMaterial[num]); Aparecer(extintor[1]); Desaparecer(extintor[2]); break;
                    case 3: TrocarMaterial(objetoParaTrocar, novoMaterial[num]); Desaparecer(extintor[1]); break;
                    case 4: TrocarMaterial(objetoParaTrocar, novoMaterial[num]); Aparecer(extintor[3]); break;
                    case 5: TrocarMaterial(objetoParaTrocar, novoMaterial[num]); Desaparecer(extintor[3]); break;
                    case 6: ControleBotoes.MudarDeCena("Tipo_A"); break;
                }
                isGazing = false;
                if(num !=6) { 
                DisplayGreeting(num);
                StopAllSounds();
                PlaySoundOnce(audioSources[num+1]);
                }
                num++;
                Debug.Log(num);
            }
        }
    }
    private void DisplayGreeting(int id)
    {
        textMeshProComponent.text = texto[id];
    }
    public void MudarDeCena(string nomeDaCena)
    {

        SceneManager.LoadScene(nomeDaCena);
    }

    //som
    public void StopAllSounds()
    {
        // Para o componente AudioSource
        audioSource.Stop();
    }
    // Função para pausar todos os sons
    public void PauseAllSounds()
    {
        // Pausa o componente AudioSource
        audioSource.Pause();
    }
    // Função para reproduzir um som específico
    public void PlaySoundOnce(AudioClip soundEffect)
    {
        // Verifica se há um som definido
        if (soundEffect != null)
        {
            // Reproduz o som no AudioSource atual
            GetComponent<AudioSource>().PlayOneShot(soundEffect);

            // Atualiza o índice do próximo AudioSource a ser usado
            currentSourceIndex = (currentSourceIndex + 1) % audioSources.Length;
        }
        else
        {
            Debug.LogWarning("Sound effect not set!");
        }
    }

    public void OnPointerExit()
    {
        isGazing = false;
        tempo = 0.0f;
    }
    public void OnPointerEnter()
    {
        isGazing = true;
    }
    // Função para trocar o material de um objeto
    public void TrocarMaterial(GameObject objeto, Material novoMaterial)
    {
        // Verifica se o objeto e o material não são nulos
        if (objeto != null && novoMaterial != null)
        {
            // Obtém o Renderer do objeto
            Renderer renderer = objeto.GetComponent<Renderer>();

            // Se o objeto tiver um Renderer, troca o material
            if (renderer != null)
            {
                renderer.material = novoMaterial;
            }
            else
            {
                Debug.LogWarning("O objeto não possui um Renderer para trocar o material.");
            }
        }
        else
        {
            Debug.LogWarning("Objeto ou material fornecido é nulo.");
        }
    }
    // Função para fazer o objeto desaparecer
    public void Desaparecer(GameObject objeto)
    {
        if (objeto != null)
        {
            objeto.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Objeto fornecido é nulo.");
        }
    }

    // Função para fazer o objeto aparecer
    public void Aparecer(GameObject objeto)
    {
        if (objeto != null)
        {
            objeto.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Objeto fornecido é nulo.");
        }
    }
}
