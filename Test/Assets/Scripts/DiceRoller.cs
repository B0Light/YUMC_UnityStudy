using System.Collections;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void OnEnable()
    {
        GameEvent.OnRolled += Roll;
    }

    private void OnDisable()
    {
        GameEvent.OnRolled -= Roll;
    }

    public void Roll()
    {
        Debug.Log("ROLL!");

        transform.position = initialPosition;
        transform.rotation = initialRotation;
        
        rigidbody.AddForce(new Vector3(Random.Range(-5, 5), 10, Random.Range(-5, 5)), ForceMode.Impulse);
        rigidbody.AddTorque(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)), ForceMode.Impulse);
        
        StartCoroutine(CheckDiceResult());
    }
    
    private IEnumerator CheckDiceResult()
    {
        yield return new WaitForSeconds(1.0f);
        
        while (rigidbody.velocity.magnitude > 0.1)
        {
            yield return new WaitForSeconds(1.0f);
        }
        
        Debug.Log("Dice Result: " + GetDiceResult());
    }

    private int GetDiceResult()
    {
        Vector3[] directions = { transform.right, transform.up, transform.forward };
        int[] faceValues = { 4, 2, 1, 3, 5, 6 };
    
        for (int i = 0; i < directions.Length; i++)
        {
            float dotProduct = Vector3.Dot(Vector3.up, directions[i]);

            if (Mathf.Abs(dotProduct) > 0.5f)
            {
                return dotProduct > 0 ? faceValues[i] : faceValues[i + 3];
            }
        }

        return 0;
    }
}
