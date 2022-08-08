using UnityEngine;
using UnityEngine.UIElements;

namespace Azimuth
{
public class CarMenu : SimpleMenu<CarMenu> {
    protected override void Awake() {
        base.Awake();
        documentRoot.Q<Button>(name: "back").clicked += OnBackPressed;
    }

    public override void OnBackPressed() {
        //PauseMenu.Show();
        Debug.Log("Car Menu OnBackPressed");
    }
}
}