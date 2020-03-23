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
        private ICharge _charge;
        private int _thresholdLow = 5;
        private int _thresholdHigh = 500;


        public ChargeControl(ICharge charge)
        { 
            charge.CurrentValueEvent += (sender, e) => HandleCurrentValueEvent(sender, e);
            _charge = charge;
        }

        private void HandleCurrentValueEvent(object sender, CurrentEventArgs e)
        {
            CurrentCharge = e.Current;
        }
        
        public void Regulate()
        {
            if (CurrentCharge > _thresholdLow && CurrentCharge <= _thresholdHigh)
            {
                _charge.StartCharge();
            }
            else
            {
                _charge.StopCharge();
            }
        }
        public bool IsConnected()
        {
            return _charge.Connected;
        }
    }
}
