namespace Client
{
    public interface IFolderPicker
    {
        Task<string> PickFolder();
    }
}