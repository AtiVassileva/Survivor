using System;

namespace Survivor.Models
{
    using static Common.ExceptionMessages;

    public class Exit
    {
        private readonly string name;

        public Exit(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidNameExceptionMsg);
                }

                this.name = value;
            }
        }
    }
}
