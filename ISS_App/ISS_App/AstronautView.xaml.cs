using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISS_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AstronautView : ContentView
    {
        public AstronautView(string name, string craft)
        {
            InitializeComponent();
            labelAstronautName.Text = name;
            labelAstronautCraft.Text = craft;
        }
    }
}