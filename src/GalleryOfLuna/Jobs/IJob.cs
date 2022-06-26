namespace GalleryOfLuna.Jobs
{
    internal interface IJob
    {
        Task Execute() => Execute(default);

        Task Execute(CancellationToken cancellationToken);
    }
}