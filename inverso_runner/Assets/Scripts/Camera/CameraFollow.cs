using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 3f;
    public Transform player;

    void Update()
    {
        transform.position += Vector3.right * cameraSpeed * Time.deltaTime;

        // Si el jugador se queda muy atr�s de la c�mara (por ejemplo, m�s de 2 unidades)
        if (player.position.x < transform.position.x - 5f)
        {
            GameManager.Instance.GameOver();
        }
    }
}
