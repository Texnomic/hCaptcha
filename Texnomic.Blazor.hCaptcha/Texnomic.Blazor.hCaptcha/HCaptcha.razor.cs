using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Texnomic.Blazor.hCaptcha
{
    public class HCaptchaBase : ComponentBase, IDisposable
    {
        [Inject] protected IJSRuntime JsRuntime { get; set; }
        
        private DotNetObjectReference<HCaptchaBase> Instance { get; set; }

        protected override async Task OnAfterRenderAsync(bool FirstRender)
        {
            if (FirstRender)
            {
                Instance = DotNetObjectReference.Create(this);

                await JsRuntime.InvokeVoidAsync("JsFunctions.hCaptcha", Instance);
            }
        }

        [JSInvokable("HCaptchaOnSuccess")]
        public async Task OnSuccess(string Token)
        {
            
        }

        [JSInvokable("HCaptchaOnError")]
        public async Task OnError()
        {

        }

        private bool IsDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool Disposing)
        {
            if (IsDisposed) return;

            if (Disposing)
            {
                Instance?.Dispose();
            }

            IsDisposed = true;
        }

        ~HCaptchaBase()
        {
            Dispose(false);
        }
    }
}