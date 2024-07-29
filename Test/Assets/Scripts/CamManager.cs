using UnityEngine;

public class CamManager : MonoBehaviour
{
    public InputManager inputManager;
    [SerializeField] float moveSpeed = 5f;
    void Update()
    {
        transform.Translate(new Vector3(inputManager.movementInput.x,0,inputManager.movementInput.y) * moveSpeed * Time.deltaTime, Space.World);
    }
}
