using UnityEngine;
using System.Collections;

public class dayMove : MonoBehaviour {

    public GameObject path;
    public bool done = false;
    bool reverse = false;
    float speed = 5f;
    bool activatet;
    int pathCountMax = 0;
    int pathCount = 0;
    Transform dir;
    // bool forward = true;
    // Use this for initialization
    void Start () {
        pathCountMax = path.transform.childCount;
    }

    void getNextPath()
    {
        if (pathCount < pathCountMax )
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

    public void move()
    {
        activatet = true;
        done = false;
    }

    public bool getDone()
    {
        return done;
    }
	// Update is called once per frame
	void Update () {

        if (activatet && !reverse)
        {
            if (dir == null)
            {
                getNextPath();
                if (dir == null)
                {
                    done = true;
                    activatet = false;
                    reverse = true;
                }
            }
            else
            {
                Vector3 reach = dir.position - transform.position;

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

        if (activatet && reverse)
        {
            if (dir == null)
            {
                getLastPath();
                if (dir == null)
                {
                    done = true;
                    reverse = false;
                    activatet = false;
                }
            }
            else
            {
                Vector3 reach = dir.position - transform.position;

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
}
