using DcMetroLib.Interfaces;

namespace DcMetroLib.Data
{
    public class MetroDataItemBase : IMetroData
    {
        /// <summary>
        /// Each object can post process its data
        /// </summary>
        internal virtual void Process()
        {
            // for overriding to process raw strings into typed objects
        }
    }
}
