using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ISS_App
{
    public partial class NavTab : TabbedPage
    {
        // previous screen size
        private double width = 0;
        private double height = 0;
        public NavTab()
        {
            InitializeComponent();
            //UpdateLayout();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); // THIS MUST STAY

            if(this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;
                // screen size has changed
            }
        }

        /// <summary>
        /// Decide on Portrait or Landscape
        /// </summary>
/*        private void UpdateLayout()
        {
            if (Content == null) return;
            string inputString = Content.FindByName<Entry>("inout")?.Text ?? "";
            if(width > height)
            {
                // landscape
                
                // if there is data pass in here
                Content = new HomeLandscape(inputString);

            }
            else
            {
                // portrait
                Content = new HomePortrait(inputString);
            }
        }*/
    }
}
