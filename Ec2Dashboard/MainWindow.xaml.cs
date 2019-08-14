using Amazon;
using Ec2Communicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ec2Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string selectedRegion = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            try
            {
                //var ec2Creator = new EC2Helper(RegionEndpoint.USEast1);
                //ec2Creator.CreateInstance();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void FillUI(string selectedRegion)
        {
            EC2Helper.ListEc2Instances(selectedRegion);
        }

        private void ComboBox_regionLister_Initialized(object sender, EventArgs e)
        {
            var allRegions = RegionFetcher.GetAllRegions();
            comboBox_regionLister.ItemsSource = allRegions;
        }

        private void ComboBox_regionLister_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(comboBox_regionLister.SelectedItem.ToString());

            HandleRegionChanged();
        }

        private void HandleRegionChanged()
        {
            selectedRegion = comboBox_regionLister.SelectedItem.ToString();

            FillUI(selectedRegion);
        }

        private void Button_create_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(selectedRegion))
            {
                MessageBox.Show("Please select an appropriate region and retry");
                return;
            }
            EC2Helper.CreateInstance(selectedRegion);
        }
    }
}
