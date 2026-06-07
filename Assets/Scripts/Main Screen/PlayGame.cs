using UnityEngine;
// 1. Es obligatorio importar la librería de gestión de escenas
using UnityEngine.SceneManagement; 

public class PlayGame : MonoBehaviour // Corregido el detalle en el nombre de la clase
{
    // Start is called before the first frame update
    void Start()
    {
        // Si quieres que cargue apenas empiece el juego, descomenta la siguiente línea:
        // CargarSandBox();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 2. Creas una función pública para poder llamarla (por ejemplo, desde un Botón)
    public void CargarSandBox()
    {
        // 3. Esta es la línea clave que carga la escena por su nombre
        SceneManager.LoadScene("SandBox");
    }
}
