﻿namespace Il2Native.Logic.DOM2
{
    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    public abstract class Expression : Base
    {
        private ITypeSymbol _type;

        public override Kinds Kind
        {
            get { return Kinds.Expression; }
        }

        public ITypeSymbol Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
                this.IsReference = this._type != null ? _type.IsReferenceType : true;
            }
        }

        public virtual bool IsReference { get; set; }

        internal void Parse(BoundExpression boundExpression)
        {
            if (boundExpression == null)
            {
                throw new ArgumentNullException();
            }

            if (boundExpression.Type == null)
            {
                return;
            }

            this.Type = boundExpression.Type;
        }
    }
}
