using AutoCAD_WPF_SlopeAddon.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace AutoCAD_WPF_SlopeAddon.ViewModels
{
    public class userWindowVM : ViewModelBase
    {

        private Double _userLength;
        public Double UserLength
        {

            get
            {
                return _userLength;
            }
            set
            {
                _userLength = value;
                OnPropertyChanged(nameof(UserLength));
            }
        }

        private Double _userSlope;
        public Double UserSlope
        {

            get
            {
                return _userSlope;
            }
            set
            {
                _userSlope = value;
                OnPropertyChanged(nameof(UserSlope));
            }
        }

        
        public double[] UVector
        {
            get
            {
                double dX = UserLength / Math.Sqrt(Math.Pow(UserSlope / 100,2) + 1);
                double dY = UserSlope/ 100 * dX;

                
                double[] vec = new double[] { dX,dY, 0 };
            return vec;
            }

        }

        
        public double[] UOrigin { get; set; } = { 0, 0 ,0};

        public double[] UOriginPlusVec
        {
            get
            {
                double[] vec = new double[] { UVector[0] + UOrigin[0], UVector[1] + UOrigin[1], UVector[2] + UOrigin[2] };
                return vec;
            }

        }

       


        public ICommand DrawNewLine { get; }

        public ICommand DrawContLine { get; }


        public userWindowVM()
        {
            DrawNewLine = new newLineCommand(this);
            DrawContLine = new contLineCommand(this);
        }

 
    }
}
