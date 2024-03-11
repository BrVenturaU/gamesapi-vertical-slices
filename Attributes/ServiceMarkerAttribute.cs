namespace VerticalSliceArchitecture.Attributes
{
    public class ServiceMarkerAttribute: Attribute
    {
        public Type InterfaceType { get; } = null;
        public ServiceMarkerAttribute()
        {
            
        }

        public ServiceMarkerAttribute(Type interfaceType)
        {

            InterfaceType = interfaceType;

        }
    }
}
