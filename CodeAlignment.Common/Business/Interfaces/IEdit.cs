using System;

namespace CMcG.CodeAlignment.Business
{
    public interface IEdit : IDisposable
    {
        bool Insert(ILine line, int position, string text);
        void Commit();
    }
}
