using UnityEngine;

public class Example_Parameters: Consideration
{
    public Example_Parameters()
    {
        AddParameter("Color param", Color.blue);
        AddParameter("Float param", 1.5f);
        AddParameter("String param", "");
    }

    protected override float CalculateBaseScore(IAiContext context)
    {
        // When getting parameters the type must be specified by the method
        var colorParam = ParameterContainer.GetParamColor("Color param");
        var floatParam = ParameterContainer.GetParamFloat("Float param");
        var stringParam = ParameterContainer.GetParamString("String param");

        return 0;
    }
}