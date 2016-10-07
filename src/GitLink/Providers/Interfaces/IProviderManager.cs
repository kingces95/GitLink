namespace GitLink.Providers {
    public interface IProviderManager {
        ProviderBase GetProvider(string url);
    }
}