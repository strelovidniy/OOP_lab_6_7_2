using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_lab_6_7_2
{
    interface IWork
    {
        public abstract void Add();

        public abstract void Remove();

        public abstract void Edit();

        public abstract void InitialiseBase(int n);

        public abstract void Sum();

        public abstract void Minimum();

        public abstract void Length();
    }
}
