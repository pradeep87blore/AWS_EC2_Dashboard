using Amazon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ec2Communicator
{
    public class RegionFetcher
    {
        static List<string> regions = null;
        public static List<string> GetAllRegions()
        {
            if(regions != null)
            {
                return regions;
            }

            regions = new List<string>();
            
            foreach (var region in RegionEndpoint.EnumerableAllRegions)
            {
                if (region.DisplayName.Contains("Gov"))
                    continue; // Dont list gov  clouds
                regions.Add(region.DisplayName);
            }

            return regions;
        }

        public static RegionEndpoint StringToRegionEndpoint(string region)
        {
            foreach (var regionEp in RegionEndpoint.EnumerableAllRegions)
            {
                if (regionEp.DisplayName.Equals(region))
                    return regionEp;
            }

            return null;
        }
    }
}
