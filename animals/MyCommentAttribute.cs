using System;

namespace library
{
    internal class MyCommentAttribute : Attribute
    {
        public string? Comment { get; }
        public MyCommentAttribute(string comment)
        {
            Comment = comment;
        }
    }
}