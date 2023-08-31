namespace Platypus.HelperLibrary
{
    public static class Enums
    {
        /// <summary>
        /// Entity Status - The IsDeleted (-1) can be used to set a scenario as SoftDelete
        /// </summary>
        public enum EntityStatus
        {
            IsDeleted = -1,
            IsDisabled = 0,
            IsEnabled = 1,
        }
    }
}