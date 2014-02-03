using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficSimulatorUi.Intersection.Configurations;

namespace TrafficSimulatorUi
{
    /// <summary>
    /// A collection of preset intersection configurations.
    /// </summary>
    public sealed class IntersectionConfigurations
    {
        public static readonly IntersectionConfiguration Type1Configuration =
            new Type1Configuration();
        public static readonly IntersectionConfiguration Type2Configuration =
            new Type2Configuration();
        public static readonly IntersectionConfiguration Type3Configuration =
            new Type3Configuration();
        public static readonly IntersectionConfiguration Type4Configuration =
            new Type4Configuration();
        public static readonly IntersectionConfiguration Type5Configuration =
            new Type5Configuration();
        public static readonly IntersectionConfiguration TypeRailwayConfiguration =
            new TypeRailwayConfiguration();


        /// <summary>
        /// Non instantiable class (could also have made it abstract)
        /// </summary>
        private IntersectionConfigurations() {}
        
        /// <summary>
        /// Get the configuration for a specific intersection type.
        /// 
        /// Use of method is not mandatory when you need an intersection configuration. 
        /// You can also access configurations from the public attributes of this class.
        /// 
        /// The method IS used to make configurations selectable through the UI editor of visual studio.
        /// See the property IntersectionType of the class IntersectionControl.
        /// </summary>
        /// <param name="intersectionType">The type of the intersection</param>
        /// <returns>The configuration</returns>
        public static IntersectionConfiguration GetConfig(IntersectionType intersectionType)
        {
            switch (intersectionType)
            {
                case IntersectionType.TYPE_1: return Type1Configuration;
                case IntersectionType.TYPE_2: return Type2Configuration;
                case IntersectionType.TYPE_3: return Type3Configuration;
                case IntersectionType.TYPE_4: return Type4Configuration;
                case IntersectionType.TYPE_5: return Type5Configuration;
                case IntersectionType.TYPE_RAILWAY: return TypeRailwayConfiguration;
                default: return null;
            }
        }

        /// <summary>
        /// Save configurations to a file
        /// </summary>
        /// <param name="configurations">The configurations to save</param>
        /// <param name="fileName">The file name to save to.</param>
        public static void SaveConfigurations(List<IntersectionConfiguration> configurations, 
            String fileName)
        {
            // Feel free to give it a go!
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load configurations from a file
        /// </summary>
        /// <param name="fileName">The file name to load the configuration from.</param>
        /// <returns>A list of configurations.</returns>
        public static List<IntersectionConfiguration> LoadConfigurations(String fileName)
        {
            // Feel free to give it a go!
            throw new NotImplementedException();
        }
    }
}
