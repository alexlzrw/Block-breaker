using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour
{  
    [SerializeField] float screenWidthInUNits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    void Update(){
        float mousePositionInOunt = Input.mousePosition.x / Screen.width * screenWidthInUNits;
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePositionInOunt, minX, maxX);
        transform.position = paddlePosition;
            
    }
}
