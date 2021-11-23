window.Texnomic =
{
    Blazor:
    {
        hCaptcha: function (DotNetInstance, ID, SiteKey, Theme, Size) {
            if (typeof hcaptcha == 'undefined')
                return false;
            hcaptcha.render(ID,
                {
                    'sitekey': SiteKey,

                    'theme': Theme,

                    'Size': Size,

                    'callback': function (Args) {
                        DotNetInstance.invokeMethodAsync('HCaptchaOnSuccess', Args);
                    },

                    'error-callback': function (Args) {
                        DotNetInstance.invokeMethodAsync('HCaptchaOnError', Args);
                    }
                });
            return true;
        }
    }
}