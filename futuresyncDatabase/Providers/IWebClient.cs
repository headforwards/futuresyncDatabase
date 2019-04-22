using System;
namespace futuresyncDatabase.Providers
{
    public interface IWebClient
    {
        string DownloadString(string address);
    }
}
