using SaAddressApi.Net.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaAddressApi.Net
{
    public class Helper
    {


        /// <summary>
        /// return the formatted address from <see cref="ISaAddress"/> components details
        /// </summary>
        /// <param name="saAddress">
        /// <see cref="SaAddressV3"/> Or <see cref="SaAddressV4"/>
        /// </param>
        /// <exception cref="System.ArgumentNullException">must be no null val</exception>
        /// <returns>
        /// Formatted Address as a string [buildingNumber] [street]-{District}، {City} {PostCode}-{AdditionalCode} {RegionName}
        /// </returns>
        public static string ConvertToArbicFormattedAddress(ISaAddress saAddress)
        {
            if (saAddress == null)
                throw new ArgumentNullException(nameof(saAddress));

            //TODO!! generate format that works intelligently with null and white spaces

            var str = $"{saAddress?.Title} {saAddress?.BuildingNumber} {saAddress?.Street} - {saAddress?.District}، {saAddress?.City} {saAddress?.PostCode} - {saAddress?.AdditionalNumber} ({saAddress?.RegionName})";



            return str;
        }
    }
}
