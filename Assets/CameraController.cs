using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public float scaleCoef;
    private float minSize;
    void Start()
    {
        minSize =  GetComponent<Camera>().orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 averagePos = ((Vector2)player1.transform.position + (Vector2)player2.transform.position) / 2;
        float dist = Vector2.Distance((Vector2)player1.transform.position, (Vector2)player2.transform.position);
        transform.position = new Vector3(averagePos.x, averagePos.y, transform.position.z);
        GetComponent<Camera>().orthographicSize = Mathf.Max(scaleCoef * dist, minSize);
    }
}
