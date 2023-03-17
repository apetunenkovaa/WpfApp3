using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp3
{
    public partial class Product
    {
        public SolidColorBrush solidColor
        {
            get
            {
                if (ProductionPersonCount < MinCostForAgent)
                {
                    SolidColorBrush color = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                    return color;
                }
                else
                {
                    SolidColorBrush color = new SolidColorBrush(Color.FromRgb(214, 45, 0));
                    return color;
                }
            }
        }

        public double productpersoncount
        {
            get
            {
                double ProductPersonCount = Convert.ToDouble(ProductionPersonCount);
                return (double)ProductionPersonCount;
            }
        }
    }
}