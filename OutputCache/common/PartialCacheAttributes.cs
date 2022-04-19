using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Configuration;

namespace OutputCache.common
{
    public class PartialCacheAttributes:OutputCacheAttribute
    {
        public PartialCacheAttributes(string cacheProfileName)
        {
            OutputCacheSettingsSection outputCacheSettingsSection =
                (OutputCacheSettingsSection)WebConfigurationManager.GetSection("system.web/caching/outputCacheSettings");
            OutputCacheProfile outputCacheProfile = outputCacheSettingsSection.OutputCacheProfiles[cacheProfileName];
            Duration = outputCacheProfile.Duration;
            VaryByParam = outputCacheProfile.VaryByParam;
        }
    }
}