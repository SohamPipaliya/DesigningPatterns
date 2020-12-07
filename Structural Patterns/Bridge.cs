using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningPatterns.Structural_Patterns
{
    class Bridge
    {
        public static void Main()
        {
            ILEDTV RemoteControl = new SonyRemoteControl(new SonyLedTv());
            RemoteControl.SwitchOn();
            RemoteControl.SetChannel(101);
            RemoteControl.SwitchOff();

            Console.WriteLine();
            RemoteControl = new SamsungRemoteControl(new SamsungLedTv());
            RemoteControl.SwitchOn();
            RemoteControl.SetChannel(202);
            RemoteControl.SwitchOff();
            Console.Read();
        }
    }

    public interface ILEDTV
    {
        void SwitchOn();

        void SwitchOff();

        void SetChannel(int channelNumber);
    }

    public class SamsungLedTv : ILEDTV
    {
        public void SwitchOn()
        {
            Console.WriteLine("Turning ON : Samsung TV");
        }

        public void SwitchOff()
        {
            Console.WriteLine("Turning OFF : Samsung TV");
        }

        public void SetChannel(int channelNumber)
        {
            Console.WriteLine("Setting channel Number " + channelNumber + " on Samsung TV");
        }
    }

    public class SonyLedTv : ILEDTV
    {
        public void SwitchOn()
        {
            Console.WriteLine("Turning ON : Sony TV");
        }

        public void SwitchOff()
        {
            Console.WriteLine("Turning OFF : Sony TV");
        }

        public void SetChannel(int channelNumber)
        {
            Console.WriteLine("Setting channel Number " + channelNumber + " on Sony TV");
        }
    }

    public abstract class AbstractRemoteControl : ILEDTV
    {
        protected ILEDTV ledTv;

        protected AbstractRemoteControl(ILEDTV ledTv)
        {
            this.ledTv = ledTv;
        }

        public abstract void SwitchOn();
        public abstract void SwitchOff();
        public abstract void SetChannel(int channelNumber);
    }

    public class SamsungRemoteControl : AbstractRemoteControl
    {
        public SamsungRemoteControl(ILEDTV ledTv) : base(ledTv)
        {

        }

        public override void SwitchOn()
        {
            ledTv.SwitchOn();//ledtv inhetited from base class
        }

        public override void SwitchOff()
        {
            ledTv.SwitchOff();
        }

        public override void SetChannel(int channelNumber)
        {
            ledTv.SetChannel(channelNumber);
        }
    }

    public class SonyRemoteControl : AbstractRemoteControl
    {
        public SonyRemoteControl(ILEDTV ledTv) : base(ledTv)
        {
        }

        public override void SwitchOn()
        {
            ledTv.SwitchOn();
        }

        public override void SwitchOff()
        {
            ledTv.SwitchOff();
        }

        public override void SetChannel(int channelNumber)
        {
            ledTv.SetChannel(channelNumber);
        }
    }
}
