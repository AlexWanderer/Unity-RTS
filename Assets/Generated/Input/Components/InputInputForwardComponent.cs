//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public InputForwardComponent inputForward { get { return (InputForwardComponent)GetComponent(InputComponentsLookup.InputForward); } }
    public bool hasInputForward { get { return HasComponent(InputComponentsLookup.InputForward); } }

    public void AddInputForward(float newSpeed) {
        var component = CreateComponent<InputForwardComponent>(InputComponentsLookup.InputForward);
        component.speed = newSpeed;
        AddComponent(InputComponentsLookup.InputForward, component);
    }

    public void ReplaceInputForward(float newSpeed) {
        var component = CreateComponent<InputForwardComponent>(InputComponentsLookup.InputForward);
        component.speed = newSpeed;
        ReplaceComponent(InputComponentsLookup.InputForward, component);
    }

    public void RemoveInputForward() {
        RemoveComponent(InputComponentsLookup.InputForward);
    }
}
