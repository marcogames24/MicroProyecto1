using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    

    public Transform target; // Referencia al objeto del personaje
    public Vector3 offset; // Posici�n de la c�mara relativa al personaje

    void LateUpdate()
    {
        // Ajuste de posici�n de la c�mara
        transform.position = target.position + offset;
    }


}
