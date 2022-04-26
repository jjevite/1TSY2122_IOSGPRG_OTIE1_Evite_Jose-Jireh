using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public enum Direction {up, right, down, left, upperLeft, upperRight, downRight, downLeft, dDefault}
public class Player : MonoBehaviour
{
    // Default is 8 Dont Forgetti
    [SerializeField] private int arrow;
    [SerializeField] public int life;

    // Replacing this with enum
    //[SerializeField] private Direction direction = Direction.dDefault;

    public int Arrow
    {
        get
        {
            return arrow;
        }
        set
        {
            arrow = value;
        }
    }
    // Swipe Tap
    public TextMeshProUGUI outputText;

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;

    // Automatic Upward Movement
    public float ms = 5;

    // Dash
    private Rigidbody2D rb;
    public float dashSpeed;
    public bool isDashing = false;
    [SerializeField] ParticleSystem dashPartcileEffect;

    // Wild Swing Skill
    public Animator wildSwingAnimator;
    private bool isSwingingSword = false;

    // Event System if touching over UI
    public EventSystem eventSystem;

    // Mega Dash Skill
    public bool isMegaDashing = false;
    public Animator megaDashAnimator;

    // char
    public int colorInt = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colorInt = PlayerPrefs.GetInt("SelectedChar");
        if(colorInt == 0)
        {
            rb.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        else if(colorInt == 1)
        {
            rb.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            rb.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
    }

    void Update()
    {
        transform.Translate(new Vector2(1, 0).normalized * ms * Time.deltaTime);
        if(life <= 0)
        {
            FindObjectOfType<GameMgr>().EndGame();
        }
        Swipe();
    }

    public void megaDash()
    {
        if (isMegaDashing == false && isSwingingSword == false)
        {
            StartCoroutine(MegaDashCD());
        }
    }

    IEnumerator MegaDashCD()
    {
        isMegaDashing = true;
        FindObjectOfType<GameMgr>().current -= 100;
        megaDashAnimator.SetBool("isMegaDashinger", true);
        ms += 20;

        yield return new WaitForSeconds(4);

        ms -= 20;
        megaDashAnimator.SetBool("isMegaDashinger", false);
        isMegaDashing = false;
    }
    public void swingSword()
    {
        if(isSwingingSword == false && isMegaDashing == false)
        {
            StartCoroutine(swingSwordCD());
        }
    }

    IEnumerator swingSwordCD()
    {
        isSwingingSword = true;
        wildSwingAnimator.SetBool("isPlay", true);
        FindObjectOfType<GameMgr>().current -= 50;

        yield return new WaitForSeconds(2);

        isSwingingSword = false;
        wildSwingAnimator.SetBool("isPlay", false);
    }

    public void Dash()
    {
        if(isDashing == false)
        {
            StartCoroutine(DashTimer());
        }

    }

    public void PlayerArrowChange()
    {
        StartCoroutine(ArrowTimer());
    }

    IEnumerator DashTimer()
    {
        isDashing = true;
        rb.velocity = Vector2.up * dashSpeed;
        if (colorInt == 1)
        {
            FindObjectOfType<GameMgr>().addToMeter(2);
        }
        
        dashPartcileEffect.Play();
       
        yield return new WaitForSeconds(0.1f);
     
        isDashing = false;
        rb.velocity = Vector2.zero;
    }

    IEnumerator ArrowTimer()
    {
        yield return new WaitForSeconds(0.1f);

        arrow = 8;
    }

    private bool IsPointerOverUIObject()
    {
       
        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        eventSystem.RaycastAll(eventData, results);
        return results.Count > 0;   
    }

    public void Swipe()
    {
        if (isMegaDashing == false)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                currentPosition = Input.GetTouch(0).position;
                Vector2 Distance = currentPosition - startTouchPosition;

                if (!stopTouch)
                {
                    if (Distance.x < -swipeRange && Distance.y < -swipeRange)
                    {
                        outputText.text = "Lower Left";
                        stopTouch = true;
                        arrow = 7;
                        PlayerArrowChange();

                    }
                    else if (Distance.x > swipeRange && Distance.y < -swipeRange)
                    {
                        outputText.text = "Lower Right";
                        stopTouch = true;
                        arrow = 6;
                        PlayerArrowChange();
                    }
                    else if (Distance.x < -swipeRange && Distance.y > swipeRange)
                    {
                        outputText.text = "Upper Left";
                        stopTouch = true;
                        arrow = 4;
                        PlayerArrowChange();
                    }
                    else if (Distance.x > swipeRange && Distance.y > swipeRange)
                    {
                        outputText.text = "Upper Right";
                        stopTouch = true;
                        arrow = 5;
                        PlayerArrowChange();
                    }

                    else if (Distance.x < -swipeRange)
                    {
                        outputText.text = "Left";
                        stopTouch = true;
                        arrow = 3;
                        PlayerArrowChange();
                    }
                    else if (Distance.x > swipeRange)
                    {
                        outputText.text = "Right";
                        stopTouch = true;
                        arrow = 1;
                        PlayerArrowChange();
                    }
                    else if (Distance.y > swipeRange)
                    {
                        outputText.text = "Up";
                        stopTouch = true;
                        arrow = 0;
                        PlayerArrowChange();
                    }
                    else if (Distance.y < -swipeRange)
                    {
                        outputText.text = "Down";
                        stopTouch = true;
                        arrow = 2;
                        PlayerArrowChange();
                    }

                }

            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                stopTouch = false;

                endTouchPosition = Input.GetTouch(0).position;

                Vector2 Distance = endTouchPosition - startTouchPosition;

                if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
                {
                    if (IsPointerOverUIObject())
                    {
                        // Do Nothing
                    }
                    else
                    {
                        Dash();

                    }
                }
            }
        }
        else
        {
            // Do Nothing
        }
    }
}
