using System;

namespace DemoLibrary
{
    public  class OverdraftEventArgs : EventArgs
    {
        public OverdraftEventArgs(decimal amountOverdrafted, string moreInfo)
        {
            AmountOverdrafted = amountOverdrafted;
            MoreInfo = moreInfo;
        }

        public decimal AmountOverdrafted { get; private set; }
        public string MoreInfo { get; private set; }
    }
}
