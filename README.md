![Blazor](https://raw.githubusercontent.com/Texnomic/hCaptcha/master/Logo.png)
## Texnomic.Blazor.hCaptcha

![NuGet](https://img.shields.io/nuget/vpre/Texnomic.Blazor.hCaptcha?logo=NuGet&label=NuGet%20%7C%20Texnomic.Blazor.hCaptcha&logoColor=blue&color=blue)

ASP.NET Core hCaptcha Component for Server-Side Blazor.

## Installation

```pwsh
PM> Install-Package Texnomic.Blazor.hCaptcha
```

## Setup


1. Reference hCaptcha & NuGet Package JavaScript Files In `Pages/_Host.cshtml` File:

    ```html
    <head>

    <script src="https://hcaptcha.com/1/api.js&render=explicit" async type="text/javascript"></script>

    <script src="_content/Texnomic.Blazor.hCaptcha/scripts/hCaptcha.js" type="text/javascript"></script>

    </head>
    ```

2. Add Package Configuration To Dependancy Injection Services in `Startup.cs` File:

    ```csharp
    using Texnomic.Blazor.hCaptcha.Extensions;

    public void ConfigureServices(IServiceCollection Services)
    {
        Services.AddHttpClient();
        Services.AddHCaptcha(Options =>
        {
            Options.SiteKey = "10000000-ffff-ffff-ffff-000000000001";
            Options.Secret = "0x0000000000000000000000000000000000000000";
        });
    }
    ```

3. Create Callback Function & Backing Field To Capture Captcha Result In `Example.razor.cs` File:

    ```csharp
    private bool IsCaptchaValid { get; set; }

    protected void hCaptchaCallback(bool Result) => IsCaptchaValid = Result;
    ```

4. Finally, Drop-In hCaptcha Component & Bind Callback Function In `Example.razor` File:

    ```html
    <HCaptcha Callback="hCaptchaCallback" Theme="Theme.Dark"></HCaptcha>
    ```


## Donations

* [![PayPal](https://img.shields.io/static/v1?logo=PayPal&label=PayPal&message=https://www.paypal.me/texnomic&color=blue)](https://www.paypal.me/texnomic)
* ![Bitcoin](https://img.shields.io/static/v1?logo=Bitcoin&label=BTC&message=13wMqy8yg9yhJAAP2AXu8A2De1ptAYh6s4&color=orange)
* ![Ethereum](https://img.shields.io/static/v1?logo=Ethereum&label=Ethereum&message=0xfE171b1C5C5584b65ec58a6FA2009f6ECeE812D7&color=black&logoColor=black)