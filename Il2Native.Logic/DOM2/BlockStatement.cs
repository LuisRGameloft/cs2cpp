﻿namespace Il2Native.Logic.DOM2
{
    using System;

    public class BlockStatement : Statement
    {
        public Base Statements { get; set; }

        public bool NoSeparation { get; set; }

        internal override void Visit(Action<Base> visitor)
        {
            base.Visit(visitor);
            visitor(this.Statements);
        }

        internal override void WriteTo(CCodeWriterBase c)
        {
            if (this.Statements != null)
            {
                PrintBlockOrStatementsAsBlock(c, this.Statements);
            }
            else
            {
                base.WriteTo(c);
            }

            if (!this.NoSeparation)
            {
                // No normal ending of Statement as we do not need extra ;
                c.Separate();
            }
        }
    }
}
