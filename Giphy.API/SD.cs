namespace Giphy.API
{
    public static class SD
    {
        public static string GiphyApiBase {get;set; }
        public static string ApiKey {get;set; }
        public enum ApiType
        {
            GET, POST, PUT, DELETE
        }
        //Need to comlete all existing endpoints
        public enum EndPoint
        {
            Aoutocomplete,Categories,Search,Trending
        }
        public enum Raiting
        {
            g,r,pg
        }
        //Need to comlete all existing endpoints
        public enum Lang
        {
            en,es,pt,de
        }
        public enum Bundle
        {
            clips_grid_picker,messaging_non_clips,
            sticker_layering,low_bandwith
        }
    }
}
