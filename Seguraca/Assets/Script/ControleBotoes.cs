using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleBotoes : MonoBehaviour
{
    // Método chamado quando o botão de mudar de cena é clicado
    public void MudarDeCena(string nomeDaCena)
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

}
