namespace TubeBuddyAssessment.Services
{
    public interface ISettingsService
    {
        bool IsFirstRun();
        void SetAppIsInitated();
    }
}
