using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Activation : MonoBehaviour {

    public GameObject path;
    public GameObject movingObjects;
    Transform dir;
    Transform obj;
    int pathCount = 0;
    int pathCountMax = 0;
    int objectsCount = 0;
    int objectsCountMax = 0;
    int okays = 0;
    public bool finished = false;
    bool wait = false;
    bool lastPosition = false;
    public GameObject player;
    Transform playerPosition;

    public bool active = false;
    public bool reversePathing = false;
    float speed = 5f;

    void Start()
    {
        if(path != null)
            pathCountMax = path.transform.childCount;
        if(movingObjects != null)
            objectsCountMax = movingObjects.transform.childCount;
        if(player != null)
            playerPosition = player.transform;
    }

    void getNextPath()
    {
        if(pathCount < pathCountMax)
        {
            dir = path.transform.GetChild(pathCount++);
        }
        else
        {
            pathCount--;
            dir = null;
        }      
    }

    void getLastPath()
    {
        if (pathCount > -1)
        {
            dir = path.transform.GetChild(pathCount--);
        }
        else
        {
            pathCount++;
            dir = null;
        }
    }

    void getNextObject()
    {
        if (objectsCount < objectsCountMax)
        {
            obj = movingObjects.transform.GetChild(objectsCount++);
        }
        else
        {
            objectsCount = 0;
            obj = null;
        }
    }

    public void activate(GameObject player)
    {
        this.player = player;
        playerPosition = this.player.transform;
        active = true;
    }

    //move pathing object
    void pathing()
    {
        if (active && !finished)
        {
            if (dir == null)
            {
                getNextPath();
                if (dir == null)
                {
                    finished = true;
                }
                else
                {
                    transform.rotation = Quaternion.LookRotation(dir.position - transform.localPosition, Vector3.up) ;
                }
            }
            else
            {
                Vector3 reach = dir.position - transform.localPosition;

                float distThisFrame = speed * Time.deltaTime;

                if (reach.magnitude <= distThisFrame)
                {
                    //reached goal
                    dir = null;
                }
                else
                {
                    //Move to next node
                    transform.Translate(reach.normalized * distThisFrame);
                }
            }
        }
    }

    //move pathing object
    void cameraPathing()
    {
        if (!reversePathing)
        {

            //move to destination
            if (active && !finished)
            {
                if (dir == null)
                {
                    getNextPath();
                    if (dir == null)
                    {
                        finished = true;
                    }
                }
                else
                {
                    Vector3 reach = dir.position - transform.localPosition;

                    float distThisFrame = speed * Time.deltaTime;

                    if (reach.magnitude <= distThisFrame)
                    {
                        //reached goal
                        dir = null;
                    }
                    else
                    {
                        //Move to next node
                        transform.Translate(reach.normalized * distThisFrame, Space.Self);
                    }
                }
            }

            //rotate Camera
            if(active && finished)
            {
                Quaternion rotation = Quaternion.LookRotation(Vector3.down);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 5);
                if((transform.rotation.eulerAngles - rotation.eulerAngles).magnitude < 0.2f)
                {
                    transform.rotation = Quaternion.LookRotation(Vector3.down);
                    active = false;
                }
            }

            //activate all Objects to move
            if (!active && finished)
            {
                if (!wait)
                {
                    if (obj == null)
                    {
                        getNextObject();
                        if (obj == null)
                        {
                            wait = !wait;
                        }
                    }
                    else
                    {
                        obj.gameObject.GetComponent<dayMove>().move();
                        obj = null;
                    }
                }
                else
                {
                    if (obj == null)
                    {
                        getNextObject();
                        if (obj == null)
                        {
                            if (okays == objectsCountMax)
                            {
                                okays = 0;
                                reversePathing = true;
                                wait = !wait;
                                transform.rotation = Quaternion.LookRotation(Vector3.forward);
                            }
                            else
                                okays = 0;
                        }
                    }
                    else
                    {
                        if (obj.gameObject.GetComponent<dayMove>().getDone())
                            okays++;

                        obj = null;
                    }
                }
            }

        }
        else
        {
            if (!lastPosition)
            {
                if (dir == null)
                {
                    getLastPath();
                    if (dir == null)
                    {
                        lastPosition = true;
                    }
                }
                else
                {
                    Vector3 reach = dir.position - transform.localPosition;

                    float distThisFrame = speed * Time.deltaTime;

                    if (reach.magnitude <= distThisFrame)
                    {
                        //reached goal
                        dir = null;
                    }
                    else
                    {
                        //Move to next node
                        transform.Translate(reach.normalized * distThisFrame, Space.Self);
                    }
                }
            }
            else
            {
                //TODO:Change
                Vector3 reach = playerPosition.position - transform.localPosition;

                float distThisFrame = speed * Time.deltaTime;

                if (reach.magnitude <= distThisFrame)
                {
                    //reached goal
                    lastPosition = false;
                    finished = false;
                    active = false;
                    reversePathing = false;
                    player.GetComponent<Stats>().upWasser(Stats.wasserMax);
                    player.GetComponent<FirstPersonController>().enabled = true;
                }
                else
                {
                    //Move to next node
                    transform.Translate(reach.normalized * distThisFrame);
                }
            }
        }
    }

    void upgrade()
    {
        if (active && !finished)
        {
            player.GetComponent<FirstPersonController>().upgrade();
            finished = !finished;

        }
    }

    void Update()
    {
        if(GetComponent<Type>().getMyType() == Type.Types.Pather)
        {
            pathing();
        }
        if(GetComponent<Type>().getMyType() == Type.Types.Activator)
        {
            upgrade();
        }
        if (GetComponent<Type>().getMyType() == Type.Types.CameraPather)
        {
            cameraPathing();
        }
    }
}
