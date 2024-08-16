namespace Utilities.Core.UtilityApplication.Abstractions.Services.Storage
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }
    }
}
