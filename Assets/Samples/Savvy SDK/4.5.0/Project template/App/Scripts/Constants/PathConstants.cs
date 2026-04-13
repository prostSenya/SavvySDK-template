using Alias = Savvy.Constants.PathConstants;

namespace App.Scripts.Constants
{
    public static class PathConstants
    {
        public const string ServicesDir = "Services";
        public const string StaticDataDir = "StaticData";

        public const string ResourcesPath = Alias.AssetsDir + "/" + Alias.ResourcesDir;
        public const string ServicesPath = ResourcesPath + "/" + ServicesDir;
    }
}