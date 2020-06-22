window.JsFunctions =
{
    hCaptcha: function(DotNetInstance) {
        hcaptcha.render('hcaptcha',
            {
                'sitekey': 'd355811d-9cf2-4348-8bb6-7bb66f41f44e',

                'callback': function(Args) {
                    DotNetInstance.invokeMethodAsync('HCaptchaOnSuccess', Args);
                },

                'error-callback': function(Args) {
                    DotNetInstance.invokeMethodAsync('HCaptchaOnError', Args);
                }
            });
    }
}