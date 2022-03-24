using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Models
{
    public class StateData
    {
        public string header;
        public string text;

        public StateData(string header_, string description_)
        {
            header = header_;
            text = description_;
        }

        public string Header
        {
            get => header;
            set => header = value;
        }

        public string Text
        {
            get => text;
            set => text = value;
        }
    }
}