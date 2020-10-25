using System;

namespace Api.Management.Todo
{
    public class TodoItem
    {
        public int Id { get; set; } = int.MinValue;
        public string Title { get; set; }
        public bool Completed { get; set; } = false;
    }
}
