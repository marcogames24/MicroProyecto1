using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelSystem : MonoBehaviour
{
    //public void NextLevel2 ()// Este m�todo esta orientado para el nivel1 del juego//
    //                         //en la victory panel del nivel 1 cuando el jugador quiera presionar el bot�n de
    //                         //avanzar nivel //este se encargara de vargar al nivel 2 del juego es
    //{
    //    SceneManager.LoadScene("Level2 IceZone"); //Carga la escena donde se desarrolla el nivel2 del juego
    //    Debug.Log("Cargando el nivel2 IceZone");//Un mensaje para verificar que el codigo esta funcionando
    //}
    public void NextFinalLevel()  //Ahora aqui esta orientado para cargar el �ltimo nivel del juego.
                                  //cuando el jugador gana en el nivel2 en la pantalla de victoria el jugador 
                                  //tendra la opci�n de avanzar al pr�ximo nivel que en este caso es el �ltimo 
                                  //y al presionar el bot�n podra cargar el nivel 3 FinalZone
    
    {

        SceneManager.LoadScene("New Scene") ; //Cargara la escena donde se desarrolla el nivel final
        Debug.Log("Cargando el nivel2 IceZone");//Mensaje que indica cuando el jugador haya avanzado al �ltimo nivel.
    }
}
