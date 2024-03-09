namespace VerticalSliceArchitecture.FeaturesAlt.Games.CrossCutting.Exceptions
{
    public class NoPlatformExistsException: Exception
    {
        public NoPlatformExistsException(int platformId)
            :base($"The platform with the provided id ({platformId}) does not exists.")
        {
            
        }
    }
}
