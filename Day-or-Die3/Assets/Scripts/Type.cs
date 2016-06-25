using UnityEngine;
using System.Collections;

public  class Type : MonoBehaviour {

	public enum Types
    {
        Pather,
        CameraPather,
        Door,
        Activator
    }

    public Types myType;

    public Types getMyType()
    {
        return myType;
    }
}
