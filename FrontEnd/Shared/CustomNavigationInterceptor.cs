namespace FrontEnd.Shared
{
    using CurrieTechnologies.Razor.SweetAlert2;
    using FrontEnd.Utils;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Routing;
    using Microsoft.JSInterop;
    using System.Net.NetworkInformation;
    using System.Threading.Tasks;

    public class CustomNavigationInterceptor : INavigationInterception
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        [Inject]
        protected SweetAlertService swl { get; set; }

        public Task EnableNavigationInterceptionAsync()
        {
            // Implementa la lógica para habilitar la interceptación de navegación
            return Task.CompletedTask;
        }

        public Task<bool> NavigateToUrlAsync(string url, bool forceLoad)
        {
            // Implementa la lógica para manipular la navegación a una URL específica
            // Puedes realizar acciones personalizadas o validar la URL antes de permitir la navegación

            return Task.FromResult(true); // Permitir la navegación a la URL especificada
        }

        public async Task<bool> NavigateToRouteAsync(string route, bool forceLoad)
        {
            if (route == "/")
            {

                var u = await new Functions(JSRuntime,swl).LeerUsuarioDesdeLocalStorage();

                if (u!=null)
                {
                    // Ocultar el menú si la verificación es exitosa
                    AppState.ShowSalir();
                    if(u.RolId==1)
                    {
                        AppState.ShowMenu();
                    }
                }
                else
                {
                    AppState.HideSalir();
                    AppState.HideMenu();

                }
            }

            return await Task.FromResult(true); // Permitir la navegación a la ruta especificada
        }
    }

}
