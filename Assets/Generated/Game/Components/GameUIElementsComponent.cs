//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity uIElementsEntity { get { return GetGroup(GameMatcher.UIElements).GetSingleEntity(); } }
    public UIElementsComponent uIElements { get { return uIElementsEntity.uIElements; } }
    public bool hasUIElements { get { return uIElementsEntity != null; } }

    public GameEntity SetUIElements(ProgressBarPro newPlayerHealthSlider, UnityEngine.GameObject newLoosePanel, BuildPanel newBuildPanel, TMPro.TextMeshProUGUI newBalanceText, TMPro.TextMeshProUGUI newKillCountText) {
        if (hasUIElements) {
            throw new Entitas.EntitasException("Could not set UIElements!\n" + this + " already has an entity with UIElementsComponent!",
                "You should check if the context already has a uIElementsEntity before setting it or use context.ReplaceUIElements().");
        }
        var entity = CreateEntity();
        entity.AddUIElements(newPlayerHealthSlider, newLoosePanel, newBuildPanel, newBalanceText, newKillCountText);
        return entity;
    }

    public void ReplaceUIElements(ProgressBarPro newPlayerHealthSlider, UnityEngine.GameObject newLoosePanel, BuildPanel newBuildPanel, TMPro.TextMeshProUGUI newBalanceText, TMPro.TextMeshProUGUI newKillCountText) {
        var entity = uIElementsEntity;
        if (entity == null) {
            entity = SetUIElements(newPlayerHealthSlider, newLoosePanel, newBuildPanel, newBalanceText, newKillCountText);
        } else {
            entity.ReplaceUIElements(newPlayerHealthSlider, newLoosePanel, newBuildPanel, newBalanceText, newKillCountText);
        }
    }

    public void RemoveUIElements() {
        uIElementsEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public UIElementsComponent uIElements { get { return (UIElementsComponent)GetComponent(GameComponentsLookup.UIElements); } }
    public bool hasUIElements { get { return HasComponent(GameComponentsLookup.UIElements); } }

    public void AddUIElements(ProgressBarPro newPlayerHealthSlider, UnityEngine.GameObject newLoosePanel, BuildPanel newBuildPanel, TMPro.TextMeshProUGUI newBalanceText, TMPro.TextMeshProUGUI newKillCountText) {
        var index = GameComponentsLookup.UIElements;
        var component = (UIElementsComponent)CreateComponent(index, typeof(UIElementsComponent));
        component.PlayerHealthSlider = newPlayerHealthSlider;
        component.LoosePanel = newLoosePanel;
        component.BuildPanel = newBuildPanel;
        component.BalanceText = newBalanceText;
        component.KillCountText = newKillCountText;
        AddComponent(index, component);
    }

    public void ReplaceUIElements(ProgressBarPro newPlayerHealthSlider, UnityEngine.GameObject newLoosePanel, BuildPanel newBuildPanel, TMPro.TextMeshProUGUI newBalanceText, TMPro.TextMeshProUGUI newKillCountText) {
        var index = GameComponentsLookup.UIElements;
        var component = (UIElementsComponent)CreateComponent(index, typeof(UIElementsComponent));
        component.PlayerHealthSlider = newPlayerHealthSlider;
        component.LoosePanel = newLoosePanel;
        component.BuildPanel = newBuildPanel;
        component.BalanceText = newBalanceText;
        component.KillCountText = newKillCountText;
        ReplaceComponent(index, component);
    }

    public void RemoveUIElements() {
        RemoveComponent(GameComponentsLookup.UIElements);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherUIElements;

    public static Entitas.IMatcher<GameEntity> UIElements {
        get {
            if (_matcherUIElements == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UIElements);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUIElements = matcher;
            }

            return _matcherUIElements;
        }
    }
}
