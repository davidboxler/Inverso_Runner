using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 3f;
    public Transform player;

    void Update()
    {
        transform.position += Vector3.right * cameraSpeed * Time.deltaTime;

        // Si el jugador se queda muy atrás de la cámara (por ejemplo, más de 2 unidades)
        if (player.position.x < transform.position.x - 5f)
        {
            GameManager.Instance.GameOver();
        }
    }
}
