namespace futuresyncDatabase.Providers
{
    public class WebClient : IWebClient
    {
        private readonly System.Net.WebClient webClient;

        public WebClient()
        {
            webClient = new System.Net.WebClient();
        }

        public string DownloadString(string address)
        {
            return webClient.DownloadString(address);
        }
    }
}
