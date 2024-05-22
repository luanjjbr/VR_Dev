using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleBotoes : MonoBehaviour
{
    private float tempo;
    private bool isGazing = false;
    public float TempoOBS;
    public string nomeDaCena;

    // Método chamado quando o botão de mudar de cena é clicado
    public static void MudarDeCena(string nomeDaCena)
    {

        SceneManager.LoadScene(nomeDaCena);
    }

    // Método chamado quando o botão de fechar é clicado
    public void FecharPrograma()
    {
        // Este código pode não funcionar em todas as plataformas, 
        // dependendo das configurações e do ambiente.
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
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
                if (nomeDaCena == "Sair")
                {
                    FecharPrograma();
                }
                else if (nomeDaCena == "Reinicia")
                {

                    // Reinicia a cena atual (pode ser necessário ajustar se você tiver várias cenas)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                else if (nomeDaCena == ".")
                {
                }
                else
                {
                    MudarDeCena(nomeDaCena);
                }
            }
        }
    }
}
