using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmateurRadioNewsline
{
    internal class PTT : IDisposable, INotifyPropertyChanged
    {
        public String name
        {
            set
            {
                Dispose();
                m_ptt = new SerialPort();
                m_ptt.PortName = value;
                try
                {
                    m_ptt.Open();
                }
                catch
                {
                    Dispose();
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("open"));
            }
        }

        public bool value
        {
            get
            {
                return (m_ptt?.IsOpen ?? false) && m_ptt.RtsEnable;
            }
            set
            {
                if(this.value != value)
                {
                    if (m_ptt?.IsOpen ?? false)
                    {
                        m_ptt.RtsEnable = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("value"));
                        if (value) m_start = DateTime.Now;
                    }
                }
            }
        }

        public TimeSpan onAirTime
        {
            get
            {
                return value ? DateTime.Now - m_start : TimeSpan.Zero;
            }
        }

        public bool open
        {
            get
            {
                return m_ptt != null;
            }
        }

        public void Dispose()
        {
            m_ptt?.Dispose();
            m_ptt = null;
        }

        private SerialPort? m_ptt;
        private DateTime m_start;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
