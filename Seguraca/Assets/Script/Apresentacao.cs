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
        "Extintor de �gua Pressurizada:\r\n" +
            "\r\nMeio de Extin��o: Utiliza �gua pressurizada como agente extintor principal." +
            "\r\nIndica��o de Uso: Eficaz em inc�ndios de Classe A, que envolvem materiais s�lidos combust�veis." +
            "\r\nLimita��es: Pode ser perigoso em inc�ndios el�tricos ou em presen�a de l�quidos inflam�veis." ,

        "Extintor de G�s Carb�nico (CO2):\r\n" +
            "\r\nMeio de Extin��o: Utiliza g�s carb�nico sob press�o como agente extintor." +
            "\r\nindica��o de Uso: Eficiente em inc�ndios de Classe B (l�quidos inflam�veis) e Classe C (equipamentos el�tricos energizados)." +
            "\r\nR�pida Evapora��o: O g�s carb�nico atua rapidamente, removendo o oxig�nio do fogo e abafando as chamas.",

        "Extintor de P� Qu�mico:\r\n" +
            "\r\nMeio de Extin��o: Cont�m um p� qu�mico seco como agente extintor." +
            "\r\nIndica��o de Uso: Vers�til, adequado para inc�ndios de Classe A, B e C." +
            "\r\nMecanismo de A��o: O p� qu�mico forma uma camada sobre o material inflamado, interrompendo a rea��o em cadeia do fogo.",

        "Agora gostaria de compartilhar algumas informa��es importantes sobre como usar os extintores de inc�ndio de maneira eficaz e segura. " +
            "Como parte de nossos esfor�os para promover a seguran�a em nossos ambientes, � essencial entender como lidar com diferentes tipos de inc�ndios e qual extintor usar em cada situa��o. " +
            "Vamos explorar juntos os tr�s tipos principais de extintores. Vamos come�ar!" ,

            "Passo 1: Determine se � um inc�ndio de qualquer tipo (s�lidos, l�quidos inflam�veis ou equipamentos el�tricos)." +
            "\r\nPasso 2: Pegue o extintor e remova o pino de seguran�a." +
            "\r\nPasso 3: Aponte o bico para a base das chamas.Passo " +
            "\r\nPasso 4: Aperte a alavanca para liberar o Material.Passo " +
            "\r\nPasso 5: Cubra as chamas com o Material, movendo o extintor para abranger toda a �rea em chamas." +
            "\r\nPasso 6: Certifique-se de que o fogo tenha sido totalmente apagado.",

            "Agora vamos para algumas poss�veis situa��es de inc�ndios. Podemos encontrar-nos diante de diferentes " +
            "cen�rios que requerem a��o r�pida e decisiva para garantir a seguran�a de todos. Vamos analisar algumas " +
            "dessas situa��es e discutir como devemos proceder em cada uma delas."
    };

    private float tempo;
    private bool isGazing = false;

    public Button button;
    public GameObject buttonGameObject;

    //som
    public AudioClip[] audioSources; // Array de AudioSource
    private AudioSource audioSource; // Refer�ncia ao componente AudioSource
    private int currentSourceIndex = 0;

    //var global
    private static int num=0;

    void Start()
    {
        num = 0;
        // Obt�m a refer�ncia ao componente AudioSource
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
    // Fun��o para pausar todos os sons
    public void PauseAllSounds()
    {
        // Pausa o componente AudioSource
        audioSource.Pause();
    }
    // Fun��o para reproduzir um som espec�fico
    public void PlaySoundOnce(AudioClip soundEffect)
    {
        // Verifica se h� um som definido
        if (soundEffect != null)
        {
            // Reproduz o som no AudioSource atual
            GetComponent<AudioSource>().PlayOneShot(soundEffect);

            // Atualiza o �ndice do pr�ximo AudioSource a ser usado
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
    // Fun��o para trocar o material de um objeto
    public void TrocarMaterial(GameObject objeto, Material novoMaterial)
    {
        // Verifica se o objeto e o material n�o s�o nulos
        if (objeto != null && novoMaterial != null)
        {
            // Obt�m o Renderer do objeto
            Renderer renderer = objeto.GetComponent<Renderer>();

            // Se o objeto tiver um Renderer, troca o material
            if (renderer != null)
            {
                renderer.material = novoMaterial;
            }
            else
            {
                Debug.LogWarning("O objeto n�o possui um Renderer para trocar o material.");
            }
        }
        else
        {
            Debug.LogWarning("Objeto ou material fornecido � nulo.");
        }
    }
    // Fun��o para fazer o objeto desaparecer
    public void Desaparecer(GameObject objeto)
    {
        if (objeto != null)
        {
            objeto.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Objeto fornecido � nulo.");
        }
    }

    // Fun��o para fazer o objeto aparecer
    public void Aparecer(GameObject objeto)
    {
        if (objeto != null)
        {
            objeto.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Objeto fornecido � nulo.");
        }
    }
}
