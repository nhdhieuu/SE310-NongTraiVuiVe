﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NongTraiVuiVe.DataAccessLayer.DataClass
{
    public interface IMilkable
    {
        int ProduceMilk();
    }

    public interface ISoundable
    {
        void MakeSound();
    }

    public interface IGiveBirth
    {
        int GiveBirth();
    }
}
