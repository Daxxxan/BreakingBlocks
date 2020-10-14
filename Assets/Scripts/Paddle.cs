using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float paddleMinPosition = 1f;
    [SerializeField] float paddleMaxPosition = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(GetXPos(), paddleMinPosition, paddleMaxPosition), transform.position.y);
    }

    private float GetXPos() {
        if(FindObjectOfType<GameStatus>().IsAutoPlayEnabled()) {
            return FindObjectOfType<Ball>().transform.position.x;
        } else {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;;
        }
    }
}
