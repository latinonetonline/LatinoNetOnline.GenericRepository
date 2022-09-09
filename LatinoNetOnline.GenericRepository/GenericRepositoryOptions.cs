namespace LatinoNetOnline.GenericRepository
{
    public enum RepositoryTypeAllowed
    {
        Sync,
        Async,
        Both
    }

    public class GenericRepositoryOptions
    {
        public RepositoryTypeAllowed RepositoryTypeAllowed { get; set; } = RepositoryTypeAllowed.Both;
    }
}
