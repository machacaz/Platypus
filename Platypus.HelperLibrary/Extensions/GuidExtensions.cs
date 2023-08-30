namespace Platypus.HelperLibrary.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsNullOrEmptyGuid(this Guid? guid)
        {
            return (guid == null || guid == Guid.Empty);
        }
    }
}
