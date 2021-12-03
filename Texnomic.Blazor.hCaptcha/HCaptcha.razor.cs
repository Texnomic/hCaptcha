using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

using Texnomic.Blazor.hCaptcha.Configurations;
using Texnomic.Blazor.hCaptcha.Enums;

namespace Texnomic.Blazor.hCaptcha
{
    public partial class HCaptcha : IDisposable
    {
        [Inject] protected IJSRuntime JsRuntime { get; set; }

        [Inject] protected IHttpClientFactory HttpClientFactory { get; set; }

        [Inject] protected IOptionsMonitor<HCaptchaConfiguration> Configuration { get; set; }

        [Parameter] public EventCallback<bool> Callback { get; set; }
        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Size Size { get; set; }

        private DotNetObjectReference<HCaptcha> Instance { get; set; }

        protected string ID { get; set; }

        public HCaptcha()
        {
            ID = Guid.NewGuid().ToString().Replace("-", "");
        }

        protected override async Task OnAfterRenderAsync(bool FirstRender)
        {
            if (FirstRender)
            {
                Instance = DotNetObjectReference.Create(this);

                while (!await JsRuntime.InvokeAsync<bool>("Texnomic.Blazor.hCaptcha", Instance, ID,
                    Configuration.CurrentValue.SiteKey, Theme.ToString().ToLower(), Size.ToString().ToLower()))
                    await Task.Delay(20);
            }
        }

        [JSInvokable("HCaptchaOnSuccess")]
        public async Task OnSuccess(string Token)
        {
            var HttpClient = HttpClientFactory.CreateClient("hCapatcha");

            var Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("response", Token),
                    new KeyValuePair<string, string>("secret", Configuration.CurrentValue.Secret),
                });

            var Result = await HttpClient.PostAsync("https://hcaptcha.com/siteverify", Content);

            await Callback.InvokeAsync(Result.IsSuccessStatusCode);
        }

        [JSInvokable("HCaptchaOnError")]
        public async Task OnError()
        {
            await Callback.InvokeAsync(false);
        }

        public void Dispose()
        {
            Instance?.Dispose();
        }
    }
}