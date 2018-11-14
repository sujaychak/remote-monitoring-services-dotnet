// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.IoTSolutions.UIConfig.Services.Models;

namespace Microsoft.Azure.IoTSolutions.UIConfig.WebService.v1.Models
{
    public class PackageListApiModel
    {
        public IEnumerable<PackageApiModel> Items { get; set; }

        public PackageListApiModel(IEnumerable<Package> models)
        {
            this.Items = models.Select(m => new PackageApiModel(m));
        }

        public PackageListApiModel(IEnumerable<Package> models, string type, string config)
        {
            type = type.ToLower().Trim();
            config = config.ToLower().Trim();
            this.Items = models.Select( m =>  new PackageApiModel(m)).Where(
                                            package => (
                                            package.ConfigType != null
                                            && package.packageType.ToString().ToLower().Equals(type)
                                            && package.ConfigType.ToString().ToLower().Equals(config)));

        }
    }
}