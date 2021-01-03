using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{

    public float jumpForce = 10f;
    public SpriteRenderer sr;
    public Rigidbody2D rb;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;

    private string _currentColor;
    
    // Start is called before the first frame update
    void Start()
    {
        SetRandomColor();
    }

    

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }
        
        if (col.tag != _currentColor)
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    private void SetRandomColor()
    {
        int index = Random.RandomRange(0, 3);

        switch (index)
        {
            case 0:
                _currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                _currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                _currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                _currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }
}
