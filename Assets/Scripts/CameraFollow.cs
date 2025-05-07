using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    

    public Transform target; // Referencia al objeto del personaje
    public Vector3 offset; // Posición de la cámara relativa al personaje

    void LateUpdate()
    {
        // Ajuste de posición de la cámara
        transform.position = target.position + offset;
    }


}
