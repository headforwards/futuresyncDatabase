using System;
namespace futuresyncDatabase.Providers
{
    public class WebClientProvider : IWebClientProvider
    {
        public IWebClient WebClient()
        {
            return new WebClient();
        }
    }
}
