using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Activation : MonoBehaviour {

    public GameObject path;
    Transform dir;
    Transform oldDir;
    int pathCount = 0;
    int pathCountMax = 0;
    bool finished = false;
    GameObject player;

    public bool active = false;
    bool reversePathing = false;
    float speed = 5f;

    void Start()
    {
        oldDir = transform;
        pathCountMax = path.transform.childCount;
    }

    void getNextPath()
    {
        if(pathCount < pathCountMax)
        {
            oldDir = dir;
            dir = path.transform.GetChild(pathCount++);
        }
        else
        {
            dir = null;
        }
        
    }

    public void activate(GameObject player)
    {
        this.player = player;
        if (!finished)
        {
            oldDir = transform;
            active = true;
        }
        else
        {
            active = false;
            reversePathing = true;
        }
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
            if (active && !finished)
            {
                if (dir == null)
                {
                    getNextPath();
                    if (dir == null)
                    {
                        finished = true;
                        active = false;
                        reversePathing = true;
                    }
                }
                else
                {
                    Vector3 reach = dir.position - transform.localPosition;
                    Vector3 back = transform.localPosition - oldDir.position;

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
                        Quaternion rotation = Quaternion.LookRotation(back.normalized);
                        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, Time.deltaTime*5);
                        //this.transform.rotation = Quaternion.LookRotation(reach * (-1));
                    }
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
