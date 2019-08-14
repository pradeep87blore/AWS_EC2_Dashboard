using Amazon.EC2;
using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ec2Communicator
{
    // This class helps with all security groups related tasks like listing them, creating them, editing them, etc.
    public class SecurityGroupsHelper
    {
        public static List<SecurityGroup> ListSecurityGroupsForCurrentUser(AmazonEC2Client ec2Client)
        {
            var request = new DescribeSecurityGroupsRequest();
            var response = ec2Client.DescribeSecurityGroups(request);
            List<SecurityGroup> mySGs = response.SecurityGroups;

            //foreach (SecurityGroup item in mySGs)
            //{
            //    Console.WriteLine("Security group: " + item.GroupId);
            //    Console.WriteLine("\tGroupId: " + item.GroupId);
            //    Console.WriteLine("\tGroupName: " + item.GroupName);
            //    Console.WriteLine("\tVpcId: " + item.VpcId);
            //    Console.WriteLine();
            //}

            return mySGs;
        }

        public static string CreateSecurityGroup()
        {
            return null;
        }

        public static string EditSecurityGroup()
        {
            return null;
        }

        static void EnumerateSecurityGroups(AmazonEC2Client ec2Client)
        {
            var request = new DescribeSecurityGroupsRequest();
            var response = ec2Client.DescribeSecurityGroups(request);
            List<SecurityGroup> mySGs = response.SecurityGroups;
            foreach (SecurityGroup item in mySGs)
            {
                Console.WriteLine("Security group: " + item.GroupId);
                Console.WriteLine("\tGroupId: " + item.GroupId);
                Console.WriteLine("\tGroupName: " + item.GroupName);
                Console.WriteLine("\tVpcId: " + item.VpcId);
                Console.WriteLine();
            }
        }
    }
}
