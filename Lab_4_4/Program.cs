// Метод для установки режима, который включает или выключает элементы управления
using System.Reflection.Emit;

private void SetMode(bool mod)
{
    // Установка состояния элементов в зависимости от переданного режима
    SetControlsState(mod, label1, button1, button2);
    SetControlsState(!mod, button3, button4);
}

// Вспомогательный метод для изменения состояния переданных элементов управления
private void SetControlsState(bool isEnabled, params Control[] controls)
{
    foreach (var control in controls)
    {
        control.Enabled = isEnabled;
    }
}
