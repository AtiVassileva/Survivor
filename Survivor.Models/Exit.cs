using System;
using Survivor.Models.Enums;

namespace Survivor.Models
{
    using static Common.ExceptionMessages;

    public class Exit
    {
        private readonly string name;

        public Exit(string name, ExitType exitType)
        {
            this.Name = name;
            this.ExitType = exitType;
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

        public ExitType ExitType { get; }

        public override string ToString() => $"{this.Name} ({this.ExitType})";
    }
}
