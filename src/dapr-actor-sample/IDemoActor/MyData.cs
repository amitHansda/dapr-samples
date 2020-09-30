using System;

namespace IDemoActorInterfaces
{
    public class MyData
    {
        /// <summary>
        /// Gets or sets the value for PropertyA.
        /// </summary>
        public string PropertyA { get; set; }

        /// <summary>
        /// Gets or sets the value for PropertyB.
        /// </summary>
        public string PropertyB { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var propAValue = this.PropertyA ?? "null";
            var propBValue = this.PropertyB ?? "null";
            return $"PropertyA: {propAValue}, PropertyB: {propBValue}";
        }
    }
}
