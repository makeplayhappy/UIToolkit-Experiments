using UnityEngine;
using UnityEngine.UIElements;

namespace Azimuth
{
public class HomeMenu : SimpleMenu<HomeMenu> {
    protected override void Awake() {
        base.Awake();
        documentRoot.Q<Button>(name: "quit").clicked += OnBackPressed;
    }

    public override void OnBackPressed() {
        //PauseMenu.Show();
        Debug.Log("Home Menu QUIT OnBackPressed");
    }
}
}