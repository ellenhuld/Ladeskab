using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interface;

namespace Ladeskab
{
    public class ChargeControl : IChargeControl
    {
        public double CurrentCharge { get; set;}
        private int _threshold;
        private IChargeControl _chargeControl;
        private ICharge charge;


        public ChargeControl(int threshold, ICharge charge)//, IChargeControl chargeControl)
        { 
            charge.CurrentValueEvent += (sender, e) => HandleCurrentValueEvent(sender, e);
            _threshold = threshold;
            //_chargeControl = chargeControl;
        }

        private void HandleCurrentValueEvent(object sender, CurrentEventArgs e)
        {
            CurrentCharge = e.Current;
            Regulate();
        }

        private void Regulate()
        {
            if (CurrentCharge < _threshold)
            {
                charge.StartCharge();
            }
            else
            {
                charge.StopCharge();
            }
        }
    }
}
