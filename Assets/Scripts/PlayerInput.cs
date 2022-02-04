using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public Text outputText;

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;


    //////////////
    private bool enableSlowSwipe = false;

    //PlayerMovement
    public GameObject Player;

    private Vector3 posLeft = new Vector3(-1.367f, 1f, 0f);
    private Vector3 posMid = new Vector3(0f, 1f, 0f);
    private Vector3 posRight = new Vector3(1.367f, 1f, 0f);
    public Vector3 posCurrent;
    public float moveTime = 0.2f;

    //Shooting
    public GameObject bulletPrefab;
    private float bulletDistance = 28f;

    private void Start()
    {
        Player.transform.position = posMid;
        posCurrent = posMid;
    }

    void Update()
    {

        if(!enableSlowSwipe)
        {
            FastSwipe();
        }
        else
        {
            SlowSwipe();
        }

        
    }

    public void FastSwipe()
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

                if (Distance.x < -swipeRange)
                {
                    outputText.text = "Left";
                    stopTouch = true;
                    MoveLeft();
                }
                else if (Distance.x > swipeRange)
                {
                    outputText.text = "Right";
                    stopTouch = true;
                    MoveRight();
                }
                else if (Distance.y > swipeRange)
                {
                    outputText.text = "Up";
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange)
                {
                    outputText.text = "Down";
                    stopTouch = true;
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
                outputText.text = "Tap";
                Shoot();
            }

        }
    }

    public void SlowSwipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;


            Vector2 Distance = endTouchPosition - startTouchPosition;

           
                if (Distance.x < -swipeRange)
                {
                    outputText.text = "Left";
                    MoveLeft();
                }
                else if (Distance.x > swipeRange)
                {
                    outputText.text = "Right";
                    MoveRight();
                }
                else if (Distance.y > swipeRange)
                {
                    outputText.text = "Up";
                }
                else if (Distance.y < -swipeRange)
                {
                    outputText.text = "Down";
                }

                if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
                {
                outputText.text = "Tap";
                Shoot();
                }

        }

    }

    public void ChangeMode()
    {
        if (!enableSlowSwipe)
        {
            enableSlowSwipe = true;
        }
        else
        {
            enableSlowSwipe = false;
        }

    }

    //PlayerMovement

    public void MoveLeft()
    {
        if (posCurrent == posLeft)
        {
            posCurrent = posLeft;
        }else if (posCurrent == posMid)
        {
            LeanTween.moveLocal(Player, posLeft, moveTime);
            posCurrent = posLeft;
        }else if (posCurrent == posRight)
        {
            LeanTween.moveLocal(Player, posMid, moveTime);
            posCurrent = posMid;
        }
                  
    }

    public void MoveRight()
    {
        if (posCurrent == posLeft)
        {
            LeanTween.moveLocal(Player, posMid, moveTime);
            posCurrent = posMid;
        }else if(posCurrent == posMid)
        {
            LeanTween.moveLocal(Player, posRight, moveTime);
            posCurrent = posRight;
        }else if(posCurrent == posRight)
        {
            posCurrent = posRight;
        }            
    }

    //Shooting
    public void Shoot()
    {
        StartCoroutine(SpawnProjectile());
    }

    IEnumerator SpawnProjectile()
    {
        //Vector3 curTarget = new Vector3(posCurrent.x, posCurrent.y, 20f);
        GameObject shot = Instantiate(bulletPrefab, this.gameObject.transform.position, Quaternion.identity);
        shot.LeanMoveLocalZ(bulletDistance, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Destroy(shot);        
    }


}

