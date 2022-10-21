public class Example_NameDescHelp: Consideration
{
    public Example_NameDescHelp()
    {
        Name = "Give the object a descriptive name. Can be changed in the UI";
        Description = "Use the description to communicate the functionality of the consideration. Can be changed in UI";
        HelpText = "The help text, is a static text, which can't be changed in the UI";
    }

    protected override float CalculateBaseScore(IAiContext context)
    {
        throw new System.NotImplementedException();
    }
}