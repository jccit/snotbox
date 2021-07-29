using System;

namespace Sandbox
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LibraryAttribute : Attribute
    {
        private string Id;
        public string Title;

        public LibraryAttribute(string Id)
        {
            this.Id = Id;
            Title = "";
        }
    }
}