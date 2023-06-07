namespace FrontEnd.Shared
{
    public static class AppState
    {
        public static bool IsMenuVisible { get; set; } = false;
        public static bool IsSalirVisible { get; set; } = false;
        public static void ShowSalir()
        {
            IsSalirVisible= true;
        }
        public static void HideSalir()
        {
            IsSalirVisible = false;
        }
        public static void ShowMenu()
        {
            IsMenuVisible= true;
        }
        public static void HideMenu()
        {
            IsMenuVisible = false;
        }
    }
}
