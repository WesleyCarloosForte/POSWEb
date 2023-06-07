using CurrieTechnologies.Razor.SweetAlert2;
using FrontEnd.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SharedProject.DTOs;

namespace FrontEnd.Utils
{
    public  class Functions
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private IJSRuntime JSRuntime { get; set; }
        private  IJSRuntime _runtime { get; set; }
        private  SweetAlertService _swl { get; set; }

        public async Task<UsuarioViewDTO> LeerUsuarioDesdeLocalStorage()
        {
            var usuarioJson = await _runtime.InvokeAsync<string>("localStorage.getItem", "Usuario");
            if (!string.IsNullOrEmpty(usuarioJson))
            {
                var r = System.Text.Json.JsonSerializer.Deserialize<UsuarioViewDTO>(usuarioJson);
                if (r.Id == 0 || r.RolId == 0)
                {
                    await EliminarUsuarioDesdeLocalStorage();
                    return null;
                }
                else
                {
                    return r;
                }
            }
            return null;
        }

        public async Task EliminarUsuarioDesdeLocalStorage()
        {
            try
            {
                var usuarioJson = await _runtime.InvokeAsync<string>("localStorage.getItem", "Usuario");
                if (!string.IsNullOrEmpty(usuarioJson))
                {
                    await _runtime.InvokeVoidAsync("localStorage.removeItem", "Usuario");

                }
                AppState.HideMenu();
                AppState.HideSalir();
                NavigationManager.NavigateTo("/");

            }
            catch (Exception)
            {


            }

        }
        public Functions(IJSRuntime runtime, SweetAlertService swl) 
        {
            this._runtime = runtime;
            this._swl = swl;
        
        }
        public  async Task ShowError(string txt, string title )
        {
                var res = await _swl.FireAsync(
                      new SweetAlertOptions
                      {
                          Title = title,
                          Text = $"{txt}",
                          Icon = SweetAlertIcon.Error,
                          ShowCancelButton = false,
                          ShowConfirmButton = false,
                          Timer = 1000,
                          ConfirmButtonText = "Ok",
                      });
            }

        public async Task NormalAler(string txt, string title)
        {
            var res = await _swl.FireAsync(
                  new SweetAlertOptions
                  {
                      Title = title,
                      Text = $"{txt}",
                      Icon = SweetAlertIcon.Info,
                      ShowCancelButton = false,
                      ShowConfirmButton = false,
                      Timer = 1000,
                      ConfirmButtonText = "Ok",
                  });
        }
        public async Task ShowSaved()
        {
            var res = await _swl.FireAsync(
                  new SweetAlertOptions
                  {
                      Title = "",
                      Text = $"",
                      Icon = SweetAlertIcon.Success,
                      ShowCancelButton = false,
                      ShowConfirmButton= false,
                      Timer= 1000,
                      ConfirmButtonText = "Ok",
                  });
        }
        public  async Task<Boolean> ShowConfirmation(string txt,string title) 
        {
            
            var res = await _swl.FireAsync(
                  new SweetAlertOptions
                  {
                      Title = title,
                      Text = txt,
                      Icon = SweetAlertIcon.Question,
                      ShowCancelButton = true,
                      ConfirmButtonText = "Sí",
                      CancelButtonText = "No"
                  });

            var r= !string.IsNullOrEmpty(res.Value);
            return r;
        }

    }
}
