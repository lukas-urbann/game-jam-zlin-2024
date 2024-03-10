using System;

[Serializable]
public class VariableReference
{
    public ValueIdentifier identifier;

    public float Value
    {
        get { return identifier.Value; }
        set { identifier.Value = value; }
    }
}
