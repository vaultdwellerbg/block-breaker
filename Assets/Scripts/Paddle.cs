using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] public float screenWidthInUnits = 16f;
    [SerializeField] public float minX = 1f;
    [SerializeField] public float maxX = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = paddlePos;
    }
}
