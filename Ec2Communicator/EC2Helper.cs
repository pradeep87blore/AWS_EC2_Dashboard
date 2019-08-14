using Amazon;
using Amazon.EC2;
using DataMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ec2Communicator
{
    public class EC2Helper
    {
        public static string CreateInstance(string region)
        {
            AmazonEC2Client ec2Client = new AmazonEC2Client(RegionFetcher.StringToRegionEndpoint(region));

            //SecurityGroupsHelper.ListSecurityGroupsForCurrentUser(ec2Client);

            return string.Empty;
        }

        public static Ec2Properties ListEc2Instances(string region)
        {
            AmazonEC2Client ec2Client = new AmazonEC2Client(RegionFetcher.StringToRegionEndpoint(region));

            var ec2DescRsp = ec2Client.DescribeInstances();

            return null;
        }
    }
}
