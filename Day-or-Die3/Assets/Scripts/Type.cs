using UnityEngine;
using System.Collections;

public  class Type : MonoBehaviour {

	public enum Types
    {
        Pather,
        CameraPather,
        Door,
        Activator,
        Ending,
        ChangeScene
    }

    public Types myType;

    public Types getMyType()
    {
        return myType;
    }
}
