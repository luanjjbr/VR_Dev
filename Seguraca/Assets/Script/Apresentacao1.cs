using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Apresentacao1 : MonoBehaviour
{
    //text
    public TextMeshProUGUI textMeshProComponent;
    public float TempoOBS;
    public string[] texto= {
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
    public static int num=0;

    void Start()
    {
        
        // Obtém a referência ao componente AudioSource
        audioSource = GetComponent<AudioSource>();
        StopAllSounds();
        DisplayGreeting(num);
        PlaySoundOnce(audioSources[num]);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGazing||Input.GetKeyDown(KeyCode.Space) || num==1)
        {
            tempo += Time.deltaTime;

            if ((tempo >= TempoOBS)|| Input.GetKeyDown(KeyCode.Space))
            {
                if (num==6)
                {
                    ControleBotoes.MudarDeCena("Tipo_A");
                }
                isGazing = false;
                DisplayGreeting(num);
                StopAllSounds();
                PlaySoundOnce(audioSources[num]);
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
}
