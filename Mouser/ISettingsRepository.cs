namespace Mouser
{
    internal interface ISettingsRepository
    {
        void Save(MouserSettings settings);
        MouserSettings Load();
    }
}