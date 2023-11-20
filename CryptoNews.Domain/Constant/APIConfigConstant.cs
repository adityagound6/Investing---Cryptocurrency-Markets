using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNews.Domain.Constant
{
    public class APIConfigConstant
    {
        public static string _baseUrl => "https://investing-cryptocurrency-markets.p.rapidapi.com/";
        public static string _newsEndpoint => "coins/get-news?pair_ID=1057391&page=1&time_utc_offset=28800&lang_ID=1";
        public static string _host => "investing-cryptocurrency-markets.p.rapidapi.com";
        public static string _key => "5383f682f8msh91314d808db40a2p161abfjsnbd07b9860ddc";
    }
}
