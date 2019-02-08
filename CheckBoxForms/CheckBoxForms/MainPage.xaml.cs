using CheckBoxForms.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CheckBoxForms
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<HelperModel> statusRecords;
        string[] statusList;
        public MainPage()
        {
            InitializeComponent();

            statusList = new string[] { "All", "red", "green", "yellow", "blue" };
            statusRecords = new ObservableCollection<HelperModel>();

            //Adding list value into model 
            foreach (var status in statusList)
            {
                statusRecords.Add(new HelperModel
                {
                    Name = status
                });
            }
            ListView1.ItemsSource = statusRecords;
        }

        private void ListView1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            var statusData = e.SelectedItem as HelperModel;
            ((ListView)sender).SelectedItem = null;

           
            if (statusData.Name == "All")
            {
                statusRecords.ToList().ForEach(x => x.IsSelected = false);
            }
            else
            {
                statusRecords[0].IsSelected = false;
            }

            var item = statusRecords.Where(x => x.Name == statusData.Name).FirstOrDefault();
            if (item != null)
                item.IsSelected = !item.IsSelected;

            
        }
    }
}
