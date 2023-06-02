using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.JSInterop;

namespace FrontEnd.Utils
{
    public  class Functions
    {
        private  IJSRuntime _runtime { get; set; }
        private  SweetAlertService _swl { get; set; }
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
