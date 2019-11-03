﻿using System;

namespace Mailbox
{
    [Flags]
    public enum Size
    {
        Undeclared = default,
        Small = 1,
        Medium = 3,
        Large = 5,
        Premium = 10,
        
        SmallPremium = Small | Premium,
        MediumPremium = Medium | Premium,
        LargePremium = Large | Premium
    }
}
