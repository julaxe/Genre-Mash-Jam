using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 10;
    //Menu
    public RingMenu MainMenuPrefab;
    protected RingMenu MainMenuInstance;
    protected bool isMenuOn = false;
    public Sprite icon;
    [HideInInspector]
    public PlayerMode Mode;

    
    //Turret Place
    public TowerSpaceCheck box;
    

    private Rigidbody2D body;
    public bool isGrounded;    
    public Canvas canvas;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Camera cam1;
    public Camera cam2;
    
    // Start is called before the first frame update
    void Start()
    {        
        box = FindObjectOfType<TowerSpaceCheck>();
        box.gameObject.SetActive(false);
        MainMenuInstance = Instantiate(MainMenuPrefab, canvas.transform);
        MainMenuInstance.gameObject.SetActive(false);
        SetMode(PlayerMode.Play);
        cam1.enabled = true;
        cam2.enabled = false;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //player jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        if(Input.GetKeyUp(KeyCode.G))
        {
            if (cam1.enabled == true)
            {
                cam1.enabled = false;
                cam2.enabled = true;
            }
            else
            {
                cam1.enabled = true;
                cam2.enabled = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            GameEvent.scraps += 1;
        }
        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            GameEvent.legs += 1;
        }
        if (Input.GetKeyUp(KeyCode.Keypad3))
        {
            GameEvent.arms += 1;
        }
        if (Input.GetKeyUp(KeyCode.Keypad4))
        {
            GameEvent.brains += 1;
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (MainMenuInstance.gameObject.activeInHierarchy)
            {
                SetMode(PlayerMode.Play);
            }
            else
            {
                SetMode(PlayerMode.Menu);
                
            }
        }


    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //player movement on x axis 
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
    }
    public void SetMode(PlayerMode mode)
    {
        Mode = mode;
        switch(mode)
        {
            case PlayerMode.Play:
                box.gameObject.SetActive(false);
                MainMenuInstance.gameObject.SetActive(false);
                break;
            case PlayerMode.Build:
                box.gameObject.SetActive(true);
                MainMenuInstance.gameObject.SetActive(false);
                break;
            case PlayerMode.Menu:
                box.gameObject.SetActive(false);
                MainMenuInstance.gameObject.SetActive(true);
                break;
        }
    }

    public enum PlayerMode
    {
        Play,
        Build,
        Menu
    }
}


