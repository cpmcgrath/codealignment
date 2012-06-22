using System;

namespace CMcG.CodeAlignment.Business
{
    public interface ILine
    {
        int    Position { get; }
        string Text     { get; }
    }
}