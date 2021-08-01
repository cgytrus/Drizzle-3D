﻿using System;
using Drizzle.Lingo.Runtime;

namespace Drizzle.Ported
{
    [MovieScript]
    public sealed partial class MovieScript : LingoScriptBase
    {
        public void Init(LingoGlobal global)
        {
            Init(this, global);
        }
    }
}