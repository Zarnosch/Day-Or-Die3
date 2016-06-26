using UnityEngine;
using System.Collections;


public class LabGen : MonoBehaviour {

    [Header("Stats")]
    public int sizeX = 30;
    public int sizeZ = 20;
    public int sizeY = 15;
    public int scale = 2;
    public int paths = 9;
    public int pathlength = 120;
    public GameObject quadraticWall;
    public GameObject PivotofLab;
    public GameObject Sense;


    private Vector3 pivotVec;
    private int[,,] positioning;
    private int[] GasseX;
    private int[] GasseY;
    private int[] GasseZ;
    private int activePathCounts = 0;

    // Use this for initialization
    void Start () {
        //Debug.Log("Generate" + Time.realtimeSinceStartup);
        Random.seed = (int)((sizeX*sizeZ*sizeY*scale*Time.realtimeSinceStartup)% 2000);
        pivotVec = PivotofLab.transform.position;
        positioning = new int[sizeX, sizeZ, sizeY];
        GasseX = new int[pathlength];
        GasseY = new int[pathlength];
        GasseZ = new int[pathlength];
        MakePaths();
        CleanLab();
        GenerateLab();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MakePaths()
    {
        // init
        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    positioning[x, z, y] = 1;
                }
            }
        }

        for (int p = 0; p < paths; p++)
        {

            
            //pathlength = sizeX + 20;
            int activeX = 0;
            int activeZ = 5;
            int activeY = 1;
            int tactiveX = 0;
            int tactiveZ = 5;
            int tactiveY = 1;
            float tdir = -1;
            positioning[activeX, activeZ, activeY] = 2;

            if (p != 0)
            {
                activeX = GasseX[p - 1];
                activeZ = GasseZ[p - 1];
                activeY = GasseY[p - 1];
                tactiveX = activeX;
                tactiveZ = activeZ;
                tactiveY = activeY;
                tdir = -1;
                positioning[activeX, activeZ, activeY] = 0;
            }

            for (int i = 0; i < pathlength; i++)
            {
                if(pathlength > GasseX.Length)
                {
                    pathlength = GasseX.Length;
                }

                if (sizeX >= (pathlength - i)+ activeX)
                {
                    if (activeX <= sizeX)
                    {
                        if (p == 0)
                        {
                            positioning[activeX++, activeZ, activeY] = 2;
                            //positioning[activeX, activeZ, activeY++] = 2;
                        }
                        else
                        {
                            positioning[activeX++, activeZ, activeY] = 0;
                        }        
                    }
                }
                else
                {
                    float dir = Random.Range(0, 5);
                    if (dir <= 1 && !(tdir <= 1 && tdir > 0))
                    {
                        activeX += 1;
                    }
                    else if (dir <= 2 && !(tdir <= 2 && tdir > 1))
                    {
                        activeX -= 1;
                    }
                    else if (dir <= 3 && !(tdir <= 3 && tdir > 2))
                    {
                        activeZ += 1;
                    }
                    else if (dir <= 4 && !(tdir <= 4 && tdir > 3))
                    {
                        activeZ -= 1;
                    }
                    else if (dir <= 5 && !(tdir <= 5 && tdir > 4))
                    {
                        activeY += 1;
                    }
                    else if (dir <= 6 && !(tdir <= 6 && tdir > 5))
                    {
                        activeY -= 1;
                    }
                    if (activeX >= 0 && activeX < sizeX && activeZ > 2 && activeZ < sizeZ && activeY >= 0 && activeY < sizeY)
                    {
                        tdir = dir;
                        if (p == 0)
                        {
                            bool gasseSet = false;
                            positioning[activeX, activeZ, activeY] = 2;


                            if (activeX > 1 && activeX < sizeX-1 && activeZ > 1 && activeZ < sizeZ-1 && activeY > 1 && activeY < sizeY-1)
                            {
                                
                                if(positioning[activeX + 1, activeZ, activeY] != 2)
                                {
                                    positioning[activeX + 1, activeZ, activeY] = -1;
                                    if (i % 10 == 0 && activePathCounts < paths && !gasseSet)
                                    {
                                        GasseX[activePathCounts] = activeX+1;
                                        GasseZ[activePathCounts] = activeZ;
                                        GasseY[activePathCounts] = activeY;
                                    }
                                }
                                if (positioning[activeX - 1, activeZ, activeY] != 2)
                                {
                                    positioning[activeX - 1, activeZ, activeY] = -1;
                                    if (i % 10 == 0 && activePathCounts < paths && !gasseSet)
                                    {
                                        GasseX[activePathCounts] = activeX-1;
                                        GasseZ[activePathCounts] = activeZ;
                                        GasseY[activePathCounts] = activeY;
                                    }
                                }
                                if (positioning[activeX, activeZ + 1, activeY] != 2)
                                {
                                    positioning[activeX, activeZ + 1, activeY] = -1;
                                    if (i % 10 == 0 && activePathCounts < paths && !gasseSet)
                                    {
                                        GasseX[activePathCounts] = activeX;
                                        GasseZ[activePathCounts] = activeZ+1;
                                        GasseY[activePathCounts] = activeY;
                                    }
                                }
                                if (positioning[activeX, activeZ - 1, activeY] != 2)
                                {
                                    positioning[activeX, activeZ - 1, activeY] = -1;
                                    if (i % 10 == 0 && activePathCounts < paths && !gasseSet)
                                    {
                                        GasseX[activePathCounts] = activeX;
                                        GasseZ[activePathCounts] = activeZ-1;
                                        GasseY[activePathCounts] = activeY;
                                    }
                                }
                                if (positioning[activeX, activeZ, activeY + 1] != 2)
                                {
                                    positioning[activeX, activeZ, activeY + 1] = -1;
                                    if (i % 10 == 0 && activePathCounts < paths && !gasseSet)
                                    {
                                        GasseX[activePathCounts] = activeX;
                                        GasseZ[activePathCounts] = activeZ;
                                        GasseY[activePathCounts] = activeY+1;
                                    }
                                }
                                if (positioning[activeX, activeZ, activeY - 1] != 2)
                                {
                                    positioning[activeX, activeZ, activeY - 1] = -1;
                                    if (i % 10 == 0 && activePathCounts < paths && !gasseSet)
                                    {
                                        GasseX[activePathCounts] = activeX;
                                        GasseZ[activePathCounts] = activeZ;
                                        GasseY[activePathCounts] = activeY -1;
                                    }
                                }
                                
                            }
                            tactiveX = activeX;
                            tactiveZ = activeZ;
                            tactiveY = activeY;
                        }
                        else
                        {
                            if (activeX > 0 && activeX < sizeX && activeZ > 0 && activeZ < sizeZ && activeY > 0 && activeY < sizeY && positioning[activeX, activeZ, activeY] != -1)
                            {
                                positioning[activeX, activeZ, activeY] = 0;
                                tactiveX = activeX;
                                tactiveZ = activeZ;
                                tactiveY = activeY;
                            }
                        }
                        
                    }
                    else
                    {
                        activeX = tactiveX;
                        activeZ = tactiveZ;
                        activeY = tactiveY;
                    }
                }
            }
        }    
    }

    // instantiates the Lab
    void GenerateLab()
    {
        for(int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if(positioning[x,z,y] == 1 || positioning[x, z, y] == -1)
                    {
                    GameObject temp = (GameObject)Instantiate(quadraticWall, new Vector3(pivotVec.x + (x * scale), pivotVec.y + (y * scale), pivotVec.z + (z * scale)), Quaternion.identity);
                        
                    }
                    else if(positioning[x, z, y] == 2)
                    {
                        GameObject temp = (GameObject)Instantiate(Sense, new Vector3(pivotVec.x + (x * scale), pivotVec.y + (y * scale), pivotVec.z + (z * scale)), Quaternion.identity);
                    }
                }
            }
        }
    }

    void CleanLab()
    {
        for (int x = 1; x < sizeX-2; x++)
        {
            for (int z = 1; z < sizeZ-2; z++)
            {
                for (int y = 1; y < sizeY-2; y++)
                {
                    bool temp1 = false;
                    bool temp2 = false;
                    bool temp3 = false;
                    bool temp4 = false;
                    bool temp5 = false;
                    bool temp6 = false;
                    if(positioning[x , z, y] == 1)
                    {
                        if (positioning[x + 1, z, y] != 2 && positioning[x + 1, z, y] != -1 && positioning[x + 1, z, y] != 0)
                        {
                            temp1 = true;
                        }
                        if (positioning[x - 1, z, y] != 2 && positioning[x - 1, z, y] != -1 && positioning[x - 1, z, y] != 0)
                        {
                            temp2 = true;
                        }
                        if (positioning[x, z + 1, y] != 2 && positioning[x, z + 1, y] != -1 && positioning[x, z + 1, y] != 0)
                        {
                            temp3 = true;
                        }
                        if (positioning[x, z - 1, y] != 2 && positioning[x, z - 1, y] != -1 && positioning[x, z - 1, y] != 0)
                        {
                            temp4 = true;
                        }
                        if (positioning[x, z, y + 1] != 2 && positioning[x, z, y + 1] != -1 && positioning[x, z, y + 1] != 0)
                        {
                            temp5 = true;
                        }
                        if (positioning[x, z, y - 1] != 2 && positioning[x, z, y - 1] != -1 && positioning[x, z, y - 1] != 0)
                        {
                            temp6 = true;
                        }
                        if (temp1 && temp2 && temp3 && temp4 && temp5 && temp6)
                        {
                            positioning[x , z, y] = 0;
                        }
                    }                    
                }
            }
        }
    }
}
